using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private static TextMeshProUGUI textMeshPro;

    private static uint _score;

    public static uint Score
    {
        get => _score;
        set {
            _score = value;
            textMeshPro.SetText("SCORE: " + _score);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
