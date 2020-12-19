using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacada : MonoBehaviour
{

    [SerializeField] private float _maxForceX, _maxForceY;

    private float _forceX, _forceY;
    private Vector2 _initialTouchPosition;
    private Vector2 _lastTouchPosition;
    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        int currentTouch;
        for (currentTouch = 0; currentTouch < Input.touchCount; currentTouch++)
        {
            Touch touch = Input.GetTouch(currentTouch);
            if (touch.phase == TouchPhase.Began)
            {
                _initialTouchPosition = touch.position;
                _lastTouchPosition = touch.position;
                _forceX = 0;
                _forceY = 0;
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, transform.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                _lastTouchPosition = touch.position;

                _forceX = (_initialTouchPosition.x - _lastTouchPosition.x) * 0.03f;
                _forceY = (_initialTouchPosition.y - _lastTouchPosition.y) * 0.03f;

                if (_forceX > _maxForceX)
                    _forceX = _maxForceX;
                if (_forceY > _maxForceY)
                    _forceY = _maxForceY;

                _lineRenderer.SetPosition(1, new Vector3(transform.position.x + _forceX, transform.position.y, transform.position.z + _forceY));
            }

            if (touch.phase == TouchPhase.Ended)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(2 * _forceX, 0, 2 * _forceY));
                _lineRenderer.enabled = false;
            }
        }
    }
}
