using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text t_Bounce;
<<<<<<< HEAD
    public GameObject p_GameOver;
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateBounce(){
        t_Bounce.text = GameManager.instance.Bounce.ToString();
    }

<<<<<<< HEAD
    public void OnGameOver(){
        p_GameOver.SetActive(true);
        WaterMovement.instance.OnGameOver();
        GameManager.instance.isStart = false;
    }

    public void OnRestart(){
        p_GameOver.SetActive(false);
        GameManager.instance.OnRestart();
    }

=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906

}
