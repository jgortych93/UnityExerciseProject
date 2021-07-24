using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        Cursor.visible = true;
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
