using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GolfBallShotHandler>() != null)
        {
            GolfBallShotHandler shotHandler = other.GetComponent<GolfBallShotHandler>();
            shotHandler.RegisterShotAmount();
        }
    }
}
