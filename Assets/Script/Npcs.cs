using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcs : MonoBehaviour
{
    public Acciones Actions;
    public int edad;




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
    public virtual Vector3 Avanzar(int dir)
    {
        Vector3 vec = Vector3.zero;

        if (dir == 0)
        {
            vec.x -= move * Time.deltaTime;
        }
        if (dir == 1)
        {
            vec.x += move * Time.deltaTime;
        }
        if (dir == 2)
        {
            vec.z += move * Time.deltaTime;
        }
        if (dir == 3)
        {
            vec.z -= move * Time.deltaTime;
        }
        return vec;
    }


    public virtual void Reaccionar()
    {
        
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


