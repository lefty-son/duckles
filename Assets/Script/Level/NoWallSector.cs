using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWallSector : MonoBehaviour {
    private bool isLefty;
    public PlatSizer upperPlat, middlePlat, lowerPlat;
    public Star upperStar, lowerStar;
    public SpikeCollider upperSpike, lowerSpike;
    public Roof roof;
    public Key key;

    public void OnNotify(){
        var r = Random.Range(0, 2);
        if(r == 0){
            isLefty = true;
            upperPlat.OnNotify(PlatSizer.SIDE.LEFT);
            middlePlat.OnNotify(PlatSizer.SIDE.RIGHT);
            lowerPlat.OnNotify(PlatSizer.SIDE.LEFT);
        }
        else{
            isLefty = false;
            upperPlat.OnNotify(PlatSizer.SIDE.RIGHT);
            middlePlat.OnNotify(PlatSizer.SIDE.LEFT);
            lowerPlat.OnNotify(PlatSizer.SIDE.RIGHT);
        }
        upperStar.OnNotify();
        lowerStar.OnNotify();
        upperSpike.OnNotify();
        lowerSpike.OnNotify();
        key.OnNotifty();
    }

    public void OpenRoof(){
        roof.DoOpen(isLefty);
    }
}
