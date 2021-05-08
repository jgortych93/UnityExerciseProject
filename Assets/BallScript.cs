using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 1700f;
    public bool isBallInInitialPosition = true;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBallInInitialPosition)
        {
            if (Input.GetMouseButton(0))
            {
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                rigidbody2d.AddForce(transform.up * speed);
                isBallInInitialPosition = false;
            }
        }
    }
}
