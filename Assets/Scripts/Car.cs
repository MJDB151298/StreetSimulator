using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Vector3 carDirection = Vector3.right;
    public bool running = true;
    public GameObject lightToStop = null;
    public float velocity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.running){
            transform.Translate(carDirection * velocity * Time.deltaTime);
        }
        
    }


    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Remove"){
            Destroy(this.gameObject);
        }

        else if(collider.tag == "Light"){
            GameObject light = collider.gameObject;
            if(light.GetComponent<Lights>().lightState == "red" && this.lightToStop == null){
                this.running = false;
                light.GetComponent<Lights>().carsStopped.Add(gameObject);
            }  
            this.lightToStop = light;    
        }


        else if(collider.tag == "Car"){
            GameObject otherCar = collider.gameObject;
            if(!otherCar.GetComponent<Car>().running){
                this.running = false;
                this.lightToStop = otherCar.GetComponent<Car>().lightToStop;
                this.lightToStop.GetComponent<Lights>().carsStopped.Add(gameObject);
            }
            
        }
    }

    /**void OnTriggerStay2D(Collider2D collider){
        if(collider.tag == "Light"){
            GameObject light = collider.gameObject;
            GameObject street = GameObject.Find("StreetWall");
            if(light.GetComponent<Lights>().lightState == "green" && street.GetComponent<StreetScript>().carsInStreet.Count > 0){
                this.running = false;
                Debug.Log("The light is green and there is cars on the street");
            } 
            else{
                this.running = true;
                Debug.Log("Run you fool");
            }
                
        }
    }**/

    
}
