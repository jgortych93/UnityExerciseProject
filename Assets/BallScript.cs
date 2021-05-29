using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 1700f;
    public float leftBounceDegAngle = 170f;
    public float rightBounceDegAngle = 10f;
    public int bounceForce = 500;
    public bool isBallInInitialPosition = true;

    private Rigidbody2D rigidbody2d;

    private readonly float leftBounceRadAngle;
    private readonly float rightBounceRadAngle;

    private BallScript()
    {
        leftBounceRadAngle = leftBounceDegAngle * Mathf.Deg2Rad;
        rightBounceRadAngle = rightBounceDegAngle * Mathf.Deg2Rad;
    }

    //TO DO: unift bounce force and it should probably be done better by changing the position instead of adding the force
    public void BounceBallLeft()
    {
        float xComponent = Mathf.Cos(leftBounceRadAngle) * bounceForce;
        Vector3 forceApplied = new Vector3(xComponent, 0, 0);

        rigidbody2d.AddForce(forceApplied);
    }

    public void BounceBallRight()
    {
        float xComponent = Mathf.Cos(rightBounceRadAngle) * bounceForce;
        Vector3 forceApplied = new Vector3(xComponent, 0, 0);

        rigidbody2d.AddForce(forceApplied);
    }

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
