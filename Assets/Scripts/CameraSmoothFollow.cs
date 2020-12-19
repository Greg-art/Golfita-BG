using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceToTarget = 10.0f;
    public float _cameraHeightAboveTarget = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    [AddComponentMenu("Camera-Control/Smooth Follow")]

    void LateUpdate()
    {
        if (!_target) return;

        // Calculate the current rotation angles
        float wantedRotationAngle = _target.eulerAngles.y;
        float wantedHeight = _target.position.y + _cameraHeightAboveTarget;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = _target.position;
        transform.position -= currentRotation * Vector3.forward * _distanceToTarget;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(_target);
    }
}