using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc;
using UnityEngine.UI;
using Npc.Enemy;
namespace Npc
{
    namespace Ally
    {

        public class Citizen : Npcs
        {
            public CitizenInfo ci;

            GameManager gm;
            public GameObject IntansCanvas;


            private void Start()
            {
                gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
                IntansCanvas = Instantiate(gm.canvasZombie, gameObject.transform.position, Quaternion.identity);
                IntansCanvas.transform.SetParent(gameObject.transform);
                IntansCanvas.transform.position = transform.position;
                DisplayModify();
                IntansCanvas.SetActive(false);
                StartCoroutine(fade());
                ci.names = (Nombres)Random.Range(0, 20);
                gameObject.name = ci.names.ToString();
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            }


            public override void Reaccionar()
            {
                Vector3 direc;
                int distMax = 5;
                float distMin = 1.0f;


                foreach (GameObject go in GameManager.npcList)
                {
                    float distanceTarget = Vector3.Distance(transform.position, go.transform.position);
                    if (go.GetComponent<Zombie>())
                    {
                        if (distanceTarget <= distMax)
                        {
                            if (distanceTarget >= distMin)
                            {
                                StopCoroutine(fade());
                                Actions = Acciones.Reaccionar;
                                direc = new Vector3(go.transform.position.x + gameObject.transform.position.x,0, go.transform.position.z + gameObject.transform.position.z);
                                gameObject.transform.position += direc * 100/ botAge.age * Time.deltaTime;
                            }
                        }
                    }
                }
            }
            Text farmerText;
            public void DisplayModify()
            {
                Text[] tx;
                tx = IntansCanvas.transform.Find("ZombieText").GetComponents<Text>();
                IntansCanvas.SetActive(true);
                farmerText = tx[0];
                farmerText.text = "Hola soy " + ci.names.ToString() + " y tengo " + botAge.age + "Años ";
            }

            private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<Player>() && IntansCanvas != null)
                {
                    IntansCanvas.gameObject.SetActive(true);
                }
            }
            private void OnCollisionExit(Collision collision)
            {
                if (collision.gameObject.GetComponent<Player>() && IntansCanvas != null)
                {
                    IntansCanvas.gameObject.SetActive(false);
                }
            }


            public static implicit operator Zombie(Citizen cit)
            {
                Zombie z = cit.gameObject.AddComponent<Zombie>();
                z.botAge.age = cit.botAge.age;
                z.IntansCanvas = cit.IntansCanvas;
                Destroy(cit);
                return z;
            }


        }
    }
}