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



    void Start()
    {
        UpdateScoreDisplay(ScoreManager.Instance.TotalScore);
        UpdateParDisplay(ScoreManager.Instance.CurrentScenePar);
    }

    public void UpdateShotsDisplay(int shotAmount)
    {
        _shotsDisplay.SetText($"Tacadas: {shotAmount}");
    }

    public void UpdateScoreDisplay(int totalScore)
    {
        _scoreDisplay.SetText($"Pontuação Total: {totalScore}");
    }

    public void UpdateShotNameDisplay(string scoreName)
    {
        _shotNameDisplay.SetText(scoreName);

    }

    public void UpdateParDisplay(int par)
    {
        _parDisplay.SetText($"Par: {par}");
    }
}
