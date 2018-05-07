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
            GameObject IntansCanvas;


            private void Start()
            {
                gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();      
                IntansCanvas = Instantiate(gm.canvasZombie,gameObject.transform.position,Quaternion.identity);
                IntansCanvas.transform.SetParent(gameObject.transform);
                IntansCanvas.transform.position = transform.position;

                go = gameObject;
                go.name = "Zombie";
                int numColor = Random.Range(0, 3);
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
              
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
            Text zombieMenssage;

            public void DisplayWrite(bool id)
            {

                if (id == true)
                {
                    Text[] tx;
                    tx = IntansCanvas.transform.Find("ZombieText").GetComponents<Text>(); 
                    IntansCanvas.SetActive(true);
                    zombieMenssage = tx[0];
                    zombieMenssage.text = "Arrrrrr quiero comer: " + gz.gustoZombie.ToString();
                   
                }
                
                if(id == false)
                {
                    IntansCanvas.SetActive(false);
                }

            }

            private void OnCollisionEnter(Collision collision)
            {
                if(collision.gameObject.GetComponent<Citizen>())
                {
                    Citizen cit = collision.gameObject.GetComponent<Citizen>();
                    Zombie z = (Zombie)cit;
                    z.convert = true;
                }
            }
        }
    }
}
