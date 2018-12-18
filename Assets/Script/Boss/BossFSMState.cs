using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossFSMManager))]
public class BossFSMState : MonoBehaviour {

    protected BossFSMManager m_manager;

    static bool phase1;
    static bool phase2;

    private void Awake()
    {
        phase1 = false;
        phase2 = false;
        m_manager = GetComponent<BossFSMManager>();
    }

    public virtual void BeginState(){}
    public virtual void EndState(){}

    protected virtual void Update()
    {
        if(GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            if(m_manager.PlayerTransform == null)
            {
                m_manager.SetState(BossState.IDLE);
            }
        }
    }
}
