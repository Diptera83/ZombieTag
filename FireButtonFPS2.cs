using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButtonFPS2 : Button
{
    float Zaman;
    bool basilimi;


    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        GameObject.Find("Main Camera").GetComponent<PlayerWeapon_FPS>().OpenFireButton = true;
        transform.Find("PS_Parent (6)").GetComponent<ParticleSystem>().Play();
        GameObject.Find("MachineGun").GetComponent<Animator>().SetBool("Rifle_Fire_Anime", true);
        basilimi = true;
        transform.Find("PS_Parent (6)").GetComponent<ParticleSystem>().Play(true);
    }

    // Button is released
    public override void OnPointerUp(PointerEventData eventData)
    {
        basilimi = false;
        base.OnPointerUp(eventData);
        GameObject.Find("Main Camera").GetComponent<PlayerWeapon_FPS>().OpenFireButton = false;
        transform.Find("PS_Parent (6)").GetComponent<ParticleSystem>().Stop();

        GameObject.Find("MachineGun").GetComponent<Animator>().SetBool("Rifle_Fire_Anime", false);

    }

    public void Update()
    {
        if (basilimi)
        {


            if (Time.time >= Zaman)
            {

                Zaman = Time.time;
                Zaman = Zaman + 0.02f;
            }
            else
            {

            }

        }
    }
}
