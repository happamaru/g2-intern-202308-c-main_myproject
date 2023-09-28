using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager
{
    /// <summary>
    /// 道の難易度を変える情報を持ったリスト
    /// </summary>
    public static List<int> roadLevel = new List<int>();
    public static int todayRoadIndex;

    public static int TodayRoad()
    {
        todayRoadIndex = Random.Range(0, 3);
        return todayRoadIndex;
    }

}
