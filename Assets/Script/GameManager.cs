using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.Ally;
using Npc.Enemy;

public class GameManager : MonoBehaviour
{
    readonly int minSpawn;
    const int MAXSPAWN = 25;
    public Text textZombieNum;
    public Text textFarmerNum;
    public List<GameObject> npcList = new List<GameObject>();



    public GameManager()
    {        
        minSpawn = Inicializar.minValue;
    }
    //instancia un tipo de instancia que esta predifinida 
    void Awake()
    {
        //se buscan los textos directamente 
        textZombieNum = FindObjectOfType<Canvas>().transform.Find("ZombieText").GetComponent<Text>();
        textFarmerNum = FindObjectOfType<Canvas>().transform.Find("FarmerText").GetComponent<Text>();

    }
    void Start ()
    {
        //se diferecian los tipos de spawn entre 1 y 2 y se usa el default para instanciar al hero 
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
                    go.AddComponent<Citizen>();
                    typeOfSpawn = Random.Range(1, 3);
                    break;
                default:
                    go.AddComponent<Player>();
                    typeOfSpawn = Random.Range(1, 3);
                    break;
            }
            //se verifica el componente del go para identificar y añadir a la lista 
            if(go.GetComponent<Zombie>() || go.GetComponent<Citizen>())
            {
                npcList.Add(go);
            }
        }
    }
    //cuentan la cantidad de zombies y aldeanos que hay 
    int countZombie;
    int countFarmer;

    void Update()
    {
        //se inician en 0 cada vez que cambian 
        countZombie = 0;
        countFarmer = 0;
        foreach (GameObject go in npcList)
        {
            if (go.GetComponent<Zombie>() != null)
            {
                countZombie++;
            }
            else if (go.GetComponent<Citizen>() != null)
            {
                countFarmer++;
            }
        }
        textZombieNum.text = "Quedan "+countZombie+" Zombies";
        textFarmerNum.text = "Quedan " + countFarmer + " Citizen";


    }
   




}


