using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharEffect : MonoBehaviour {

    private Animator _ani;


    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }


    [SerializeField]
    private GameObject[] _hitEffect;
    [SerializeField]
    private Transform _weapon;

    public void AttackEffect()
    {
        GameObject effect = Instantiate(_hitEffect[0], _weapon.position, Quaternion.identity) as GameObject;

        effect.transform.localPosition = _weapon.position + new Vector3(0.0f, 3.0f, 0.0f);

        Destroy(effect, 0.8f);

        //Debug.Log("공격");
    }

    public void AttackEffect2()
    {
        GameObject effect = Instantiate(_hitEffect[1], _weapon.position, Quaternion.identity) as GameObject;

        effect.transform.localPosition = _weapon.position + new Vector3(0.0f, 3.0f, 0.0f);

        Destroy(effect, 0.8f);
    }
}
