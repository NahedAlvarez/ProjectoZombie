using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.Ally;
using UnityEngine.UI;
namespace Npc
{
    namespace Enemy
    {
        public class Zombie : Npcs
        {
            public GameObject go;
            public ZombieInfo gz;
            public Gusto gusto;
            public GameObject playerObject;
            public bool convert = false;
            GameManager gm;
            public  GameObject IntansCanvas;
            Rigidbody rb;

            private void Start()
            {
                gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
                rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                go = gameObject;
                go.name = "Zombie";
                int numColor = Random.Range(0,3);
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
                gusto = (Gusto)Random.Range(0, 5);
                gz.gustoZombie = gusto;
            }
         
            private void OnCollisionEnter(Collision collision)
            {
                // verificamos que sea el citizen Citizen se convierte le agrega el componente zombie  y se le dice que es convertido 
                if (collision.gameObject.GetComponent<Citizen>())
                {
                    Citizen cit = collision.gameObject.GetComponent<Citizen>();
                    Zombie z = (Zombie)cit;
                    z.convert = true;
                }
            }
        }
    }
}
