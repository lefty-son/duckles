using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour {
    

    private readonly float yPos = 9.875f;

    public void DoOpen(bool _isLefty){
        
        StartCoroutine(Open(_isLefty));
    }

    IEnumerator Open(bool _isLefty){
        var origin = transform.localPosition;
        var t = 0f;
        while (t < 2f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!_isLefty)
            {
                transform.localPosition = Vector3.Lerp(origin, new Vector3(-6, yPos, 0), t/ 2f) ;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(origin, new Vector3(6, yPos, 0), t / 2f);
            }

        }


    }
}
