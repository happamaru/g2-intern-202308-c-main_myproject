using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManagerScript;
    /// <summary>
    ///  シーンを切り替える関数
    /// </summary>
    public void SceneTransition(string targetSceneName)
    {
        soundManagerScript.Play(3);
        SceneManager.LoadScene(targetSceneName);
    }
    public void ResetScore(string targetSceneName)
    {
        Score.playerScore = 0;
        Score.scoreDamages = 0;
        Score.finalScore = 0;
        Score.reliabilityScore = 1;
        SceneTransition(targetSceneName);
    }
}
