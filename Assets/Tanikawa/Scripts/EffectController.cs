using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{

    public static EffectController Instance => instance;

    public enum EffectName
    {
        ItemDestory,
        Drive,
        Count,
    }


    [SerializeField]
    private ParticleSystem[] particleSystems;

    private static EffectController instance = null;

    private void Awake()
    {
        if (!instance) { instance = this; }
        else { Destroy(this); }
    }

    public void EffectPlay( Vector3 effectPosition,EffectName effectName)
    {
        var particle = Instantiate(particleSystems[(int)effectName]);
        particle.transform.position = effectPosition;
        particle.Play();
    }
}
