using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectManager : MonoBehaviour
{
    
    [SerializeField] List<ItemButton> itemButtons;//UIアイテムのボタンクラス
    [SerializeField] ItemDataBase itemDataBase;//アイテムのデータベース
   [SerializeField] List <ItemData> NowItemDatas;
    [SerializeField] int TotalItemNum;
    [SerializeField] Text ScoreText;
    [SerializeField] Text MassText;
    [SerializeField] GameObject HandImage;//プレイヤーが手に持ってる画像
    int? SelectID = null;

    IEnumerator Start(){
        yield return null;
        for(int k =0; k<TotalItemNum;k++){
            int ran = Random.Range(0,itemDataBase.itemDatas.Count);
            NowItemDatas.Add(itemDataBase.itemDatas[ran]);
        }

        for(int i =0;i < itemButtons.Count;i++){
            itemButtons[i].OnSelect = Select;
            itemButtons[i].Set_Image = NowItemDatas[i].Image;
        }
    }

    public GameObject InstanceItem(){
        if(SelectID == null) return null;
        ItemData itemData = NowItemDatas[(int)SelectID];
        GameObject go = Instantiate(itemData.Prefab) as GameObject;
        go.transform.position = HandImage.transform.position;
        go.GetComponent<Item>().Init(itemData);
     //   HandImage.SetActive(false);
        return go;
    }

    public void LeftButton(){
         for(int i =0;i < itemButtons.Count;i++){
            if(itemButtons[i].ID_Set == 0) return;
            itemButtons[i].ID_Set = -1;
            itemButtons[i].Set_Image = NowItemDatas[itemButtons[i].ID_Set].Image;
        }
    }
       public void RightButton(){
         for(int i =itemButtons.Count-1;i >= 0;i--){
            if(itemButtons[i].ID_Set == NowItemDatas.Count-1) return;
            itemButtons[i].ID_Set = 1;
            itemButtons[i].Set_Image = NowItemDatas[itemButtons[i].ID_Set].Image;
        }
    }

    /// <summary>
    /// アイテムボタンが押されたとき呼ばれる
    /// </summary>
    /// <param name="ItemID"></param>
    public void Select(int ItemID){
        SelectID = ItemID;
        if(!HandImage.activeSelf){
            HandImage.SetActive(true);
        }
        float mass = NowItemDatas[(int)SelectID].Mass;
        if(mass <= 5f){
            MassText.text = "重さ:軽い";
        }else if(mass <= 9){
            MassText.text = "重さ:ふつう";
        }else{
            MassText.text = "重さ:重い";
        }
        ScoreText.text = "スコア" + NowItemDatas[(int)SelectID].Score.ToString();
        float scale = NowItemDatas[(int)SelectID].scale;
        HandImage.transform.localScale = new Vector3(scale,scale,scale);
        HandImage.GetComponent<SpriteRenderer>().sprite = NowItemDatas[(int)SelectID].Image;
    }

    public void RemoveItem(){
        if(SelectID == null) return;
        NowItemDatas.RemoveAt((int)SelectID);
            if(NowItemDatas.Count == 2){
                itemButtons[2].DestroyBox();
                ResetID();
            }
            if(NowItemDatas.Count == 1) {
                itemButtons[1].DestroyBox();
                ResetID();
            }
            if(NowItemDatas.Count == 0) {
                itemButtons[0].DestroyBox();
                ResetID();
                 for(int k =0; k<TotalItemNum;k++){
                    int ran = Random.Range(0,itemDataBase.itemDatas.Count);
                    NowItemDatas.Add(itemDataBase.itemDatas[ran]);
                }
                for(int i =0;i < itemButtons.Count;i++){
                    itemButtons[i].ActiveBox();
                    itemButtons[i].Set_Image = NowItemDatas[i].Image;
                }
            }
         for(int i =0;i < itemButtons.Count;i++){
            if(itemButtons[i].CheckIsActive() == false) continue;
            itemButtons[i].Set_Image = NowItemDatas[i].Image;
        }
        SelectID = null;
        ScoreText.text = "";
        MassText.text = "";
        HandImage.GetComponent<SpriteRenderer>().sprite = null;
    }

    void ResetID(){
        itemButtons[0].SetID = 0;
        itemButtons[1].SetID = 1;
        itemButtons[2].SetID = 2;
    }
}
