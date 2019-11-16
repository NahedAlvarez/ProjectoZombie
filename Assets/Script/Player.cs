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
    GameObject containerCitizen;
    Text textCitizen;
    CombatManager gm;
    Arma arma;
    string[] mensajes = new string[3];

    public Player()
    {
        speed = Inicializar.speed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //se obtiene el rigidbody
        rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY; //Se frezea los constraints
        containerCitizen = GameObject.FindObjectOfType<Canvas>().transform.Find("Container").gameObject; //FindObjectOfType<Canvas>().transform.Find("Container");//GetComponent<Text>();
        textCitizen = containerCitizen.transform.Find("Message").GetComponent<Text>();
        gm = FindObjectOfType<CombatManager>().GetComponent<CombatManager>();
        arma = FindObjectOfType<Arma>().GetComponent<Arma>();
        mensajes[0] = "tus balas son limitadas no las desperdicies";
        mensajes[1] = "puedes encontrar curaciones en el mapa";
        mensajes[2] = "puedes encontrar  recargas de balas";
    }

    ZombieInfo gz; // se crea una instancia de la estructura zombie
    CitizenInfo ci;  // se crea una instancia de la estructura Cititzen 
    float dist; //Se crea una varible de distancia 
    Text zombie; // se crea un text zombie
    Zombie zb; // se crea un zombie 

    int explorer;

    private void Update()
    {
        //en el foreach  se revizan los objetos de la lista y se revisa la distancai entre los zombies y el player
        foreach (GameObject go in GameManager.npcList)
        {
            if(go != null)
            {
                dist = Vector3.Distance(gameObject.transform.position, go.transform.position);
                if (go.GetComponent<Citizen>())
                {
                    if (dist < 3)
                    {
                        containerCitizen.SetActive(true);
                        textCitizen.text = go.name + ": " + mensajes[explorer];//array text de todos los mensajes;
                    }
                    else if (dist > 5)
                    {
                        containerCitizen.SetActive(false);
                    }   
                }
            }
        }
    }

    public IEnumerator fade()
    {
        explorer = Random.Range(0, 3);
        yield return new WaitForSeconds(5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Municion"))
        {
            arma.Recarga();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Life"))
        {
            gm.Lifen();
            collision.gameObject.SetActive(false);
        }
    }

}


