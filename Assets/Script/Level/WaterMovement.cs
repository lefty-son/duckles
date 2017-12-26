using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    
    public static WaterMovement instance;
    public Transform target;
    private bool watering;
    public float waterSpeed;

    private void Awake()
    {
        if (instance == null) instance = this;
        watering = false;
    }

    private void Update()
    {
        if(GameManager.instance.isStart){
            transform.Translate(Vector3.up * Time.deltaTime * waterSpeed);
        }
    }

    public void OnRestart(){
        StopCoroutine(WaterUp(Vector3.zero));
        transform.position = new Vector3(0, -10, 0);
    }

    public void OnGameOver(){
        watering = false;
        StopCoroutine(WaterUp(Vector3.zero));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sector")){
            other.GetComponent<BoxCollider>().enabled = false;
            LevelGenerator.instance.CheckLevel();
        }
    }

    public void DoWaterUp(Vector3 _position){
        if(!watering){
            StartCoroutine(WaterUp(_position));
        }
    }

 

    IEnumerator WaterUp(Vector3 _position){
        Debug.Log(_position);
        watering = true;
        var position = transform.position;
        var t = 0f;
        while(t < 2f){
            t += Time.deltaTime;
            yield return null;
            if(!watering){
                yield break;
            }
            transform.position = Vector3.Lerp(position, Vector3.up * (_position.y - 5f), t / 2f);
        }
        watering = false;
    }

 
}
