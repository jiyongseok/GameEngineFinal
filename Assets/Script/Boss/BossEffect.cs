using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    [SerializeField]
    GameObject _effect;

    private bool _on;

   public void EffectOn()
    {
        StartCoroutine("SetActive");
    }
    
    IEnumerator SetActive()
    {
        _effect.SetActive(true);

        yield return new WaitForSeconds(2f);
        _effect.SetActive(false);
    }

}
