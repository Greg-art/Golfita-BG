using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay = default;
    [SerializeField] private TextMeshProUGUI _parDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotsDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotNameDisplay = default;
    [SerializeField] private Image imagem = default;
    [SerializeField] private GolfBallShotHandler _shotHandler = default;


    void Start()
    {

        _scoreDisplay.SetText($"Pontuação Total: {ScoreManager.Instance._totalScore}");
        _parDisplay.SetText($"Par: {ScoreManager.Instance._currentScenePar}");
        if (_shotHandler != null)
        {
            _shotsDisplay.SetText($"Tacadas: {_shotHandler.CurrentTotalShots}");
        }

        _shotNameDisplay.SetText($"ALBATROZ");


        //PlayerPrefs.SetInt("points", _currentScore);
    }

    public void UpdateDisplayedText()
    {
        _scoreDisplay.SetText($"Pontuação Total: 0");
        _shotsDisplay.SetText($"Tacadas: 0");
        _shotNameDisplay.SetText($"ALBATROZ");
    }
}
