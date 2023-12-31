using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance => instance;

    public enum SEName
    {
        BGM_Start,
        BGM_Throw,
        BGM_Running,
        ClickButton,
        GatanGoton,
        Go,
        ItemColide,
        ItemErase,
        ItemSelect,
        OneCountDown,
        ScoreOpen,
        Throw,
        ToMainButton,
        Truck_Move,
        TruckEnd,

    }

    private static SEManager instance = null;

    private AudioSource[] audioSourceList = new AudioSource[13];


    [SerializeField]
    private AudioClip[] audioClips;
    private void Awake()
    {
        if (!instance) { instance = this; }
        else { Destroy(this); }
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }

        return null; //未使用のAudioSourceは見つかりませんでした
    }
    public void PlaySE(SEName name)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = audioClips[(int)name];
        audioSource.Play();
    }


}
