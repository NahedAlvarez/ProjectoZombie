using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFps : MonoBehaviour {

    //creo una variable publica de velocidad 
    public float speed ;

    void Start()
    {
        speed = Random.Range(10, 15);
    }

    //Creo el metodo movement nuevo por organizacion 
    void Movement()
    {
        //Cuando se precione input W se va a mover hacia adelante sumando el vector forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        //cuando se precione S
        if (Input.GetKey(KeyCode.S))
        {
            //se va a mover hacia atras
          
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
 

        //cuando preciona A se va a mover hacia la derecha 
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
  
        
        //cuando preciona D se va a mover hacia la izquierda
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }


    }



    void Update ()
    {
        //Se llama al metodo Movement


        
            Movement();
            
       
	}
}
