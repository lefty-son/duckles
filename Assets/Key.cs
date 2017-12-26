using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public NoWallSector nws;

    public void OnNotifty(){
        transform.SetParent(null);
        transform.localScale = Vector3.one;
    }

    private void OnCollisionEnter(Collision collision)
    {
        nws.OpenRoof();
        gameObject.SetActive(false);
    }
}
