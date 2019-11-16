using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    RaycastHit rac;
    Ray ray;
    float range = 100;
    float damage = 50f;
    public int mun = 100;
    public  LineRenderer line;
    public Camera camFps;
    public Text municion;


    private void Start()
    {
        camFps = Camera.main;
        municion = FindObjectOfType<Canvas>().transform.Find("Municion").GetComponent<Text>();
        municion.text = "Municion: " + mun + "/100";
    }

    void Update ()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(camFps.transform.position,camFps.transform.forward, out hit, range))
        {
            if(mun > 0)
            {
                mun--;
                municion.text = "Municion: " + mun + "/100";
                EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();
                if (target != null)
                {
                    Debug.Log(target.name);
                    target.takeDamage(damage);  
                }
            }
        }
    }

    public void Recarga()
    {
        mun = mun +(100 - mun);
        municion = FindObjectOfType<Canvas>().transform.Find("Municion").GetComponent<Text>();
        municion.text = "Municion: " + mun + "/100";
    }

}
