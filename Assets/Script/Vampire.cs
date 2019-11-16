using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.Ally;
namespace Npc
{
    namespace Enemy
    {
        public class Vampire : Npcs
        {
            GameObject go;
            Rigidbody rb;
            private void Start()
            {
                rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                go = gameObject;
                go.name = "vampire";
                go.GetComponent<Renderer>().material.color = Color.gray;
            }
        }
    }
}
