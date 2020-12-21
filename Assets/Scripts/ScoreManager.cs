using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int[] _parList; //inicialmente com 4

    private int _currentScore;
    private int _totalScore;
    private int _currentTotalShots = 0;
    private int _currentSceneIndex;
    //associar par com build index
    private int _currentScenePar = -1;

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

        //código pra resgatar playerprefs

        // pegar pares
    }

    public void UpdateShotAmount()
    {
        _currentTotalShots++;
    }
}
