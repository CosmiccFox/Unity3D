using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

    public Transform player;
    public float rotateSpeed = 1;
    public float maxAngleU = 40;
    public float maxAngleD = 20;

    private float currentAngle = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
	}

    void Rotate()
    {
        float deltaRotate = Input.GetAxis("Mouse Y") * rotateSpeed *  Time.deltaTime;
        currentAngle += deltaRotate;
        currentAngle = Mathf.Clamp(currentAngle, -maxAngleD, maxAngleU);

        float angleInRad = currentAngle * Mathf.Deg2Rad;
        Vector3 newLookAtDirection = Mathf.Cos(angleInRad) * player.forward + Mathf.Sin(angleInRad) * player.up;
        Vector3 newLookAtPoint = transform.position + newLookAtDirection;
        transform.LookAt(newLookAtPoint);
    }


}
