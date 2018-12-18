using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATTACK2 : BossFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        GameLib.RotateFromTo(this.transform, m_manager.PlayerTransform);
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(m_manager.PlayerTransform.position, transform.position) >= m_manager.Stat.AttackRange)
        {
            m_manager.SetState(BossState.IDLE);
            return;
        }
    }

    public void AttackCheck()
    {
        GameLib.AttackCheck(this.transform, m_manager.PlayerTransform);
    }
}
