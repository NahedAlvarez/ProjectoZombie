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

        Debug.Log(minSpawn);

    }
    //instancia un tipo de instancia que esta predifinida 
    void Awake()
    {
        textZombieNum = FindObjectOfType<Canvas>().transform.FindChild("ZombieText").GetComponent<Text>();
        textFarmerNum = FindObjectOfType<Canvas>().transform.FindChild("FarmerText").GetComponent<Text>();

    }
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
                    go.AddComponent<Citizen>();
                    typeOfSpawn = Random.Range(1, 3);
                    break;
                default:
                    go.AddComponent<Player>();
                    typeOfSpawn = Random.Range(1, 3);
                    break;
            }
            if(go.GetComponent<Zombie>() || go.GetComponent<Citizen>())
            {
                npcList.Add(go);
            }
        }
    }
    int countZombie;
    int countFarmer;

    void Update()
    {
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


