using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInputManager : MonoBehaviour {

    private Animator _anim;

    private static CharInputManager _instance;
    public static CharInputManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _instance = this;
    }

    private void FixedUpdate()
    {
        MoveAni();
        Attack();
    }

    public float GetHorizontal { get { return Input.GetAxisRaw("Horizontal"); } }
    public float GetVertical { get { return Input.GetAxisRaw("Vertical"); } }

    private void MoveAni()
    {
        if (!(GetHorizontal == 0 && GetVertical == 0))
        {
            _anim.SetInteger("CurrentState", 1);
        }
        else
        {
            _anim.SetInteger("CurrentState", 0);
        }
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _anim.SetInteger("CurrentState", 2);
        }        
    }
}
