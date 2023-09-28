using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadNews : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roadLevels;
    private void Start()
    {
        roadLevels[RoadManager.todayRoadIndex].SetActive(true);
        //for (int i = 0; i < roadLevels.Length; ++i)
        //{
        //    if(RoadManager.todayRoadIndex == i)
        //    {

        //    }
        //}
    }

}
