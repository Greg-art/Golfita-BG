using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int[] _parList; //inicialmente com 4

    private int _currentScore;
    private int _totalScore;
    private int _currentHighScore = 0;
    private int _currentSceneIndex;
    public int _currentScenePar = -1;

    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            ScoreManager.Instance._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _currentScenePar = _parList[_currentSceneIndex];
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ScoreManager.Instance._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _currentScenePar = _parList[_currentSceneIndex];
        }

        _currentHighScore = PlayerPrefs.GetInt("highScore", 0);
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
