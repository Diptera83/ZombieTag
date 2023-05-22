using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;


    [SerializeField] private float _moveSpeed;
    private float moveHorizontal;
    private float moveVertical;

    public int PlayerHealth;
    public bool isPlayerDied;
    public Image FinishScreen;
    bool kazasoundplay;
    bool movementsoundplay;
    bool iskaza1;
    void playkazasound()
    {
        if (!kazasoundplay)
        { 
        GameObject.Find("kaza1").transform.Find("kazasound").GetComponent<AudioSource>().Play();
            kazasoundplay = true;
        }
        
    }
    void playmovementsound()
    {
        if (!movementsoundplay)
        {
            GameObject.Find("kaza1").transform.Find("movementeffect").GetComponent<AudioSource>().Play();
            movementsoundplay = true;
        }

    }

    
    private void FixedUpdate()
    {


        if (!isPlayerDied)
        {
            if (transform.position.x < -15)
            {
                GameObject.Find("Canvas").transform.Find("PanelReal").GetComponent<PanelSetActiveLevel1>().OpenPanel();
            }
            if (transform.position.x < 118 && !iskaza1)
            {
                
                GameObject.Find("kaza1").GetComponent<Animator>().SetBool("kaza1bool", true);
                GameObject.Find("kaza1").transform.Find("Target1red").gameObject.SetActive(true);
                playkazasound();
                iskaza1 = true;
                
            }
            if (transform.position.x < 65)
            {

                playmovementsound();

            }
            _rigidbody.velocity = new Vector3(-_joystick.Vertical * _moveSpeed, -_rigidbody.velocity.y, _joystick.Horizontal * _moveSpeed);


            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                // transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);


                moveHorizontal = _joystick.Horizontal;
                moveVertical = _joystick.Vertical;





                if (-moveVertical > 0)
                {

                    //GameObject.Find("Assault_Rifle_M4").transform.position = new Vector3(GameObject.Find("Assault_Rifle_M4").transform.position.x + 5, GameObject.Find("Assault_Rifle_M4").transform.position.y , GameObject.Find("Assault_Rifle_M4").transform.position.z );
                    _animator.SetBool("isRunBack", true);
                    _animator.SetBool("isRUN", false);


                }
                else if (-moveVertical < 0)
                {


                    _animator.SetBool("isRUN", true);
                    _animator.SetBool("isRunBack", false);
                }
                else
                {
                    _animator.SetBool("isRUN", false);
                    _animator.SetBool("isRunBack", false);
                }




            }
            else
            {
                _animator.SetBool("isRUN", false);

                _animator.SetBool("isRunBack", false);
            }
        }

    }

    private void Start()
    {
        transform.Find("Blood").GetComponent<ParticleSystem>().Stop();
        PlayerHealth = 100;
        isPlayerDied = false;
        GameObject.Find("PanelReal").transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);


        GameObject.Find("kaza1").transform.Find("go").GetComponent<AudioSource>().Play();
    }

    public void TakeDamage()
    {

        HeDied();



    }

    IEnumerator OpenPanelDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameObject.Find("Canvas").transform.Find("PanelReal").GetComponent<PanelSetActiveLevel1>().OpenPanel();
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("PanelReal").GetComponent<PanelSetActiveThirdPerson>().OpenPanel();
        }
    }

   public void HeDied()
    {
        if (!isPlayerDied)
        {
            PlayerHealth = PlayerHealth - 10;
            _animator.SetBool("isRUN", false);
            _animator.SetBool("isTakeDamage", false);
            _animator.SetBool("isDied", true);
            transform.Find("Blood").GetComponent<ParticleSystem>().Play();
            GameObject.Find("MachineGun").transform.position = new Vector3(999, 999, 999);
            GameObject.Find("Remy").GetComponent<BoxCollider>().enabled = false;
            isPlayerDied = true;

            StartCoroutine(OpenPanelDelay());

        }
        else
        {
            if (!transform.Find("Blood").GetComponent<ParticleSystem>().isPlaying)
            {
                transform.Find("Blood").GetComponent<ParticleSystem>().Stop();
            }


        }


    }








}

