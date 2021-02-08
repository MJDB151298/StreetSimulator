using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{

    public GameObject soap;
    public float carVelocity = 4f;
    private List<string> directions = new List<string> {"Left", "Right", "Up", "Down"};

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCar(){
        string direction = directions[Random.Range(0,4)];
        GameObject car;
        Vector3 carDirection = Vector3.right;
        Vector3 spawnPosition = new Vector3(0,0,0);
        switch (direction)
        {
            case "Left":
                carDirection = Vector3.left;
                spawnPosition = new Vector3(13,0.79f,0);
                break;
            case "Right":
                carDirection = Vector3.right;
                spawnPosition = new Vector3(-13,-0.713f,0);
                break;
            case "Up":
                carDirection = Vector3.up;
                spawnPosition = new Vector3(-1.03f,-7,0);
                break;
            case "Down":
                carDirection = Vector3.down;
                spawnPosition = new Vector3(1.93f,7,0);
                break;
        }
        car = Instantiate(soap, spawnPosition, Quaternion.identity) as GameObject;
        car.GetComponent<Car>().carDirection = carDirection;
        car.GetComponent<Car>().velocity = carVelocity;
    }
}
