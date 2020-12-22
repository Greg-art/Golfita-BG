using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallShotHandler : MonoBehaviour
{
    private int _currentTotalShots = 0;

    public void UpdateShotAmount()
    {
        _currentTotalShots++;
    }

    public void RegisterShotAmount()
    {
        ScoreManager.Instance.GetLevelScore(_currentTotalShots);
    }
}
