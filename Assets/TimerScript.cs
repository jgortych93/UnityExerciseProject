using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public GameOverScript gameOverScript;

    private TextMeshProUGUI textMeshPro;

    private float seconds = 59f;    
    private float minutes = 4f;

    // Start is called before the first frame update
    void Start()
    {
        this.textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText("TIME: " + (minutes+1f).ToString("00.") + ":00");
    }

    // Update is called once per frame
    void Update()
    {
        if(!BallScript.isBallInInitialPosition)
        {
            this.seconds -= Time.deltaTime;
            if (this.seconds < 0)
            {
                this.seconds = 59;
                --this.minutes;
            }

            this.UpdateTimer(this.minutes, this.seconds);

            if (this.minutes < 0)
            {
                gameOverScript.Setup();
            }
        }
    }
    
    private void UpdateTimer(float minutes, float seconds)
    {
        textMeshPro.SetText("TIME: " + minutes.ToString("00.") + ":" + seconds.ToString("00."));
    }
}
