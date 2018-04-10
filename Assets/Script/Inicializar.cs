using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializar : MonoBehaviour
{
    public static int minValue;
	void Awake()
    {
        minValue = Random.Range(5, 16);
    }
}
