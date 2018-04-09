using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public int age;
    public CitizenInfo ci;
    BoxCollider coll;

    // transform posiiton se pasa aleatoriamente entre 10 y -10 se asignan los datos struct
    void Start ()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
        ci.age = Random.Range(15, 100);
        ci.names = (Nombres)Random.Range(0, 20);
    }
    //returna el struct
    public CitizenInfo SendMensasgeCi()
    {
        return ci;
    }

}
//se crea un enum y nombres
public enum Nombres
{
    Eddy,
    Sergio,
    Nahed,
    dilan,
    sebastian,
    Luis,
    Santiago,
    Abdel,
    Antonio,
    Alexis,
    Jorge,
    Baruk,
    alejandro,
    victor,
    yency,
    Losbsan,
    Mauricio,
    kebin,
    smith,
    Magneto
} 
//se crea un strut Citizen que contiene un age names 
public struct CitizenInfo
{
   public int age;
   public Nombres names;
}