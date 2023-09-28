using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemThrow : MonoBehaviour
{
    //アイテムの選択やアイテムの生成を行うクラス
    [SerializeField]
    private ItemSelectManager itemSelectManager;

    //パワーゲージのオブジェクト
    [SerializeField]
    private GameObject meterObject;

    //投擲を開始できる範囲
    [SerializeField]
    ThrowArea throwArea;

    //投擲のパワー
    private float power = 0.0f;


    //上下用
    private bool reachedMaxPower = false;

    //MAXのパワー
    [SerializeField]
    private float MaxPower;

    //投げる方向
    Vector3 throwVector;

    //方向の矢印
    [SerializeField]
    private GameObject arrow;


    [SerializeField]
    private  float Meter;

    [SerializeField]
    private SoundManager soundManager;

    
    void Update()
    {
        if (GameManager.Instance.IsComplete) { return; }
        if (!throwArea.CanThrow) { return; }
      
        if (Input.GetMouseButton(0))
        {
            PowerMeter();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Throw();
            soundManager.Play(11);
            power = 0;
            reachedMaxPower = false;
        }
        else if (!Input.GetMouseButton(0))
        {
            throwVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) -(Vector2) arrow.transform.position;
            Vector3 angle = arrow.transform.localEulerAngles;
            angle.z = Mathf.Atan2(throwVector.y, throwVector.x) * Mathf.Rad2Deg;
            arrow.transform.localEulerAngles = angle;

        }


    }

    //投擲関数
    private void Throw()
    {

        //アイテムセレクトで選択されているアイテムを生成
        GameObject throwItem = itemSelectManager.InstanceItem();
        itemSelectManager.RemoveItem();
        if (!throwItem) { return; }
        //AddForceするためにアイテムのrigidbody2Dを確認
        Rigidbody2D itemRigid = throwItem.GetComponent<Rigidbody2D>();
        Vector2 normalizedThrow = throwVector/throwVector.magnitude;
        //実際に投擲する力を加える
        itemRigid.AddForce(normalizedThrow *  ( power ) ,ForceMode2D.Impulse);
    }

    //投擲力を視覚化する関数
    private void PowerMeter()
    {
        //マックスまで到達したとき切り替える
        if (power > MaxPower) { reachedMaxPower = true; }
        else if (power <= 0) { reachedMaxPower = false; }


        if(!reachedMaxPower)
        {
            
            power += (Meter * MaxPower) * Time.deltaTime;
        }
        else
        {
            power -= (Meter * MaxPower) * Time.deltaTime;
        }

        Vector2 objScale = meterObject.transform.localScale;

        objScale.y = 1 - (power/MaxPower);

        meterObject.transform.localScale = objScale;
    }


}
