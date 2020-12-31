using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallLineRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Camera _camera;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;

        _camera = Camera.main;
    }
    public void StartLine()
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position);
    }

    public void UpdateLinePoint(Vector2 forces)
    {
        Vector3 forceToApply = _camera.transform.TransformDirection(new Vector3(forces.x, 0, forces.y));
        Vector3 newLinePoint = new Vector3(transform.position.x + forceToApply.x, transform.position.y, transform.position.z + forceToApply.z);
        _lineRenderer.SetPosition(1, newLinePoint);
    }

    public void SetRendererActive(bool isActive)
    {
        _lineRenderer.enabled = isActive;
    }
}
