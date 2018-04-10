using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    readonly int minSpawn ;
    const int MAXSPAWN = 25;


    public GameManager()
    {
        minSpawn = Inicializar.minValue;
    }
    //instancia un tipo de instancia que esta predifinida 
    void Start ()
    {
        
        int typeOfSpawn=-1;


        int rangeOfSpawn = Random.Range(minSpawn, MAXSPAWN);

        for (int i = 0; i<rangeOfSpawn;i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);//Se crea un gameobject 
            go.transform.position = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
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

                    
                    typeOfSpawn = Random.Range(1, 3);
                    break;
            }
        }
    }
}
