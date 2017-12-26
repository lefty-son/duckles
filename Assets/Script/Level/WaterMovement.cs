using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    
    public static WaterMovement instance;

    public float waterSpeed;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * waterSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sector")){
            LevelGenerator.instance.CheckLevel();
        }
    }
}
