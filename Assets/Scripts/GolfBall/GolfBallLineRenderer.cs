using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallLineRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }
    public void StartLine()
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position);
    }

    public void UpdateLinePoint(float forceX, float forceY)
    {
        Vector3 newLinePoint = new Vector3(transform.position.x + forceX, transform.position.y, transform.position.z + forceY);
        _lineRenderer.SetPosition(1, newLinePoint);
    }

    public void SetRendererActive(bool isActive)
    {
        _lineRenderer.enabled = isActive;
    }
}
