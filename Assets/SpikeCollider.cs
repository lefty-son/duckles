using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        UIManager.instance.OnGameOver();
    }

    public void OnNotify(){
        gameObject.SetActive(false);
        var r = Random.Range(0, 3);
        if(r == 0){
            gameObject.SetActive(true);
        }
        else {
            return;
        }
    }
}
