using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStat : MonoBehaviour {

    [SerializeField]
    private float _hp = 100.0f;
    public float Hp { get { return _hp; } }

    [SerializeField]
    private float _moveSpeed = 3.0f;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField]
    private float _turnSpeed = 540.0f;
    public float TurnSpeed { get { return _turnSpeed; } }

    [SerializeField]
    private float _attackRange = 10.0f;
    public float AttackRange { get { return _attackRange; } }

    [SerializeField]
    private Slider m_slider;

    public BossStat lastHitBy = null;

    private void Update()
    {
        _hp = m_slider.value;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            m_slider.value -= 10.0f;            
        }
    }

    public void TakeDamage(BossStat from, float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, 100);
        if (_hp <= 0)
        {
            if (lastHitBy == null)
                lastHitBy = from;

            GetComponent<IFSMManager>().SetDeadState();
            from.GetComponent<IFSMManager>().NotifyTargetKilled();
            Debug.Log(name + " is Killed by " + lastHitBy.name);
        }
    }

    private static float CalcDamage(BossStat from, BossStat to)
    {
        return 50.0f;
    }

    public static void ProcessDamage(BossStat from, BossStat to)
    {
        float finalDamage = CalcDamage(from, to);
        to.TakeDamage(from, finalDamage);
    }
}
