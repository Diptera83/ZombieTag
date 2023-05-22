using BigRookGames.Weapons;
using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletSpeed = 100;
    public float lifeTime = 3;
    public bool OpenFire;
    public bool OpenFireButton;
    public float saniye;

    // Start is called before the first frame update
    void Start()
    {
        OpenFire = false;
        saniye = Time.time;
        GunfireCont = GameObject.Find("MachineGun").GetComponent<GunfireController>();
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
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    GunfireController GunfireCont;
    public void FireTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenFire = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OpenFire = false;
        }

        if (OpenFire)
        {
            if (Time.time >= saniye + 0.2f)
            {
                Fire();
               GunfireCont.FireWeapon();
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
                GunfireCont.FireWeapon();
                saniye = Time.time;
            }


        }
    }
}

