using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    //�S�[�������ɂ���
    [SerializeField] Transform now;[SerializeField] Transform goal;

    //���ۂɕ\�����铹�̂�I�u�W�F�N�g
    [SerializeField] Slider nowPos;

    //���߂̃^�C�~���O�ł̕\���̋������擾
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
        //��ɍ������Q�Ƃ��邱�ƂŃS�[���܂ł̋����Ȃǂ�\������
        var stuck1 = now.position;
        var stuck2 = goal.position;
        stuck1.y = 0;
        stuck2.y = 0;

        float nowdistance = Vector2.Distance(stuck1, stuck2);
        float distanceValue = distance - nowdistance;
        nowPos.value = distanceValue / distance;
    }
}
