using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    public AudioSource hitSound;

    private Collider2D rigidbody2d;
    private Renderer objectRenderer;

    private const uint disabilityTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2d = gameObject.GetComponent<Collider2D>();
        this.objectRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitSound.Play();
        ++ScoreScript.Score;
        StartCoroutine("HandleCollision");
    }

    private IEnumerator HandleCollision()
    {
        this.objectRenderer.enabled = false;
        this.rigidbody2d.enabled = false;

        yield return new WaitForSeconds(disabilityTime);

        this.objectRenderer.enabled = true;
        this.rigidbody2d.enabled = true;
    }
}
