using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject giftCloneTemplate;
    float turningSpeed = 90;
    float speed;
    float WalkingSpeed = 1;
    float RunningMultiplier = 3;

    Animator johnsAnimator;
    void Start()
    {
      johnsAnimator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        johnsAnimator.SetBool("IsWalking", false);
        johnsAnimator.SetBool("IsRunning", false);
        speed = 0;

        if (Input.GetKey(KeyCode.W))
        {
            speed = WalkingSpeed;
           
            johnsAnimator.SetBool("IsWalking", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed = -WalkingSpeed;
            johnsAnimator.SetBool("IsWalking", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //If A is pressed Im going to roll left
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            johnsAnimator.SetBool("IsWalking", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Pitch up
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
            johnsAnimator.SetBool("IsWalking", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= RunningMultiplier;
            johnsAnimator.SetBool("IsRunning", true);
        }
        transform.position += speed*transform.forward * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(giftCloneTemplate, transform.position, transform.rotation);
        }
    }
}
