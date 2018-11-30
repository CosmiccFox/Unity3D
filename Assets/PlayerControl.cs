using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float forwardSpeed = 10;
    public float sideSpeed = 5;
    public float jumpForce = 5;
    public float rotateSpeed = 5;
    public Weapon weapon;

    
    public int jumpCount = 0;
    public int maxJumps = 2;

    //private bool isGrounded;

    private Rigidbody rB;

	// Use this for initialization
	void Start ()
    {
        rB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        Jump();
        Rotate();
        Shoot();
	}

    private void FixedUpdate()
    {
        //Move();
    }

    void Move()
    {
        //get horizontal movement and add to position
        //get vertiacal movement and add that to position
        Vector3 horizontal = Input.GetAxis("Horizontal") * sideSpeed * transform.right * Time.deltaTime;
        Vector3 forward = Input.GetAxis("Vertical") * forwardSpeed * transform.forward * Time.deltaTime;

        //rB.AddForce(horizontal + forward);
        transform.position += horizontal + forward;

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            //isGrounded = false;
            rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    void Rotate()
    {
        float deltaRotate = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        Vector3 newLookAtDirection = transform.forward + deltaRotate * transform.right;
        Vector3 newLookAtPoint = transform.position + newLookAtDirection;
        transform.LookAt(newLookAtPoint);
    }

    void Shoot()
    {
        weapon.Fire(Input.GetButtonDown("Fire1"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //isGrounded = true;
            jumpCount = 0;
        }
    }
}
