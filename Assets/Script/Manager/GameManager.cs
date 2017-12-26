using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool isStart;

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
        isStart = false;
        LoseBounces();
	}

    public void LoseBounces(){
        Bounce = 0;
        if(TouchEvent.instance){
            TouchEvent.instance.isJumping = false;
        }
    }

    public void OnRestart(){
        LevelGenerator.instance.OnRestart();
        TouchEvent.instance.OnRestart();
        WaterMovement.instance.OnRestart();
    }

}
