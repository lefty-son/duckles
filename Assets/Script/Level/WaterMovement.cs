using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    
    public static WaterMovement instance;
    public Transform target;
    public float waterSpeed;

    private void Awake()
    {
        if (instance == null) instance = this;
        StartCoroutine(WaterUpInterval());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * waterSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sector")){
            other.GetComponent<BoxCollider>().enabled = false;
            LevelGenerator.instance.CheckLevel();
        }
    }

    public void DoWaterUp(){
        StartCoroutine(WaterUp());
    }

    IEnumerator WaterUp(){
        var position = transform.position;
        var t = 0f;
        while(t < 2f){
            t += Time.deltaTime;
            yield return null;
            transform.position = Vector3.Lerp(position, Vector3.up * (target.position.y - 5f), t / 2f);
        }
    }

    IEnumerator WaterUpInterval(){
        while(true){
            yield return new WaitForSeconds(6f);
            DoWaterUp();
        }
    }
}
