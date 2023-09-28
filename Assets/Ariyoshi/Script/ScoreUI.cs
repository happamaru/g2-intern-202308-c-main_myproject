using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public bool test;
    public bool test2;

    //public Score scoreScript;
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private int scoreIndex;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUIUpdate();
    }
    private void Update()
    {
        ScoreUIUpdate();
        //???????
        //if (test)
        //{
        //    test = false;
        //    Score.AddScore(6);
        //}
        //if (test2)
        //{
        //    test2 = false;
        //    Score.AddScore(-4);
        //}
    }

    /// <summary>
    /// スコアのUI表示を更新する関数
    /// </summary>
    public void ScoreUIUpdate()
    {
        if(scoreIndex<0) scoreDisplay.text = Score.ReliabilityCalculation();
        else scoreDisplay.text = Score.GetScore(scoreIndex) + "円";
    }
}
