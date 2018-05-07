using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.Ally;
using Npc.Enemy;

public class GameManager : MonoBehaviour
{
   
    const int MAXSPAWN = 25;
    public Text textZombieNum;
    public Text textFarmerNum;
    public Text textZombie;
    public GameObject canvasZombie;
    static public List<GameObject> npcList = new List<GameObject>();
    public static GameManager gm;

    
    void Awake()
    {
        textZombieNum = FindObjectOfType<Canvas>().transform.Find("ZombieTextCount").GetComponent<Text>();
        textFarmerNum = FindObjectOfType<Canvas>().transform.Find("FarmerTextCount").GetComponent<Text>();
    }

    void Start ()
    {
      
        int typeOfSpawn= -1;
        int rangeOfSpawn = Random.Range(new MinValue().minValue, MAXSPAWN);

        for (int i = 0; i<rangeOfSpawn;i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
           
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
          
      
                npcList.Add(go);
            
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
        textFarmerNum.text = "Quedan "+ countFarmer + " Citizen";
    }
}
public class MinValue
{
    public readonly int minValue;

    public MinValue()
    {
        minValue = Random.Range(5, 16);
    }
}