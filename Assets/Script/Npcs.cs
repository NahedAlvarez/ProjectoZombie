using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.Ally;
using Npc.Enemy;
[RequireComponent(typeof(Rigidbody))]

public class Npcs : MonoBehaviour
{
    public Acciones Actions;
    public bool reaction;
    public Age botAge;

    float rotate = 1;

    public Vector3 Rotate(int dir)
    {
        Vector3 vec = Vector3.zero;

        if (dir == 0)
        {
            vec.y -= rotate * Time.deltaTime;
        }
        if (dir == 1)
        {
            vec.y += rotate * Time.deltaTime;
        }
        return vec;
    }

    int move = 100;
    public Vector3 Avanzar(int dir)
    {
        Vector3 vec = Vector3.zero;

        if (dir == 0)
        {
            vec.x = -move * Time.deltaTime;
        }
        if (dir == 1)
        {
            vec.x = +move * Time.deltaTime;
        }
        if (dir == 2)
        {
            vec.z = +move * Time.deltaTime;
        }
        if (dir == 3)
        {
            vec.z = -move * Time.deltaTime;
        }
        return vec/botAge.age;
    }
    private void Awake()
    {
        botAge.age = Random.Range(15, 100);
    }
    public bool target;
    public virtual void Reaccionar()
    {
        Vector3 direc;
        int distMax = 5;
        float distMin = 1.0f;
     

        foreach (GameObject go in GameManager.npcList)
        {
            float distanceTarget = Vector3.Distance(transform.position, go.transform.position);
            if (go.GetComponent<Player>()|| go.GetComponent<Citizen>())
            {
                if (distanceTarget <= distMax)
                {
                    if(distanceTarget >= distMin)
                    {
                        StopCoroutine(fade());
                        Actions = Acciones.Reaccionar;
                        direc = Vector3.Normalize(go.transform.position - gameObject.transform.position);
                        gameObject.transform.position += direc * 0.04f;
                        transform.LookAt(go.transform);
                        target = true;
                    }   
                }
            }
        }
    }

    public virtual void Agrupar()
    {
        switch (Actions)
        {
            case Acciones.Iddle:
                transform.position += Vector3.zero;
                break;
            case Acciones.move:
                transform.position+=Avanzar(moveop);
                break;
            case Acciones.rotate:
                transform.Rotate(Rotate(rotateop) * Time.deltaTime * Random.Range(1000, 1500));
                break;
        }
    }
   
    private void Update()
    {
        Agrupar();

        if(corroutinebool == true)
        {
            StartCoroutine(fade());
        }

        Reaccionar();
    }


    WaitForSeconds ws = new WaitForSeconds(3);
    public bool corroutinebool = true;
    int rotateop;
    int moveop;

    public IEnumerator fade()
    {
        corroutinebool = false;
        yield return ws;
        moveop = Random.Range(0,4);
        rotateop = Random.Range(0,2);
        Actions = (Acciones)Random.Range(0,3);
        corroutinebool = true;  
    }


}


