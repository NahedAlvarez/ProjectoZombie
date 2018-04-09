using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]//utilizamos Require component para colocar un rb automaticamente
public class Player : MonoBehaviour
{
    float speed;
    Rigidbody rb;

    //inicializamos la velocidad del personaje y le damos una posicion al player
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().useGravity = false;
        rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        speed = Random.Range(10, 15);
    }

    

    //se crean variables para conener los structs
    GustoZombie gz;
    CitizenInfo ci;

    //cuando collisiona verifica el componente respectivo y trae los structs para imprimirlos
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            gz.gustoZombie = collision.gameObject.GetComponent<Zombie>().gz.gustoZombie;
            print("Warrrr quiero comer " + gz.gustoZombie.ToString());
        }
        if (collision.gameObject.GetComponent<Citizen>())
        {
            ci = collision.gameObject.GetComponent<Citizen>().ci;
            print("Soy un aldeano mi nombre es: " + ci.names.ToString() + " y tengo " + ci.age.ToString() + " años");
        }
    }
}

