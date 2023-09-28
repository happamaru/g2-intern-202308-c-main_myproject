using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTruck : MonoBehaviour
{
    //移動や回転において必要なコンポーネント
    [SerializeField] Rigidbody2D track;
    [SerializeField] Transform trackTrans; 
    [SerializeField] Transform wheelFront;
    [SerializeField] Transform wheelBack;
    [SerializeField] Transform cameraTrans;

    //車における各種パラメータ
    [SerializeField] float movePower; [SerializeField] float rotateSpeed;

    //振動の幅を設定する
    [SerializeField] int[] minWavePower;
    [SerializeField] int[] maxWavePower;
    [SerializeField] int[] frequency;

    //一定のタイミングで小さな振動が発生する
    int counter = 0;

    //一定のタイミングで大きな振動が発生する
    int bigCounter = 0;

    //難しさのインデックスを持つ
    int difficultIndex;

    [SerializeField]
    private GameObject effectPositionObject;
    float effectY;
    private void Awake()
    {
        difficultIndex = RoadManager.TodayRoad();
        Score.playerScore = 0;
        Score.scoreDamages = 0;
        Debug.Log(difficultIndex);
    }
    private void Start()
    {
        track.constraints = RigidbodyConstraints2D.FreezeAll;
        effectY = effectPositionObject.transform.position.y;
    }
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsVehicleDeparture || GameManager.Instance.IsVehicleArrival) { return; }

        track.constraints = RigidbodyConstraints2D.None;
        track.constraints = RigidbodyConstraints2D.FreezeRotation;
        //タイヤを回す
        wheelFront.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        wheelBack.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        //振動を起こす頻度
        counter++;
        bigCounter++;
        //進行処理
        var stuck = track.velocity;
        stuck.x = Vector2.right.x * movePower;
        track.velocity = stuck;
        //常に小さな振動の処理
        if (counter > 40)
        {
            var posStuck = effectPositionObject.transform.position;
            if (posStuck.y <= effectY + 0.6f)
            {
                EffectController.Instance.EffectPlay(posStuck, EffectController.EffectName.Drive);
            }
            track.AddForce(new Vector2(200, 230), ForceMode2D.Impulse);
            counter = 0;
        }

        //大きい振動処理
        if (bigCounter > frequency[difficultIndex])
        {
            var posStuck = effectPositionObject.transform.position;
            if (posStuck.y <= effectY + 0.6f)
            {
                EffectController.Instance.EffectPlay(posStuck, EffectController.EffectName.Drive);
            }
            track.AddForce(new Vector2(minWavePower[difficultIndex], maxWavePower[difficultIndex]), ForceMode2D.Impulse);
            bigCounter = 0;
        }
    }
}
