using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    //public bool test;
    //public bool test2;

    public static int playerScore;//?????????
    public static int scoreDamages;//??
    public static int finalScore = -99999;//????????
    public static float reliabilityScore = 1;//信頼度



    /// <summary>
    ///  ????????????????????????????????0????????????0????
    /// </summary>
    /// <param name="add"></param>
    public static void AddScore(float add)
    {
        playerScore += Mathf.FloorToInt(add * reliabilityScore);
        if (playerScore < 0) playerScore = 0;
        Debug.Log(playerScore);
    }
    public static void AddReparation(int add)
    {
        scoreDamages += Mathf.FloorToInt(add * reliabilityScore);
    }
    public static void ScoreCalculation()
    {
        Debug.Log(finalScore);
        Debug.Log(playerScore);
        Debug.Log(scoreDamages);
        finalScore += playerScore - scoreDamages;
    }
    public static string ReliabilityCalculation()
    {
        var evaluation = "エラー";
        if (scoreDamages < 10000 && finalScore>0)
        {
            reliabilityScore = 1 + (1 - scoreDamages/10000);
            evaluation = "満足";
        }
        else
        {
            reliabilityScore = 1;
            evaluation = "不満";
        }
        return evaluation;
    }


    /// <summary>
    /// 引数1でトラック上のスコア、2で損害スコア、3で合計スコアを返す関数。それ以外はー1を返す。
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int GetScore(int index)
    {
        switch (index)
        {
            case 1:
                return playerScore;
            case 2:
                return scoreDamages;
            case 3:
                return finalScore;
            default:
                return -1;
        }
    }
    /// <summary>
    /// ???????
    /// </summary>
    /// <returns></returns>
    public static int GetDebtScore()
    {
        return scoreDamages;
    }
    /// <summary>
    /// ??????????
    /// </summary>
    /// <returns></returns>
    public static int GetSalaryScore()
    {
        return finalScore;
    }
}
