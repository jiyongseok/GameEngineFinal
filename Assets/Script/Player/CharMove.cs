using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private float _rotSpeed;

    Vector3 forward, right;

    private Vector3 _moveDir;
    private Animator _ani;

    Rigidbody m_rigidbody;

    private void Awake()
    {       
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        float vertical = CharInputManager.Instance.GetVertical;
        float horizontial = CharInputManager.Instance.GetHorizontal;

        Vector3 cameraForward = CameraMove.Instance.Forward;
        cameraForward.y = 0f;
        Vector3 cameraRight = CameraMove.Instance.Right;
        cameraRight.y = 0f;

        Vector3 moveForward = cameraForward.normalized * vertical;
        Vector3 moveRight = cameraRight.normalized * horizontial;

        Vector3 movement = moveForward + moveRight;
        movement.Normalize();

        Rotate(movement);

        movement *= speed;

        m_rigidbody.velocity = movement;
        
    }

    private void Rotate(Vector3 movement)
    {
        if (movement.Equals(Vector3.zero))
            return;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotSpeed);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
