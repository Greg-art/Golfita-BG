using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallMouseInput : MonoBehaviour
{

    private Vector2 _initialTouchPosition;
    private Vector2 _lastTouchPosition;
    private Rigidbody rig;
    private GolfBallForceHandler _forceHandler;
    private GolfBallLineRenderer _lineRenderer;
    private GolfBallShotHandler _shotHandler;
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private Interface _interface = default;


    void Start()
    {
        _lineRenderer = GetComponent<GolfBallLineRenderer>();
        _forceHandler = GetComponent<GolfBallForceHandler>();
        _shotHandler = GetComponent<GolfBallShotHandler>();
    }

    void Update()
    {
        _interface.HideVaiDisplay();

        rig = GetComponent<Rigidbody>();
        if ((rig.velocity.x < 0.2f && rig.velocity.x > -0.2f) && (rig.velocity.y < 0.2f && rig.velocity.y > -0.2f) && (rig.velocity.z < 0.2f && rig.velocity.z > -0.2f))
        {
            // rig.constraints = RigidbodyConstraints.FreezePosition;
            rig.velocity = new Vector3(0, 0, 0);
            _interface.ShowVaiDisplay();
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
                Vector2 newForces = _forceHandler.SetForces(newForceX, newForceY);
                // Debug.Log(newForceX);
                // Debug.Log(newForceY);

                _lineRenderer.UpdateLinePoint(newForces);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // rig.constraints = RigidbodyConstraints.None;
                // Debug.Log("none");
                _forceHandler.ApplyForce();
                _lineRenderer.SetRendererActive(false);
                _shotHandler.UpdateShotAmount();
            }
        }
    }
}