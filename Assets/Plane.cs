using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    float angularSpeed = 120f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.eulerAngles.z % 360);

        if (transform.eulerAngles.z > 10f && transform.eulerAngles.z < 45f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 10f);
        }
        if (transform.eulerAngles.z > 315f && transform.eulerAngles.z < 350f ||
            transform.eulerAngles.z < -10f && transform.eulerAngles.z > -45f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 350f);
        }
        if (transform.eulerAngles.x > 10f && transform.eulerAngles.x < 45f)
        {
            transform.eulerAngles = new Vector3(10f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (transform.eulerAngles.x > 315f && transform.eulerAngles.x < 350f ||
            transform.eulerAngles.x < -10f && transform.eulerAngles.x > -45f)
        {
            transform.eulerAngles = new Vector3(350f, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.Y))
        {
            transform.Rotate(Vector3.right * angularSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.H))
        {
            transform.Rotate(Vector3.left * angularSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.forward * angularSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.back * angularSpeed * Time.deltaTime);
        }
    }
}
