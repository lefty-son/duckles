using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {
    
    public static WaterMovement instance;
    public Transform target;
<<<<<<< HEAD
    private bool watering;
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
    public float waterSpeed;

    private void Awake()
    {
        if (instance == null) instance = this;
<<<<<<< HEAD
        watering = false;
=======
        StartCoroutine(WaterUpInterval());
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
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

<<<<<<< HEAD
    public void DoWaterUp(Vector3 _position){
        if(!watering){
            StartCoroutine(WaterUp(_position));
        }
    }

 

    IEnumerator WaterUp(Vector3 _position){
        Debug.Log(_position);
        watering = true;
=======
    public void DoWaterUp(){
        StartCoroutine(WaterUp());
    }

    IEnumerator WaterUp(){
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
        var position = transform.position;
        var t = 0f;
        while(t < 2f){
            t += Time.deltaTime;
            yield return null;
<<<<<<< HEAD
            if(!watering){
                yield break;
            }
            transform.position = Vector3.Lerp(position, Vector3.up * (_position.y - 5f), t / 2f);
        }
        watering = false;
    }

 
=======
            transform.position = Vector3.Lerp(position, Vector3.up * (target.position.y - 5f), t / 2f);
        }
    }

    IEnumerator WaterUpInterval(){
        while(true){
            yield return new WaitForSeconds(6f);
            DoWaterUp();
        }
    }
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
}
