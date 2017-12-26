using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text t_Bounce;
    public GameObject p_GameOver;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateBounce(){
        t_Bounce.text = GameManager.instance.Bounce.ToString();
    }

    public void OnGameOver(){
        p_GameOver.SetActive(true);
        WaterMovement.instance.OnGameOver();
        GameManager.instance.isStart = false;
    }

    public void OnRestart(){
        p_GameOver.SetActive(false);
        GameManager.instance.OnRestart();
    }


}
