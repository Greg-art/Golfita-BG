using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacada : MonoBehaviour
{

    [SerializeField]private float _maxX, _maxY;
    private float _x, _y;
    private Vector2 _pi;
    private Vector2 _pf;
    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int i;
        for(i = 0; i < Input.touchCount; i++){
            Touch t = Input.GetTouch(i);
            if(t.phase == TouchPhase.Began){
                _pi = t.position;
                _pf = t.position;
                _x = 0;
                _y = 0;
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position);
            } 
            if(t.phase == TouchPhase.Moved){
                _pf = t.position;

                _x = (_pi.x - _pf.x) * 1.0f;
                _y = (_pi.y - _pf.y) * 1.0f;

                if(_x > _maxX)
                    _x = _maxX;
                if(_y > _maxY)
                    _y = _maxY;

                lr.SetPosition(1, new Vector3(transform.position.x + _x, transform.position.y, transform.position.z + _y ));
            }

            if(t.phase == TouchPhase.Ended){
                GetComponent<Rigidbody>().AddForce(new Vector3(2 * _x, 0, 2 * _y));
                lr.enabled = false;
            }

        }
    }
}
