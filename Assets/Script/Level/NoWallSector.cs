using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWallSector : MonoBehaviour {
    public PlatSizer upperPlat, middlePlat, lowerPlat;
    public Star upperStar, lowerStar;
    public void OnNotify(){
        var r = Random.Range(0, 2);
        if(r == 0){
            upperPlat.OnNotify(PlatSizer.SIDE.LEFT);
            middlePlat.OnNotify(PlatSizer.SIDE.RIGHT);
            lowerPlat.OnNotify(PlatSizer.SIDE.LEFT);
        }
        else{
            upperPlat.OnNotify(PlatSizer.SIDE.RIGHT);
            middlePlat.OnNotify(PlatSizer.SIDE.LEFT);
            lowerPlat.OnNotify(PlatSizer.SIDE.RIGHT);
        }
        upperStar.OnNotify();
        lowerStar.OnNotify();
    }
}
