using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingDataBase : MonoBehaviour
{
    [SerializeField]
    private List<int> rankingList;//ランキングを保存するリスト
    [SerializeField]
    private Text[] rankingText;//実際に表示するランキング
    private Canvas canvas;
    public static RankingDataBase instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            canvas = GetComponent<Canvas>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log(instance.rankingList);
        }
        instance.canvas.enabled = true;
        if (Score.finalScore < instance.rankingList[2]) return;
        instance.rankingList.Add(Score.finalScore);//スコアをリストに追加
        instance.rankingList.Sort();
        instance.rankingList.Reverse();
        var listMin = instance.rankingList.Count;
        if (instance.rankingText.Length < instance.rankingList.Count)
        {
            listMin = instance.rankingText.Length;
            instance.rankingList.RemoveAt(instance.rankingText.Length);
        }
        for (int i = 0; i < listMin; i++)
        {
            instance.rankingText[i].text = (i + 1) + "位" + instance.rankingList[i];
        }
        Score.finalScore = instance.rankingList[2]-1;
    }
    // Start is called before the first frame update
    public void BecomeTransparent()
    {
        canvas.enabled = false;
    }

    
}
