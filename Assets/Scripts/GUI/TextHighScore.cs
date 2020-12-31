using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHighScore : MonoBehaviour
{
    private TextMeshProUGUI _highScoreText;

    private void Awake()
    {
        _highScoreText = GetComponent<TextMeshProUGUI>();
        _highScoreText.SetText($"Recorde: {PlayerPrefs.GetInt("highScore", 0)}");
    }
}
