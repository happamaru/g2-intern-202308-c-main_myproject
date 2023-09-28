using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManagerScript;
    private void Start()
    {
        soundManagerScript.Play(0);
    }
    public void SwitchingActive(GameObject switchObj)
    {
        soundManagerScript.Play(3);
        switchObj.SetActive(!switchObj.activeSelf);
    }
    public void End()
    {
        Application.Quit();
    }
}
