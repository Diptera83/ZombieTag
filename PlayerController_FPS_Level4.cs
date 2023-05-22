using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController_FPS_Level4 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    private float moveHorizontal;
    private float moveVertical;

    public int PlayerHealth;
    public bool isPlayerDied;
    public Image FinishScreen;



    private void FixedUpdate()
    {


        if (!isPlayerDied)
        {

            moveHorizontal = _joystick.Vertical;
            moveVertical = _joystick.Horizontal;

            _rigidbody.rotation = Quaternion.Euler(20+(-moveHorizontal * 85), -50+(moveVertical * 85), 0);

        }

    }

    private void Start()
    {
        //transform.Find("Blood").GetComponent<ParticleSystem>().Stop();
        PlayerHealth = 100;
        isPlayerDied = false;
        //moveVertical = -150;
        //moveHorizontal = -5;
        //transform.rotation =  Quaternion.Euler(24.964f, -43.8f, 0f);

    }

    public void TakeDamage()
    {

        HeDied();



    }

    void HeDied()
    {
        if (!isPlayerDied)
        {
            PlayerHealth = PlayerHealth - 10;

            transform.Find("Blood").GetComponent<ParticleSystem>().Play();
            GameObject.Find("MachineGun").transform.position = new Vector3(999, 999, 999);
            GameObject.Find("Remy").GetComponent<BoxCollider>().enabled = false;
            isPlayerDied = true;
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

