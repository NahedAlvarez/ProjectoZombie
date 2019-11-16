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
    public Text textVampireNum;
    public Text sucess;
    public Text textZombie;
    static public List<GameObject> npcList = new List<GameObject>();
    public static GameManager gm;
    public GameObject[] gos;

    // se toman de la escena los text para los contadores 
    void Awake()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        textFarmerNum = canvas.transform.Find("FarmerTextCount").GetComponent<Text>();
        textZombieNum = canvas.transform.Find("ZombieTextCount").GetComponent<Text>();
        textVampireNum =canvas.transform.Find("VampiroTextCount").GetComponent<Text>(); 
    }

    void Start ()
    {


      //se crea un for para las intancias 
        int typeOfSpawn= -1;
        int rangeOfSpawn = Random.Range(new MinValue().minValue, MAXSPAWN);

        for (int i = 0; i<rangeOfSpawn;i++)
        {
            GameObject go;
            switch (typeOfSpawn)
            {
               
                case 1:
                    int r = Random.Range(1,3);
                    if (r==1)
                    {
                        go = Instantiate(gos[2], new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    }
                    else
                    {
                        go = Instantiate(gos[3], new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    }
                    typeOfSpawn = Random.Range(1, 3);
                    break;
                case 2:

                    go = Instantiate(gos[0], new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    typeOfSpawn = Random.Range(1, 3);
                    break;
                default:

                    typeOfSpawn = Random.Range(1, 3);
                    go = Instantiate(gos[1], new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    typeOfSpawn = Random.Range(1, 3);
                    break;
            }
          
                //se añaden en la lista todas las intancias 
                npcList.Add(go);
        }
    }
   //se crean dos variables de tipo int 
 
    int countFarmer;
    int countZombie;
    int countVampire;
    void Update()
    {
        //se inicializan en 0 y se suman  los componentes de zombie y cit 
        countFarmer = 0;
        countZombie = 0;
        countVampire = 0;
        foreach (GameObject go in npcList)
        {
           if(go != null)
            {
                if (go.GetComponent<Citizen>() != null)
                {
                    countFarmer++;
                }
                if (go.GetComponent<Zombie>())
                {
                    countZombie++;
                }
                if (go.GetComponent<Vampire>())
                {
                    countVampire++;
                }
            }
        }
        if (countVampire == 0 && countZombie == 0 && countFarmer != 0)
        {
            sucess.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        //se modifican los textos 
        textFarmerNum.text = "Quedan "+ countFarmer + " ciudadanos sanos";
         textZombieNum.text = "Quedan "+ countZombie + " zombies ";
         textVampireNum.text = "Quedan " + countVampire + " vampiros ";
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