using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader = default;
    private void OnTriggerEnter(Collider other){
        Debug.Log("trigger");
        if (other.GetComponent<GolfBallShotHandler>() != null)
            Debug.Log("trigger2");
            _levelLoader.RestartScene();

    }

}
