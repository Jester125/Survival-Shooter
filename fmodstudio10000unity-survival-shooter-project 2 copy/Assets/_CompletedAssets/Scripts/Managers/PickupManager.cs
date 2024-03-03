using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public Vector3[] spawnPoints = new Vector3[13];
    public GameObject thePickup;

    // Start is called before the first frame update
    void Start()
    {
        
        int spawn = Random.Range(0, 12);
        GameObject.Instantiate(thePickup, spawnPoints[spawn], Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int spawn = Random.Range(0, 12);
        GameObject.Instantiate(thePickup, spawnPoints[spawn], Quaternion.identity);
    }
    
}
