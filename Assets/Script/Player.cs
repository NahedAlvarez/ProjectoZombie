using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.Ally;
using Npc.Enemy;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    readonly public float speed;
    Rigidbody rb;
    Text textZombie;
    


    public Player()
    {
        speed = Inicializar.speed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //se obtiene el rigidbody
        rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition; //Se frezea los constraints
        Camera.main.gameObject.AddComponent<FpsController>();//se añade el FPS controller components
        Camera.main.transform.SetParent(gameObject.transform);
        Camera.main.transform.position = gameObject.transform.position;
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
        gameObject.AddComponent<MovementFps>();
        gameObject.AddComponent<FpsController>();
    }

    ZombieInfo gz; // se crea una instancia de la estructura zombie
    CitizenInfo ci;  // se crea una instancia de la estructura Cititzen 
    float distZombie; //Se crea una varible de distancia 
    Text zombie; // se crea un text zombie
    Zombie zb; // se crea un zombie 
    
    private void Update()
    {
        //en el foreach  se revizan los objetos de la lista y se revisa la distancai entre los zombies y el player
        foreach (GameObject go in GameManager.npcList)
        { 
            if (go.GetComponent<Zombie>())
            {
                zb = go.GetComponent<Zombie>();
                distZombie = Vector3.Distance(gameObject.transform.position, go.transform.position);
                if (distZombie < 5)
                {
                    zb.DisplayWrite(true);
                }
                else if (distZombie > 5)
                {
                    zb.DisplayWrite(false);
                }
            }
        }
    }
}


