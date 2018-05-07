using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc;
using Npc.Enemy;
namespace Npc
{
    namespace Ally
    {

        public class Citizen : Npcs
        {
            public CitizenInfo ci;


            void Start()
            {
                StartCoroutine(fade());
                ci.names = (Nombres)Random.Range(0, 20);
                gameObject.name = ci.names.ToString();
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            }


            public CitizenInfo SendMensasgeCi()
            {
                return ci;
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



            public static implicit operator Zombie(Citizen cit)
            {
                Zombie z = cit.gameObject.AddComponent<Zombie>();
                z.botAge.age = cit.botAge.age;
                Destroy(cit);
                return z;
            }
        }
    }
}