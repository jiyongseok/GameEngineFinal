using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRUN : BossFSMState
{
    [SerializeField]
    Slider _slider;   

    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (!GameLib.DetectCharacter(m_manager.Sight, m_manager.PlayerCC))
        {
            m_manager.SetState(BossState.IDLE);
            return;
        }

        if (Vector3.Distance(m_manager.PlayerTransform.position, transform.position) < m_manager.Stat.AttackRange)
        {
            m_manager.SetState(BossState.ATTACK);
            return;
        }
        if(_slider.value <= 50)
        {
            m_manager.SetState(BossState.ATTACK2);
            transform.position = new Vector3(10, 0, 0);
            return;
        }       
        m_manager.CC.CKMove(m_manager.PlayerTransform.position, m_manager.Stat);
    }
}
