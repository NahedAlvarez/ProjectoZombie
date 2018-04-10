using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    GameObject go;
    public GustoZombie gz;
    public Gusto gusto;
    public StateZombie sz;
 
    //se le asigna un transform position aleatorio se asigna gameobject y cambia nombre 
    private void Start()
    {   
        go = gameObject;
        go.name = "Zombie";
        //se obtiene un numero aleatorio para darle un color 
        int numColor=Random.Range(0,3);
        switch (numColor)
        {
            case 0:
                go.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 1:
                go.GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case 2:
                go.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
        StartCoroutine("fade");//Se inicia corrutina 
        gusto = (Gusto)Random.Range(0, 5);//se crea un gusto aleatorio haciaendo un cast de int a Gusto
        gz.gustoZombie = gusto;//se asigna gusto al struct
    }
    //Se da movimiento al zombie 
    private void Update()
    {
        if(sz == StateZombie.Moving)
        {
         
            transform.position += Movement(moveli);
        }
        else if(sz == StateZombie.Idle)
        {
 
            transform.position += Vector3.zero;
        }
        else if(sz == StateZombie.Rotate)
        {
            transform.Rotate(RotationZ(roteli) * Time.deltaTime*Random.Range(1000,1500));
        }
  
    }
    //se returna el struct gz   
    public GustoZombie SendMensasge()
    {
        return gz;
    }
    //se crea una variable moveli 
    int moveli;
    int roteli;
    WaitForSeconds ws  = new WaitForSeconds(3);
    IEnumerator fade()
    {
        //se returna cada 5 segundoss 
        yield return ws;
        //Se asgina un estado aleatorio
        sz =(StateZombie) Random.Range(0,3);
        //se cambia el estado moveli
        moveli = Random.Range(0, 4);
        roteli = Random.Range(0, 2);
        StartCoroutine(fade());
    }
    //se asigna los espacios que wse moveran
    int move = 1;
    //sse crea un metodo que retorna un valor de tipo vector 3 y se aplica 
    Vector3 Movement(int dir)
    {
        Vector3 vec = Vector3.zero;
       
        if (dir==0)
        {
            vec.x -= move * Time.deltaTime;
        }
        if (dir==1)
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

    Vector3 RotationZ(int dir)
    {
        Vector3 vec = Vector3.zero;

        if (dir == 0)
        {
            vec.y -= move * Time.deltaTime;
        }
        if (dir == 1)
        {
            vec.y += move * Time.deltaTime;
        }
        return vec;
    }



}
//se crea un enum Gustos 
public enum Gusto
{
    PiernaDerecha,
    PiernaIzquierda,
    BrazoDerecho,
    BrazoIzquierdo,
    Cabeza
}
//se crea un enum para los estados del zombie
public enum StateZombie
{
    Moving,
    Idle,
    Rotate
}
//se crea una struct que contiene los enum de gusto zombie
public struct GustoZombie
{
    public Gusto gustoZombie;
}

