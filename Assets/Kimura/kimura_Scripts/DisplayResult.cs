using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    //ゴール処理について
    [SerializeField] Transform now;[SerializeField] Transform goal;

    //実際に表示する道のりオブジェクト
    [SerializeField] Slider nowPos;

    //初めのタイミングでの表示の距離を取得
    float distance;
    private void Start()
    {
        var stuck1 = now.position;
        var stuck2 = goal.position;
        stuck1.y = 0;
        stuck2.y = 0;
        distance = Vector2.Distance(stuck1, stuck2);
    }
    private void Update()
    {
        //常に差分を参照することでゴールまでの距離などを表示する
        var stuck1 = now.position;
        var stuck2 = goal.position;
        stuck1.y = 0;
        stuck2.y = 0;

        float nowdistance = Vector2.Distance(stuck1, stuck2);
        float distanceValue = distance - nowdistance;
        nowPos.value = distanceValue / distance;
    }
}
