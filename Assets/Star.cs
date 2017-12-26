using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            gameObject.SetActive(false);
        }
    }

    public void OnNotify(){
        gameObject.SetActive(false);
        var r = Random.Range(0, 5);
        if(r != 0){
            return;
        }
        else {
            gameObject.SetActive(true);
        }
    }
}
