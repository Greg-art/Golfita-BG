using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay = default;
    [SerializeField] private TextMeshProUGUI _parDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotsDisplay = default;
    [SerializeField] private TextMeshProUGUI _shotNameDisplay = default;

    void Start()
    {
        int pontos_teste = 11;
        _scoreDisplay.SetText($"Pontuação Total: {pontos_teste}");

        //PlayerPrefs.SetInt("points", _currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
