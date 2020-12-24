using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallShotHandler : MonoBehaviour
{
    public int CurrentTotalShots = 0;

    public void UpdateShotAmount()
    {
        CurrentTotalShots++;
    }

    public void RegisterShotAmount()
    {
        ScoreManager.Instance.GetLevelScore(CurrentTotalShots);
    }
}
