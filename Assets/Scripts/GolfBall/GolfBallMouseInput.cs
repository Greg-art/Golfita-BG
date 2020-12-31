using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallMouseInput : MonoBehaviour
{
    
    private Vector2 _initialTouchPosition;
    private Vector2 _lastTouchPosition;
    private GolfBallForceHandler _forceHandler;
    private GolfBallLineRenderer _lineRenderer;
    private GolfBallShotHandler _shotHandler;
    [SerializeField] private Destroyer _destroyer;
    private Rigidbody rig;

    void Start()
    {
        _lineRenderer = GetComponent<GolfBallLineRenderer>();
        _forceHandler = GetComponent<GolfBallForceHandler>();
        _shotHandler = GetComponent<GolfBallShotHandler>();
    }

    void Update()
    {
        rig = GetComponent<Rigidbody>();
        if ((rig.velocity.x < 0.1f && rig.velocity.x > -0.1f) && (rig.velocity.y < 0.1f && rig.velocity.y > -0.1f) && (rig.velocity.z < 0.1f && rig.velocity.z > -0.1f) )
        {
            _destroyer.setLastStop(GetComponent<Rigidbody>().position); 

            if (Input.GetMouseButtonDown(0))
            {
                _initialTouchPosition = Input.mousePosition;
                _lastTouchPosition = Input.mousePosition;

                _forceHandler.SetForces(0, 0);

                _lineRenderer.StartLine();

            }
            else if (Input.GetMouseButton(0))
            {
                _lastTouchPosition = Input.mousePosition;

                float newForceX = (_initialTouchPosition.x - _lastTouchPosition.x) * 1f;
                float newForceY = (_initialTouchPosition.y - _lastTouchPosition.y) * 1f;
                _forceHandler.SetForces(newForceX, newForceY);
                // Debug.Log(newForceX);
                // Debug.Log(newForceY);

                _lineRenderer.UpdateLinePoint(newForceX, newForceY);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _forceHandler.ApplyForce();
                _lineRenderer.SetRendererActive(false);
                _shotHandler.UpdateShotAmount();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            _lastTouchPosition = Input.mousePosition;

            float newForceX = (_initialTouchPosition.x - _lastTouchPosition.x) * 1f;
            float newForceY = (_initialTouchPosition.y - _lastTouchPosition.y) * 1f;
            _forceHandler.SetForces(newForceX, newForceY);
    }

}
