using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon_FPS : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletSpeed = 100;
    public float lifeTime = 3;
    public bool OpenFire;
    public bool OpenFireButton;
    public float saniye;
    Animator RifleFireAnime;
    GunfireController GunfireController;

    // Start is called before the first frame update
    void Start()
    {
        OpenFire = false;
        saniye = Time.time;
        RifleFireAnime = GameObject.Find("MachineGun").GetComponent<Animator>();
        GunfireController = GameObject.Find("MachineGun").GetComponent<GunfireController>();
    }

    // Update is called once per frame
    void Update()
    {
        FireTriggerButton();
        FireTrigger();
    }



    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());
        bullet.transform.position = bulletSpawn.position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
       

        bullet.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z + -180);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        //transform.Find("MachineGun").position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
       
        Destroy(bullet);
    }

    public void FireTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenFire = true;
            RifleFireAnime.SetBool("Rifle_Fire_Anime",true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OpenFire = false;
            RifleFireAnime.SetBool("Rifle_Fire_Anime", false);
        }

        if (OpenFire)
        {
            if (Time.time >= saniye + 0.2f)
            {
                Fire();
                GunfireController.FireWeapon();
                saniye = Time.time;
            }


        }
    }

    public void FireTriggerButton()
    {
       
        if (OpenFireButton)
        {
            if (Time.time >= saniye + 0.2f)
            {
                Fire();
                GunfireController.FireWeapon();
                saniye = Time.time;
            }


        }
    }
}

