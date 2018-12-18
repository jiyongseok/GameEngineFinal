using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossIDLE : BossFSMState
{
    [SerializeField]
    private Slider _slider;

    public float idleTime = 5.0f;
    private float time = 0.0f;

    public override void BeginState()
    {
        base.BeginState();
        time = 0.0f;
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (m_manager.PlayerTransform)
        {
            if (GameLib.DetectCharacter(m_manager.Sight, m_manager.PlayerCC))
            {                
                m_manager.SetState(BossState.RUN);                
                return;
            }
            if(_slider.value <= 0)
            {
                m_manager.SetState(BossState.DEAD);
            }
        }

        //time += Time.deltaTime;
        //if (time > idleTime)
        //{
        //    m_manager.SetState(BossState.RUN);
        //}

    }
}
