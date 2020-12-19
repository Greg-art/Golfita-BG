using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallForceHandler : MonoBehaviour
{
    [SerializeField] private float _maxForceX, _maxForceY;
    private float _forceX, _forceY;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetForces(float newX, float newY)
    {
        _forceX = newX;
        _forceY = newY;

        if (newX > _maxForceX)
            _forceX = _maxForceX;
        if (newY > _maxForceY)
            _forceX = _maxForceY;
    }

    public void ApplyForce()
    {
        Vector3 forceToApply = new Vector3(2 * _forceX, 0, 2 * _forceY);
        _rigidbody.AddForce(forceToApply);
    }
}
