using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControll : MonoBehaviour
{
    public float speed = 10.0f;
    public bool isCursorVisible = false;

    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;

    private BallScript ballScript;

    private const float LOCAL_SPACE_MID_BOUNDARY = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = isCursorVisible;
        Cursor.lockState = CursorLockMode.Confined;

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2

        ballScript = GameObject.Find("Ball").GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballScript.isBallInInitialPosition)
        {
            Vector3 position = transform.position;
            float translation = Input.GetAxis("Mouse X") * speed;

            float minXPosition = ((screenBounds.x * -1) + objectWidth);
            float maxXPosition = (screenBounds.x - objectWidth);

            if (transform.position.x + translation < minXPosition)
                position.x = minXPosition;
            else if (position.x + translation > maxXPosition)
                position.x = maxXPosition;
            else
                position.x += translation;
            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var direction = transform.InverseTransformPoint(collision.transform.position);
        Debug.Log("HIT. Contact point: " + direction);

        if(direction.x > LOCAL_SPACE_MID_BOUNDARY)
        {
            ballScript.BounceBallRight();
        }
        else if(direction.x < (-1 * LOCAL_SPACE_MID_BOUNDARY))
        {
            ballScript.BounceBallLeft();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }
}
