using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatSizer : MonoBehaviour
{
	private readonly float MinSize = 1f;
    private readonly float MaxSize = 4f;
    private float speed;

    public enum SIDE
    {
        LEFT, RIGHT
    }

    public void OnNotify(SIDE side)
    {
        speed = Random.Range(1f, 2f);
        Resize(side);
    }

    private void Resize(SIDE side)
    {
        var position = transform.localPosition;
        var size = Random.Range(MinSize, MaxSize);
        var halfSize = size / 2f;
        transform.localScale = new Vector3(size, 0.2f, 1f);
        if (side == SIDE.LEFT)
        {
            var r = Random.Range(0, 2);
            // Left-padding
            if (r == 0)
            {
                var x = -5f + halfSize;
                position.x = x;
                transform.localPosition = position;
            }
            // Right-padding
            else
            {
                var x = 0 - halfSize;
                position.x = x;
                transform.localPosition = position;
            }

        }
        else if (side == SIDE.RIGHT)
        {
            var r = Random.Range(0, 2);
            // Left-padding
            if (r == 0)
            {
                var x = 0f + halfSize;
                position.x = x;
                transform.localPosition = position;
            }
            // Right-padding
            else
            {
                var x = 5f - halfSize;
                position.x = x;
                transform.localPosition = position;
            }
        }
    }


    void Update()
    {
        if(LevelGenerator.instance._depth == LevelGenerator.DEPTH.B){
            var position = transform.localPosition;
            var size = transform.localScale.x;
            position.x = size * 0.5f + Mathf.PingPong(Time.time * speed, 10f - size) - 5f;
            transform.localPosition = position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player")){
            collision.collider.transform.SetParent(transform);
            GameManager.instance.LoseBounces();
<<<<<<< HEAD
            WaterMovement.instance.DoWaterUp(transform.position);
=======
>>>>>>> 9cd2db4679c1f0701eaf11268efdce583d9b5906
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}