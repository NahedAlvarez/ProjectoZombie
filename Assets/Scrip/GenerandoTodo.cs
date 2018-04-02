using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerandoTodo : MonoBehaviour
{

    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera"); //the camera is searched on the scene
        int RangeInstancias = Random.Range(5, 11);//a range is created to control the number of instances
        int typeOfInstance = -1;// A variable of type int is created to control the object that is instantiated

        string[] names = new string[]
        {
            "Stubbs",
            "Rob",
            "White",
            "Danilo",
            "Victor",
            "Alejo",
            "Samuel",
            "Jason",
            "Luis",
            "Lobsan",
            "Sergio",
            "Eddie",
            "Fernando",
            "Dilan",
            "Alberto",
            "Mauricio",
            "David",
            "VejetitaOmg777",
            "Frigo",
            "Nahed"

        };//a Array of type string is created to accumulate names of the citizen

        for (int i = 0; i < RangeInstancias; i++) //created for instantiate number of instances what corresponding  of the number of the RangeInstatiate 
        {
            switch (typeOfInstance)//typeOfInstance is a switch what control the type what instance 
            {
                case 1:
                    Zombie z = new Zombie(Random.Range(1, 4));//you are given an argument of type int to choose a color
                    typeOfInstance = Random.Range(1, 3);//a number from 1 to 2 is randomly drawn to choose an instance type
                    break;
                case 2:
                    int numName = Random.Range(0, 21);//created for choose a number Random of the matriz of the names
                    Farmer farmer = new Farmer(names[numName],Random.Range(15,100));//you are given an argument of type  int choose a name 
                    typeOfInstance = Random.Range(1, 3);
                    break;
                 default:
                    Hero hero = new Hero(mainCamera);//the method of hero have a argument of the type GameObject for Use Camera 
                    typeOfInstance = Random.Range(1, 3);
                    break;
            }

        }  
    }
}
/// 
/// The hero is created, the necessary components are added to move in first person, the camera is delivered in an argument
/// 
class Hero
{   
    GameObject heroMesh;//created heroMesh for to stock GameObject of hero 

    public Hero(GameObject camera)
    {
        heroMesh = GameObject.CreatePrimitive(PrimitiveType.Capsule);//Created primitive of type capsule 
        camera.transform.SetParent(heroMesh.transform);// parent with hero the camera 
        heroMesh.AddComponent<MovementFps>();//Add Fps Movement 
        heroMesh.AddComponent<FpsController>();//Add FpsController
        camera.AddComponent<FpsController>();//Add FpsController
        heroMesh.transform.position = new Vector3(0, 1, 0);//position is for initialize in the terrain 
        camera.transform.position = new Vector3(0, 1, 0);//the camera position is in the part top of the player
        heroMesh.name = "Hero";//changed name of the capsule of hero
    }
}
/// 
/// Farmer is a same citizen in my mind The citizen need a name and age the age is assigned for ramdom.Range in the class
/// 
class Farmer
{
    GameObject farmerMesh;//container for GameObject primitive
    string nameFarmer;//container Name
    int ageFarmer;//Age is assigned For Random.Range 

    public Farmer(string name,int age)//Argument name is choose in Manager
    {
        farmerMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);//created primitive cube
        farmerMesh.transform.position = new Vector3(Random.Range(-115,356), 1, Random.Range(-140, 321));//position is Random in range of the terrain 
        ageFarmer = age;
        Debug.Log(NameAndAge(name));//Print name of the funtion NameAndAge what return a string 
        farmerMesh.name = NameAndAge(name);//nameIs assigned of the GameObject 
        farmerMesh.GetComponent<Renderer>().material.color = Color.yellow;//Yellow color is assigned
    }
    public string NameAndAge(string name)//Argument of type is string and return string with text in the console
    {
        return "Hi i'am " + name + " and I'am  " + ageFarmer + " years old.";
    }
}

class Zombie
{
    GameObject zombieMesh;//container GameObject primitive 
    int colorPick;//Int contain number of the color what use for choose a color for zombie ins the Swith 

    public Zombie(int colorRange)//Argument for color pick 
    {
        colorPick = colorRange;// color pick is equals with colorRange
        zombieMesh = GameObject.CreatePrimitive(PrimitiveType.Capsule);//created primitive
        //swith for chose color 
        switch (colorPick)
        {
            case 1:
                zombieMesh.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);//set color change color of the primitive at the color assigned

                break;
            case 2:
                zombieMesh.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                break;
            case 3:
                zombieMesh.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
        }

        zombieMesh.transform.position = new Vector3(Random.Range(-115, 356), 1, Random.Range(-140, 321));//zombieMesh position is assigned for the Terrain 
        Debug.Log(PrintZombieColor(zombieMesh.GetComponent<Renderer>().material.color));
        zombieMesh.name = PrintZombieColor(zombieMesh.GetComponent<Renderer>().material.color);

    }

    string nameColor;
    string PrintZombieColor(Color go)  //color Go is a color for the zombie generate 
    {

        if (go == Color.magenta) // compare color assigned with color for Print the color 
        {
            nameColor = "magenta";
        }
        if (go == Color.cyan)
        {
            nameColor = "cyan";
        }
        if (go == Color.green)
        {
            nameColor = "green";
        }


        return "i'm a zombie of the color " + nameColor; //return string with color name 
    }


}



