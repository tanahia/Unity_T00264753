using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    float turningSpeed = 180;   
    float thrustValue =2;
    float gravity = 2;
    Rigidbody rb;
    Vector3 velocity, acceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        //acceleration = Vector3.zero;
        //acceleration += gravity*thrustValue;

        if (Input.GetKey(KeyCode.W))
        {
            // acceleration +=thrustValue* transform.up;
            rb.AddForce(thrustValue * transform.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //If A is pressed Im going to roll left
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Pitch up
            transform.Rotate(Vector3.right, turningSpeed * Time.deltaTime);
        }
        //Roll using mouse
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")*turningSpeed * Time.deltaTime);
        //velocity += acceleration * Time.deltaTime;

        //transform.position+=velocity*Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch");
    }
    

}
