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
    public int _totalScore;
    public int _currentScenePar = -1;

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

    private void SetupLevel()
    {
        ScoreManager.Instance._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _currentScenePar = _parList[_currentSceneIndex];
    }

    public void GetLevelScore(int shotAmount)
    {
        _currentScore = shotAmount - ScoreManager.Instance._currentScenePar;
        _totalScore += _currentScore;
        if (_currentScore > _currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", _currentScore);
            _currentHighScore = _currentScore;
        }
    }
}
