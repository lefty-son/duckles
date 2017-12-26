using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSector : MonoBehaviour {
    public PlatSizer upperPlat, middlePlat, lowerPlat;
    public Star upperStar, lowerStar;
<<<<<<< HEAD
    public SpikeCollider upperSpike, lowerSpike;
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
    public void OnNotify()
    {
        var r = Random.Range(0, 2);
        if (r == 0)
        {
            upperPlat.OnNotify(PlatSizer.SIDE.LEFT);
            middlePlat.OnNotify(PlatSizer.SIDE.RIGHT);
            lowerPlat.OnNotify(PlatSizer.SIDE.LEFT);
        }
        else
        {
            upperPlat.OnNotify(PlatSizer.SIDE.RIGHT);
            middlePlat.OnNotify(PlatSizer.SIDE.LEFT);
            lowerPlat.OnNotify(PlatSizer.SIDE.RIGHT);
        }
        upperStar.OnNotify();
        lowerStar.OnNotify();
<<<<<<< HEAD
        upperSpike.OnNotify();
        lowerSpike.OnNotify();
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
    }
}
