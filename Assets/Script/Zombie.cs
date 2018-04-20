using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


            private void Start()
            {
                go = gameObject;
                edad = Random.Range(15, 100);
                go.name = "Zombie";
                int numColor = Random.Range(0, 3);
                GameObject[] gamesInGame = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
                foreach (GameObject Ago in gamesInGame)
                {
                    Component aComponent = Ago.GetComponent(typeof(Player));
                    if (aComponent != null)
                    {
                        playerObject = Ago;
                    }
                }

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


            public override Vector3 Avanzar(int dir)
            {
                return base.Avanzar(dir)/edad;
                
            }

            Vector3 direc;
            int distZombie = 5;
            float disZombieMin = 1.2f;
            float distancePlayer;

            public override void Agrupar()
            {
                if (distancePlayer < distZombie)
                {
                    StopCoroutine(fade());
                    Reaccionar();
                }
                else if (corroutinebool == false && distancePlayer > distZombie)
                {
                    corroutinebool = true;
                    StartCoroutine(fade());
                }

                base.Agrupar();

            }

            public override void Reaccionar()
            {
                if (distancePlayer > disZombieMin)
                {
                    Actions = Acciones.Reaccionar;
                    direc = Vector3.Normalize(playerObject.transform.position - transform.position);
                    transform.position += direc * 0.1f;
                    transform.LookAt(playerObject.transform);
                    base.corroutinebool = false;
                }
            }

            public ZombieInfo SendMensasge()
            {
                return gz;
            }

        }
        /*
        Vector3 direc;
        bool corroutinebool;
        int distZombie = 5;
        float disZombieMin = 1.2f;
        float distancePlayer;

        private void Update()
        {
            if (sz == StateZombie.Moving)
            {

                transform.position += Movement(moveli);
            }
            else if (sz == StateZombie.Idle)
            {

                transform.position += Vector3.zero;
            }
            else if (sz == StateZombie.Rotate)
            {
                transform.Rotate(RotationZ(roteli) * Time.deltaTime * Random.Range(1000, 1500));
            }

            Vector3 myvector3 = playerObject.transform.position - transform.position;
            float distancePlayer = myvector3.magnitude;


            if (distancePlayer < distZombie)
            {

                StopCoroutine(fade());


                if (distancePlayer > disZombieMin)
                {
                    sz = StateZombie.Pursuing;
                    direc = Vector3.Normalize(playerObject.transform.position - transform.position);
                    transform.position += direc * 0.1f;
                    transform.LookAt(playerObject.transform);
                }

            }
            else if (corroutinebool == false && distancePlayer > distZombie)
            {
                corroutinebool = true;
                StartCoroutine(fade());
            }

        }

      
        }



        */
    }


}
