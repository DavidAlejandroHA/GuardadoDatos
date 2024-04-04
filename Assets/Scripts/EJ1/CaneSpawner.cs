using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaneSpawner : MonoBehaviour
{

    public static CaneSpawner Instance { get; private set; }
    public GameObject candy;
    public GameObject plano;
    public float spawnInterval = 3.0f;
    public float planeYPosition = 0f; // Y position of the plane
    Vector3 planeSize;
    Vector3 planePosition;
    

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            planeSize = plano.GetComponent<MeshRenderer>().bounds.size; ;
            planePosition = plano.transform.position;
            CrearUnCaramelito();
            Instance = this;
        }
    }
    
    public void CrearUnCaramelito()
    {
        float xPosition = Random.Range(planePosition.x - planeSize.x / 2, planePosition.x + planeSize.x / 2);
        float zPosition = Random.Range(planePosition.z - planeSize.z / 2, planePosition.z + planeSize.z / 2);

        
        Vector3 spawnPosition = new Vector3(xPosition, planePosition.y, zPosition);

        Instantiate(candy, spawnPosition, Quaternion.identity).transform.Rotate(-90,0,0);
    }
}
