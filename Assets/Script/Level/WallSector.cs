using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSector : MonoBehaviour {
    public PlatSizer upper, middle, lower;
    public void OnNotify()
    {
        var r = Random.Range(0, 2);
        if (r == 0)
        {
            upper.OnNotify(PlatSizer.SIDE.LEFT);
            middle.OnNotify(PlatSizer.SIDE.RIGHT);
            lower.OnNotify(PlatSizer.SIDE.LEFT);
        }
        else
        {
            upper.OnNotify(PlatSizer.SIDE.RIGHT);
            middle.OnNotify(PlatSizer.SIDE.LEFT);
            lower.OnNotify(PlatSizer.SIDE.RIGHT);
        }
    }
}
