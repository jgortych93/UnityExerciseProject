using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    private Collider2D rigidbody2d;

    private const uint disabilityTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2d = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("HandleCollision");
    }

    private IEnumerator HandleCollision()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        this.rigidbody2d.enabled = false;

        yield return new WaitForSeconds(disabilityTime);

        gameObject.GetComponent<Renderer>().enabled = true;
        this.rigidbody2d.enabled = true;
    }
}
