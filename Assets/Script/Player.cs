using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.Ally;
using Npc.Enemy;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    readonly float speed;
    Rigidbody rb;

    public Player()
    {
        speed = Inicializar.speed;
    }
  
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().useGravity = false;
        rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
        Camera.main.gameObject.AddComponent<FpsController>();
        Camera.main.transform.SetParent(gameObject.transform);
        Camera.main.transform.position = gameObject.transform.position;
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
        gameObject.AddComponent<MovementFps>();
        gameObject.AddComponent<FpsController>();
    }

    ZombieInfo gz;
    CitizenInfo ci;

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
            print("Mi nombre es: " + ci.names.ToString() + " y tengo " + ci.age.ToString() + " años");
        }
    }
}

