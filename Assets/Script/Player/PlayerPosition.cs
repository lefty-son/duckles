using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {
    public static PlayerPosition instance;
    [SerializeField]
    private int level;
    public int Level {
        get
        {
            return level;
        }
        set {
            level = value;
            if(level % 10 == 0) {
                Debug.Log("CHECK!");
            }
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        Level = 1;
    }

    private void Update()
    {
        var y = transform.position.y;
        Check((int)y);
    }

    private void Check(int _y){
        if(level < _y){
            Level = _y;
        }
        
    }
}
