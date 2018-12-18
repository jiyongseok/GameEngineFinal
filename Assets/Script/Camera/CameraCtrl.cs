using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    [SerializeField]
    private float _zoomMin, _zoomMax;

    [SerializeField]
    private float _zoomSensative;

    private float _curZoom;


    [SerializeField]
    private float _angleMin, _angleMax;

    [SerializeField]
    private float _rotation;

    [SerializeField]
    private Transform _camera, _char;

    private void Awake()
    {
        _curZoom = _camera.localPosition.z;
    }

    private void Update()
    {
        RotateCamera();
        CalcZoom();
    }

    private void RotateCamera()
    {
        Vector3 currentAngle = transform.eulerAngles;

        float moveX = Input.GetAxis("Mouse X");
        //float moveY = Input.GetAxis("Mouse Y");



        currentAngle.y += _rotation * moveX * Time.deltaTime;
        //currentAngle.x += _rotation * moveY * Time.deltaTime;

        transform.eulerAngles = currentAngle;
    }

    private void CalcZoom()
    {
        if (!CameraColCheck())
        {
            float wheel = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(wheel);

            _curZoom = Mathf.Clamp(_curZoom + wheel * _zoomSensative * Time.deltaTime, _zoomMin, _zoomMax);

            Vector3 currentPosition = _camera.localPosition;
            currentPosition.z = _curZoom;

            _camera.localPosition = currentPosition;
        }
    }

    private bool CameraColCheck()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, -transform.forward * -_curZoom, Color.red);

        if (Physics.Raycast(transform.position, -transform.forward, out hit, -_curZoom + 0.5f))
        {
            Vector3 newCameraPoistion = _camera.localPosition;
            newCameraPoistion.z = -Vector3.Distance(transform.position, hit.point) + 1.5f;

            _camera.localPosition = newCameraPoistion;

            return true;
        }

        return false;
    }
}
