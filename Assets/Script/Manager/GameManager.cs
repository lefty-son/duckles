using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

<<<<<<< HEAD
    public bool isStart;

=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
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
<<<<<<< HEAD
        isStart = false;
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
        LoseBounces();
	}

    public void LoseBounces(){
        Bounce = 0;
        if(TouchEvent.instance){
            TouchEvent.instance.isJumping = false;
        }
    }

<<<<<<< HEAD
    public void OnRestart(){
        LevelGenerator.instance.OnRestart();
        TouchEvent.instance.OnRestart();
        WaterMovement.instance.OnRestart();
    }

=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
}
