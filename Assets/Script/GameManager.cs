using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject manager;
    //instancia un tipo de instancia que esta predifinida 
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera");
        int typeOfSpawn=-1;
        int rangeOfSpawn = Random.Range(10, 20);

        for (int i = 0; i<rangeOfSpawn;i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);//Se crea un gameobject 
           //swith maneja el tipo de spawn 
            switch (typeOfSpawn)
            {
                case 1:
                    go.AddComponent<Zombie>();
                   typeOfSpawn = Random.Range(1, 3);
                    break;
                case 2:
                    typeOfSpawn = Random.Range(1, 3);
                    go.AddComponent<Citizen>();
                    break;
                default:
                    go.AddComponent<Player>();
                    go.AddComponent<MovementFps>();
                    go.AddComponent<FpsController>();
                    manager.transform.SetParent(go.transform);
                    manager.AddComponent<FpsController>();
                    manager.transform.position = new Vector3(0, 1, 0);
                    typeOfSpawn = Random.Range(1, 3);
                    break;
            }
        }
    }
}
