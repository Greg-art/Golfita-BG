using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private Vector3 lastStop;

    void Start(){
        lastStop = new Vector3(0,0,0);
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<GolfBallShotHandler>() != null)
            other.gameObject.GetComponent<Rigidbody>().position = lastStop;

    }

    public void setLastStop(Vector3 position){
        lastStop = new Vector3(position.x,position.y,position.z);
    }

}
