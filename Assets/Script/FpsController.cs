using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    //se crea una variable publica para acceder a otro tipo de movimiento de la camara 
    public bool inverseMouse;
    //se crea la variable float para guardar la informacion de la posicion en x del mouse
    float xPosition;
    //se crea la variable float para guardar la informacion de la posicion en y del mouse
    float yPosition;
    //angulo minimo para mirar hacia abajo se usa para limitar
    float minAngle;
    //angulo maximo para mirar hacia abajo se usa para limitar
    float maxAngle;
    //contador que se utiliza en el switch
    public int count;


    void Start()
    {
        
        if(gameObject.tag == "MainCamera")
        {
            count = 1;
        }
        else
        {
            count = 2;
        }
    }


    //se crea un metodo MousePosition Que va a operar en el Update por motivo de organizacion 
    public void MousePosition()
     {
        //Se inicia un swicht con la variable count 
        switch (count)
        {
            case 1:
                //la variable xPosition se le  suma la posicion del mouse x definido por defecto en el input
                xPosition += Input.GetAxis("Mouse X");

                //se crea un condicional para cuando se desea invertir la pantalla
                if (inverseMouse)
                {
                    //si es asi se suma el input y
                    yPosition += Input.GetAxis("Mouse Y");
                    //se utiliza la funcion Clamp para limitar la camara en el eje Y
                    yPosition = Mathf.Clamp(yPosition, -45, 45);
                }
                else
                {
                    //si no se le resta 
                    yPosition -= Input.GetAxis("Mouse Y");
                    //se utiliza la funcion Clamp para limitar la camara en el eje Y
                    yPosition = Mathf.Clamp(yPosition, -45, 45);
                }

                //se utiliza eulerAngles para asignarle la rotacion 
                transform.eulerAngles = new Vector3(yPosition, xPosition);

                break;

            case 2:

                //la variable xPosition se le  suma la posicion del mouse x definido por defecto en el input
                xPosition += Input.GetAxis("Mouse X");
                //se utiliza eulerAngles para asignarle la rotacion 
                transform.eulerAngles = new Vector3(0, xPosition);

                break;
        }
   

    }



    void Update ()
    {
        //se llama al metodo creado en cada frame
        MousePosition();
    }

}
