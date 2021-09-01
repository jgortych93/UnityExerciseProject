using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{   
    public GameObject[] hearths;

    public GameOverScript gameOverScreen;
    public AudioSource looseHealthAudioSource;

    private uint _health;

    public uint Health
    {
        get => _health;
        set {
            _health = value;
            HandleHealthChange();
        }
    }

    HealthScript()
    {
        this._health = 3;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleHealthChange()
    {
        Debug.Log("Health: " + this._health);

        if (this._health >= 3)
        {
            this.hearths[0].SetActive(true);
            this.hearths[1].SetActive(true);
            this.hearths[2].SetActive(true);
        }
        else if (this._health == 2)
        {
            this.looseHealthAudioSource.Play();
            this.hearths[0].SetActive(false);
            this.hearths[1].SetActive(true);
            this.hearths[2].SetActive(true);
        }
        else if (this._health == 1)
        {
            this.looseHealthAudioSource.Play();
            this.hearths[0].SetActive(false);
            this.hearths[1].SetActive(false);
        }
        else
        {
            this.hearths[2].SetActive(false);
            gameOverScreen.Setup();
        }
    }
}
