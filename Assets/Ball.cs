using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 10f;

    //public GameObject selectedObject;
    Ray ray;
    RaycastHit hitData;
    bool mouseClicking = false;
    float mouseClickingTime = 0f;

    float jumpForce = 5f;

    Vector2 curMousePos;

    Rigidbody rb;

    bool isJumping = false;

    GameObject plane;

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Debug.Log("ATTERRATO");
            isJumping = false;
            rb.velocity = Vector3.zero;
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hole")
        {
            SceneManager.LoadScene("Main");
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        plane = GameObject.FindGameObjectWithTag("plane");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        curMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(curMousePos);
        */

        //Debug.Log("X: " + Input.GetAxis("Mouse X") + " - Y: " + Input.GetAxis("Mouse Y"));

        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Mouse X"), transform.position.y, transform.position.z + Input.GetAxis("Mouse Y"));
        }

        
        if ((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Space)) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
       

        /*
        if (!isJumping)
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetMouseButtonDown(2) && !isJumping)
        {
            rb.velocity = Vector3.up * Time.deltaTime;
            isJumping = true;
        }

        if (Input.GetMouseButtonUp(2) && isJumping) {
            rb.velocity = -Vector3.up;
            isJumping = false;
        }
        */

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        /*
        if (Input.GetMouseButton(0)) {

            if (Input.mousePosition)
            
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + ballSpeed * Time.fixedDeltaTime);
        }
        */

        /*
        if (Physics.Raycast(ray, out hitData)) {
            Debug.Log(hitData.transform.gameObject.name);
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        };
        */

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + ballSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - ballSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector3(transform.position.x - ballSpeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector3(transform.position.x + ballSpeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
        //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
