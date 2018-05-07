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
                //se busca el gamemanager
                gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
                //se intancia el canvas 
                IntansCanvas = Instantiate(gm.canvasZombie, gameObject.transform.position, Quaternion.identity);
                IntansCanvas.transform.SetParent(gameObject.transform);
                IntansCanvas.transform.position = transform.position;
                //se modifica el text
                DisplayModify();
                IntansCanvas.SetActive(false);
                //se crean los datos 
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
                //para cada uno de los go en la lista npcList se verifica su distancia y componente zombie 
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
            //Se modifica el texto
            public void DisplayModify()
            {
                Text[] tx;
                tx = IntansCanvas.transform.Find("ZombieText").GetComponents<Text>();
                IntansCanvas.SetActive(true);
                farmerText = tx[0];
                farmerText.text = "Hola soy " + ci.names.ToString() + " y tengo " + botAge.age + "Años ";
            }
            //si collisiona con el player se activa el mensaje 
            private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<Player>() && IntansCanvas != null)
                {
                    IntansCanvas.gameObject.SetActive(true);
                }
            }
            //si deja de collisionar se desactiva el mensaje 
            private void OnCollisionExit(Collision collision)
            {
                if (collision.gameObject.GetComponent<Player>() && IntansCanvas != null)
                {
                    IntansCanvas.gameObject.SetActive(false);
                }
            }
            // se hace la conversion zombie citizen y se destruye el elemento citizen

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