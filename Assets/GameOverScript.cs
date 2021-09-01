using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI bestScoreText;
    public TimerScript timer;
    public AudioSource fanfars;
    public AudioSource looserTheme;

    private static uint bestScore = 0;
    private static float bestScoreSeconds;
    private static float bestScoreMinutes;

    public void Setup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        Cursor.visible = true;

        if (ScoreScript.Score > bestScore)
        {
            this.fanfars.Play();

            bestScore = ScoreScript.Score;
            if ((uint)timer.Seconds != 0)
            {
                bestScoreSeconds = (TimerScript.MAX_SECONDS + 1) - timer.Seconds;
            }
            else
            {
                bestScoreSeconds = 0f;
            }
            bestScoreMinutes = (TimerScript.INITIAL_MINUTES-1) - timer.Minutes;
        }
        else
        {
            this.looserTheme.Play();
        }

        bestScoreText.SetText("BEST SCORE: " + bestScore + "  IN TIME: " + bestScoreMinutes.ToString("00.") + ":" + bestScoreSeconds.ToString("00."));
    }

    public void RestartGame()
    {
        ScoreScript.Score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("GierkaProject");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
