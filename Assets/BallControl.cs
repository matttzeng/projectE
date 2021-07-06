using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float startSpeed = 100f;
    public float m_Thrust = 20f;
    public GameObject ground;
    public Camera cam;
    public float speed = 10f;


    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(transform.forward * startSpeed, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
       if(this.m_Rigidbody.velocity.magnitude < 3)
        {
            Vector3 newVelocity = new Vector3(m_Rigidbody.velocity.x, 0.0f, m_Rigidbody.velocity.z);
            m_Rigidbody.AddForce(m_Rigidbody.velocity- newVelocity , ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0) && transform.position.y < ground.transform.position.y+0.7f)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }

        if (Input.GetButtonDown("Jump") && transform.position.y < ground.transform.position.y + 0.7f)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "cube")
        {
            Destroy(collision.gameObject, 0.01f);
            GetCube();
        }
    }

    public void GetCube()
    {
        ground.transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y + 2f, ground.transform.position.z);


        cam.transform.Translate(0, 2f, 0);
    }

}
