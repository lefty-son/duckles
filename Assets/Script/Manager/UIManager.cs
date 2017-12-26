using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text t_Bounce;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateBounce(){
        t_Bounce.text = GameManager.instance.Bounce.ToString();
    }


}
