using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    static private CameraMove _instance;
    static public CameraMove Instance { get { return _instance; } }

    [SerializeField]
    private float _maxZoom;

    [SerializeField]
    private float offsetX, offsetY, offsetZ, speed;

    [SerializeField]
    private float _rotation;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform _camera;

    public Vector3 Forward { get { return transform.forward; } }
    public Vector3 Right { get { return transform.right; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        transform.position = player.position;
    }  
}
