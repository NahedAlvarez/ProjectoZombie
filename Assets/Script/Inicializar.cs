using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicializar : MonoBehaviour
{

    public static float speed;
   

    void Awake()
    {
        
        speed = Random.Range(5, 16);
      //  gameObject.AddComponent<GameManager>();
    }

}