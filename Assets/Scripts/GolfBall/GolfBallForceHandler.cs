using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallForceHandler : MonoBehaviour
{
    [SerializeField] private float _maxForceX, _maxForceY = 250f;
    [SerializeField] private float _forceMultiplier = 10f;
    private float _forceX, _forceY = 10f;
    private Rigidbody _rigidbody;
    private Camera _camera;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    public Vector2 SetForces(float newX, float newY)
    {
        _forceX = newX;
        _forceY = newY;

        if (newX > _maxForceX)
            _forceX = _maxForceX;
        else if (newX < (_maxForceX * -1))
            _forceX = _maxForceX * -1;

        if (newY > _maxForceY)
            _forceY = _maxForceY;
        else if (newY < (_maxForceY * -1))
            _forceY = _maxForceY;

        return new Vector2(_forceX, _forceY);
    }

    public void ApplyForce()
    {
        Vector3 inputForce = new Vector3(_forceX, 0, _forceY);
        Vector3 forceToApply = _camera.transform.TransformDirection(inputForce);
        _rigidbody.AddForce(new Vector3(forceToApply.x * _forceMultiplier, forceToApply.y * 0, forceToApply.z * _forceMultiplier));
    }
}
