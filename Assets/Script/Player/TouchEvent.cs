using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour {
    
    [SerializeField]
    private float power = 0f;
	private float minVelocity = 2f;
    private Rigidbody rigid;

    private Vector3 lastFrameVelocity;

    private void Awake()
    {
        power = 0f;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                HandleTouch(10, Camera.main.ScreenToWorldPoint(mousePosition), TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                HandleTouch(10, Camera.main.ScreenToWorldPoint(mousePosition), TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                HandleTouch(10, Camera.main.ScreenToWorldPoint(mousePosition), TouchPhase.Ended);
            }
        }
        lastFrameVelocity = rigid.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall")){
            Bounce(collision.contacts[0].normal);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        rigid.velocity = direction * Mathf.Max((speed * 0.8f), minVelocity);
    }

    private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                power = 0f;
                break;
            case TouchPhase.Moved:
                power += Time.deltaTime * 100f;
                break;
            case TouchPhase.Ended:
                rigid.AddForce((touchPosition - transform.position) * power);
                break;
        }
    }
}
