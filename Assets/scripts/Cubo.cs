using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public bool isGrounded;
    private bool isSecondJumpAvailable;

    //Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, 1f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, -1f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isSecondJumpAvailable))
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            transform.position += Vector3.up * speed * Time.deltaTime;

            if (!isGrounded && isSecondJumpAvailable)
            {
                isSecondJumpAvailable = false;
            }
        }
        //new Vector3(x, y, z)
        //new Vector3(0f, 0f, 0f)
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter" + collision.gameObject.name);
        isGrounded = true;
        isSecondJumpAvailable = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CollisionExit");
        isGrounded = false;
    }
}
