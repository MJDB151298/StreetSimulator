using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Sprite[] spriteArray;                                     //Contains the green, yellow, red lights sprites
    public SpriteRenderer newSprite;
    public List<GameObject> carsStopped = new List<GameObject>();
    public string lightState = "green";
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSprite();
        StartCoroutine(TrafficLights());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSprite(){
        newSprite.sprite = spriteArray[count];
    }

    /**public void OnTriggerStay2D(Collider2D collider){
        if(lightState == "yellow"){
            GameObject car = collider.gameObject;
            float objectSpeed = car.GetComponent<Car>().velocity;
            car.GetComponent<Car>().velocity = objectSpeed * 2;
        }
    }**/


    IEnumerator TrafficLights(){
        while(true){
            if(lightState == "green"){
                yield return new WaitForSeconds(10);
                count++;
                ChangeSprite(); //Turn yellow

                this.lightState = "yellow";
                yield return new WaitForSeconds(2);
                count++;
                ChangeSprite(); //Turn red

                this.lightState = "red";
                yield return new WaitForSeconds(12);
                count = 0;
                ChangeSprite(); //Turn green
                this.lightState = "green";
                StartCoroutine(moveCars()); //Starting the process of moving cars as a coroutine    
            }
            else{
                count = 2;
                ChangeSprite(); //Turn red

                yield return new WaitForSeconds(12);
                count = 0;
                ChangeSprite(); //Turn green
                StartCoroutine(moveCars()); //Starting the process of moving cars as a coroutine

                this.lightState = "green";
                yield return new WaitForSeconds(10);
                count++;
                ChangeSprite(); //Turn yellow
                
                this.lightState = "yellow";
                yield return new WaitForSeconds(2);
                count++;
                this.lightState = "red";
                ChangeSprite();
                    
            }
           
        }
                
    }

    private IEnumerator moveCars(){      
        GameObject street = GameObject.Find("street wall");
        bool canMove = street.GetComponent<StreetScript>().carsInStreet.Count == 0;
        while(!canMove){
            canMove = street.GetComponent<StreetScript>().carsInStreet.Count == 0;
            yield return new WaitForSeconds(0);
        }
        foreach (GameObject car in carsStopped){
            car.GetComponent<Car>().running = true;
        }
        carsStopped.Clear();
        yield return new WaitForSeconds(0);
    }
    
}
