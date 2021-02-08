using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button slowButton;
    public Button normalButton;
    public Button fastButton;


    // Start is called before the first frame update
    void Start()
    {
        normalButton.GetComponent<Image>().color = Color.green;
        slowButton.onClick.AddListener(setSlowVelocity);
        normalButton.onClick.AddListener(setNormalVelocity);
        fastButton.onClick.AddListener(setFastVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Once you change the speed settings, cars that have already spawned and new cars will change their speed accordingly

    private void setSlowVelocity(){
        GameObject.Find("GameObject").GetComponent<SpawnCars>().carVelocity = 2f;
        foreach (GameObject car in GameObject.FindGameObjectsWithTag("Car"))
            car.GetComponent<Car>().velocity = 2f;
        slowButton.GetComponent<Image>().color = Color.green;
        normalButton.GetComponent<Image>().color = Color.white;
        fastButton.GetComponent<Image>().color = Color.white;
    }

    private void setNormalVelocity(){
        GameObject.Find("GameObject").GetComponent<SpawnCars>().carVelocity = 4f;
        foreach (GameObject car in GameObject.FindGameObjectsWithTag("Car"))
            car.GetComponent<Car>().velocity = 4f;
        slowButton.GetComponent<Image>().color = Color.white;
        normalButton.GetComponent<Image>().color = Color.green;
        fastButton.GetComponent<Image>().color = Color.white;
    }

    private void setFastVelocity(){
        GameObject.Find("GameObject").GetComponent<SpawnCars>().carVelocity = 6f;
        foreach (GameObject car in GameObject.FindGameObjectsWithTag("Car"))
            car.GetComponent<Car>().velocity = 6f;
        slowButton.GetComponent<Image>().color = Color.white;
        normalButton.GetComponent<Image>().color = Color.white;
        fastButton.GetComponent<Image>().color = Color.green;
    }
}
