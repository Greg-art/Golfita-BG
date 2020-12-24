using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallShotHandler : MonoBehaviour
{
    private int _currentTotalShots = 0;

    [SerializeField] private Interface _interface = default;

    private void Awake()
    {
        _interface.UpdateShotsDisplay(_currentTotalShots);
    }

    public void UpdateShotAmount()
    {
        _currentTotalShots++;
        _interface.UpdateShotsDisplay(_currentTotalShots);
    }

    public void RegisterShotAmount()
    {
        ScoreManager.Instance.GetLevelScore(_currentTotalShots);
        _interface.UpdateShotNameDisplay(_currentTotalShots);
        _interface.UpdateScoreDisplay(ScoreManager.Instance.TotalScore);
    }
}
