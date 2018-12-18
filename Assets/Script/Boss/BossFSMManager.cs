using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossState
{
    IDLE = 0,
    RUN,
    ATTACK,
    ATTACK2,
    DEAD
}

[RequireComponent(typeof(BossStat))]
public class BossFSMManager : MonoBehaviour, IFSMManager
{

    private bool m_isinit = false;

    public BossState startState = BossState.IDLE;
    private Dictionary<BossState, BossFSMState> m_states = new Dictionary<BossState, BossFSMState>();

    [SerializeField]
    private BossState m_currentState;
    public BossState CurrentState
    {
        get
        {
            return m_currentState;
        }
    }

    public BossFSMState CurrentStateComponent
    {
        get { return m_states[m_currentState]; }
    }

    private CharacterController m_cc;
    public CharacterController CC { get { return m_cc; } }

    private CharacterController m_playercc;
    public CharacterController PlayerCC { get { return m_playercc; } }

    private Transform m_playerTransform;
    public Transform PlayerTransform { get { return m_playerTransform; } }

    private Transform m_targetTransform;
    public Transform TargetTransform { get { return m_targetTransform; } }

    private BossStat m_stat;
    public BossStat Stat { get { return m_stat; } }

    private Animator m_anim;
    public Animator Anim { get { return m_anim; } }

    private Camera m_sight;
    public Camera Sight {  get { return m_sight; } }

    public int sightAspect = 3;

    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
        m_stat = GetComponent<BossStat>();
        m_anim = GetComponentInChildren<Animator>();
        m_sight = GetComponentInChildren<Camera>();

        m_playercc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        m_playerTransform = m_playercc.transform;
        m_targetTransform = this.transform;

        BossState[] stateValues = (BossState[])System.Enum.GetValues(typeof(BossState));
        foreach (BossState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Boss" + s.ToString());
            BossFSMState state = (BossFSMState)GetComponent(FSMType);
            if (null == state)
            {
                state = (BossFSMState)gameObject.AddComponent(FSMType);
            }

            m_states.Add(s, state);
            state.enabled = false;
        }

    }

    public void SetState(BossState newState)
    {
        if (m_isinit)
        {
            m_states[m_currentState].enabled = false;
            m_states[m_currentState].EndState();
        }
        m_currentState = newState;
        m_states[m_currentState].BeginState();
        m_states[m_currentState].enabled = true;
        m_anim.SetInteger("CurrentState", (int)m_currentState);
    }

    private void Start()
    {
        SetState(startState);
        m_isinit = true;
    }

    private void OnDrawGizmos()
    {
        if (m_sight != null)
        {
            Gizmos.color = Color.red;
            Matrix4x4 temp = Gizmos.matrix;

            Gizmos.matrix = Matrix4x4.TRS(
                m_sight.transform.position,
                m_sight.transform.rotation,
                Vector3.one
                );

            Gizmos.DrawFrustum(
                m_sight.transform.position,
                m_sight.fieldOfView,
                m_sight.farClipPlane,
                m_sight.nearClipPlane,
                m_sight.aspect
                );

            Gizmos.matrix = temp;
        }
    }

    public void NotifyTargetKilled()
    {
        SetState(BossState.IDLE);
    }

    public void SetDeadState()
    {
        SetState(BossState.DEAD);
    }
}
