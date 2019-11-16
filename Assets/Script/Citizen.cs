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
            Rigidbody rb;

            private void Start()
            {
                //se busca el gamemanager
                gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
                rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                //DisplayModify();
                //se crean los datos 
                StartCoroutine(fade());
                ci.names = (Nombres)Random.Range(0, 20);
                gameObject.name = ci.names.ToString();
            }

           
            public override void Reaccionar()
            {
                Vector3 direc;
                int distMax = 5;
                float distMin = 1.0f;
                //para cada uno de los go en la lista npcList se verifica su distancia y componente zombie 
                foreach (GameObject go in GameManager.npcList)
                {
                    if(go != null)
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
                                    direc = Vector3.Normalize(go.transform.position - gameObject.transform.position);
                                    gameObject.transform.position += direc * (-100 / botAge.age) * Time.deltaTime;
                                    transform.LookAt(go.transform);
                                }
                            }
                        }
                    }
                }
            }
          
            public static implicit operator Zombie(Citizen cit)
            {
                Zombie z = cit.gameObject.AddComponent<Zombie>();
                EnemyDamage enem = cit.gameObject.AddComponent<EnemyDamage>();
                z.botAge.age = cit.botAge.age;
                Destroy(cit);
                return z;
            }
        }
    }
}