using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundEvent : MonoBehaviour {

    [SerializeField]
    AudioClip[] m_clip;

    AudioSource m_source;

    private void Awake()
    {
        m_source = GetComponent<AudioSource>();
    }

    public void RunSound()
    {
        m_source.PlayOneShot(m_clip[0]);
    }

    public void Attack1before()
    {
        m_source.PlayOneShot(m_clip[1]);
    }

    public void Attack1after()
    {
        m_source.PlayOneShot(m_clip[2]);
    }

    public void JumpAttackbefore()
    {
        m_source.PlayOneShot(m_clip[3]);
    }

    public void JumpAttackafter()
    {
        m_source.PlayOneShot(m_clip[4]);
    }
}
