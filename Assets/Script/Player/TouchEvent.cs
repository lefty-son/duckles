using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour {

    public static TouchEvent instance;
    
    [SerializeField]
    private float power = 0f;
	private float minVelocity = 2f;
    private Rigidbody rigid;

    public bool isJumping;

    private Vector3 lastFrameVelocity;

    private void Awake()
    {
        if (instance == null) instance = this;
        power = 0f;
        isJumping = false;
        rigid = GetComponent<Rigidbody>();
    }

    public void OnRestart(){
        transform.position = new Vector3(0, 0.4f, 0);
        power = 0f;
        isJumping = false;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10);
            HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touchPosition), touch.phase);
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
            GameManager.instance.Bounce++;
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
        GameManager.instance.isStart = true;
        switch (touchPhase)
        {
            case TouchPhase.Stationary:
                power += Time.deltaTime * 100f;
                break;
            case TouchPhase.Began:
                power = 0f;
                break;
            case TouchPhase.Moved:
                power += Time.deltaTime * 100f;
                break;
            case TouchPhase.Ended:
                if(isJumping){
                    rigid.AddForce((touchPosition - transform.position) * power * 2.5f );
                }
                else {
                    rigid.AddForce((touchPosition - transform.position) * power);
                }
                isJumping = true;
                //rigid.AddForce((touchPosition - transform.position) * power);
                break;
        }
    }
}
