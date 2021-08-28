using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static readonly float MAX_SECONDS = 59f;
    public static readonly float INITIAL_MINUTES = 5f;

    public GameOverScript gameOverScript;

    private TextMeshProUGUI textMeshPro;

    private float _seconds = 0f;    
    private float _minutes = INITIAL_MINUTES;

    public float Seconds
    {
        get => _seconds;
        private set {
            _seconds = value;
        }
    }

    public float Minutes
    {
        get => _minutes;
        private set {
            _minutes = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText("TIME: " + this._minutes.ToString("00.") + ":00");
    }

    // Update is called once per frame
    void Update()
    {
        if(!BallScript.isBallInInitialPosition)
        {
            this._seconds -= Time.deltaTime;
            if (this._seconds < 0)
            {
                this._seconds = MAX_SECONDS;
                --this._minutes;
            }

            this.UpdateTimer(this._minutes, this._seconds);

            if (this._minutes < 0)
            {
                gameOverScript.Setup();
            }
        }
    }
    
    private void UpdateTimer(float minutes, float seconds)
    {
        textMeshPro.SetText("TIME: " + _minutes.ToString("00.") + ":" + _seconds.ToString("00."));
    }
}
