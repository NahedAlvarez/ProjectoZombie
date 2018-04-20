using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc;
namespace Npc
{
    namespace Ally
    {

        public class Citizen : Npcs
        {
            public CitizenInfo ci;

            void Start()
            {
                ci.age = Random.Range(15, 100);
                ci.names = (Nombres)Random.Range(0, 20);
                gameObject.name = ci.names.ToString();
            }

            public override Vector3 Avanzar(int dir)
            {
                return base.Avanzar(dir) / ci.age;
            }
            public CitizenInfo SendMensasgeCi()
            {
                return ci;
            }
        }
    }
}