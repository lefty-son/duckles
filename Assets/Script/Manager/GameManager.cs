using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    private int bounce;
    public int Bounce {
        get {
            return bounce;
        }
        set {
            bounce = value;
            if(UIManager.instance)
                UIManager.instance.UpdateBounce();
        }
    }


	// Use this for initialization
	void Awake () {
        if (instance == null) instance = this;
        LoseBounces();
	}

    public void LoseBounces(){
        Bounce = 0;
        if(TouchEvent.instance){
            TouchEvent.instance.isJumping = false;
        }
    }

}
