using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rg2d;
    Collider2D coll;
    int MyScore;
    [SerializeField]
    private ScoreUI scoreUIScript;

    /// <summary>
    /// アイテムの初期化処理
    /// データベースのデータを入れる
    /// </summary>
    /// <param name="itemData"></param>
   public void Init(ItemData itemData){
        rg2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        MyScore = itemData.Score;
        rg2d.mass = itemData.Mass;
        transform.localScale = new Vector3(itemData.scale,itemData.scale,itemData.scale);
   }

   void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Track")){
            Score.AddScore(MyScore);
            Debug.Log("スコアの追加");
        }
   }
   void OnTriggerExit2D(Collider2D collider2D){
       if(collider2D.CompareTag("Track")){
            Score.AddScore(-MyScore);
            Debug.Log("スコアを減らす");
        }
   }

   void OnCollisionEnter2D(Collision2D collision2D){
         if(collision2D.gameObject.tag == "Ground"){
            EffectController.Instance.EffectPlay(this.transform.position,EffectController.EffectName.ItemDestory);
            Score.AddReparation(MyScore);
            Destroy(this.gameObject);
        }
   }
}
