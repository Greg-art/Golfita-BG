using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int[] _parList; //inicialmente com 4
    private int _currentScore;
    private int _currentHighScore = 0;
    private int _currentSceneIndex;

    public string ScoreName;
    public int TotalScore;
    public int CurrentScenePar = -1;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            SetupLevel();
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetupLevel();
        }

        _currentHighScore = PlayerPrefs.GetInt("highScore", 0);
    }

    public void SetupLevel()
    {
        ScoreManager.Instance._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        CurrentScenePar = _parList[_currentSceneIndex];
    }


    public void GetLevelScore(int shotAmount)
    {
        _currentScore = shotAmount - ScoreManager.Instance.CurrentScenePar;
        TotalScore += _currentScore;

        ScoreName = GetScoreName(_currentScore);
    }

    private string GetScoreName(int currentScore)
    {
        switch (currentScore)
        {
            case -2:
                return "Eagle";

            case -1:
                return "Birdie";

            case 0:
                return "Par";

            case 1:
                return "Bogey";

            case 2:
                return "Double Bogey";

            default:
                if (currentScore <= -3)
                {
                    return "Albatross";
                }
                else
                {
                    return "Triple Bogey";
                }
        }
    }

    public void SetHighScore()
    {
        if (TotalScore < _currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", TotalScore);
            _currentHighScore = TotalScore;
        }
    }
}
