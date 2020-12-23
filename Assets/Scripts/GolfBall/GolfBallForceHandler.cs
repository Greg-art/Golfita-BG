using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallForceHandler : MonoBehaviour
{
    [SerializeField] private float _maxForceX, _maxForceY = 250f;
    [SerializeField] private float _forceMultiplier = 10f;
    private float _forceX, _forceY = 10f;
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
        else if(newX < (_maxForceX * -1))
            _forceX = _maxForceX * -1;

        if (newY > _maxForceY)
            _forceY = _maxForceY;
        else if(newY < (_maxForceY * -1))
            _forceY = _maxForceY;
        
    }

    public void ApplyForce()
    {
        Vector3 forceToApply = new Vector3(_forceX * _forceMultiplier , 0, _forceY * _forceMultiplier);
        _rigidbody.AddForce(forceToApply);
    }
}
