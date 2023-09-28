using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager :MonoBehaviour
{
    private  AudioSource[] audioSourceList = new AudioSource[13];
    public  AudioClip[] audioClipList;
    private void Awake()
    {
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
    public void Play(int audioClipIndex)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = audioClipList[audioClipIndex];
        audioSource.Play();
    }
}
