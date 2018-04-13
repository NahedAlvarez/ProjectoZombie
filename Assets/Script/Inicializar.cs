using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializar : MonoBehaviour
{
    //inicializar utiliza un minValue 
    public static int minValue;
	void Awake()
    {
        //se le da un  random,range para generar el valor aleatori
        minValue = Random.Range(5, 16);
        //se añade despues el componente para asegurarse de que el gamemanager se ejecute despues del inicialize
        gameObject.AddComponent<GameManager>();
    }
}
