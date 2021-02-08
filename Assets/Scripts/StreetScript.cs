using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScript : MonoBehaviour
{
    public List<GameObject> carsInStreet = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider){
        GameObject car = collider.gameObject;
        carsInStreet.Add(car);
       // Debug.Log(carsInStreet.Count);
    }

    public void OnTriggerExit2D(Collider2D collider){
        GameObject car = collider.gameObject;
        carsInStreet.Remove(car);
       // Debug.Log(carsInStreet.Count);
    }
}
