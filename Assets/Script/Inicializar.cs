using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializar : MonoBehaviour
{
    //inicializar utiliza un minValue 
    public static int minValue;
    public static float speed;
	void Awake()
    {
        minValue = Random.Range(5, 16);
        speed = Random.Range(5, 16);
        gameObject.AddComponent<GameManager>();
    }
}
