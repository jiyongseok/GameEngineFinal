using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : MonoBehaviour
{
    [SerializeField]
    GameObject m_fireball;

    [SerializeField]
    Transform m_pos;

    [SerializeField]
    private float m_speed;

    Vector3 m_dir;

    public void Fireball()
    {
        m_dir = new Vector3(m_pos.position.x - transform.position.x, 0, m_pos.position.z - transform.position.z).normalized;
        m_fireball = Instantiate(m_fireball as GameObject , m_pos.transform.position, m_pos.transform.rotation);
        Destroy(m_fireball, 3f);
    }

    private void Update()
    {
        if(m_fireball != null)
        {
            m_fireball.transform.position += m_dir * m_speed * Time.deltaTime;
        }
    }

}
