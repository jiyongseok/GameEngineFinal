using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimEvent : MonoBehaviour {

    BossFSMManager m_manager;
    private void Awake()
    {
        m_manager = transform.root.GetComponent<BossFSMManager>();
    }

    void HitCheck()
    {
        BossATTACK attackState = m_manager.CurrentStateComponent as BossATTACK;
        if(null != attackState)
        {
            attackState.AttackCheck();
        }
    }
}
