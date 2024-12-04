using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 5;
    float explosionRadius = 5;
    float explosionStrength = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce*Vector3.up, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
    //  VictimScript victimScript=collision.gameObject.GetComponent<VictimScript>();
        Collider[] allVictims=Physics.OverlapSphere(transform.position+Vector3.down, explosionRadius);
        foreach(Collider collider in allVictims)
        {
            VictimScript newVictim= collider.gameObject.GetComponent<VictimScript>();
            if (newVictim != null)
            {
                newVictim.Bump(2000, transform.position + Vector3.down, explosionRadius);
            }
        }
       //if (victimScript != null)
       // {
       //     victimScript.Bump(2000, transform.position + Vector3.down, explosionRadius);
       //}

            //    if (collision.gameObject.name == "Victim")
            //    {
            //        Rigidbody victimRB = collision.gameObject.GetComponent<Rigidbody>();
            //        if (victimRB != null)
            //        {
            //            victimRB.AddExplosionForce(2000, transform.position + Vector3.down, 5);
            //        }
            //    }

    }
}
