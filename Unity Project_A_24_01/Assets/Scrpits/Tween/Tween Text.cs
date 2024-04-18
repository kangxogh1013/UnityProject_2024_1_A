using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;     //DOTween�� ����ϱ� ���� �߰�

public class TweenText : MonoBehaviour
{
    Sequence sequence;
    Tween tween;

    // Start is called before the first frame update
    void Start()
    {
        //Tween ����
        //tween = transform.DOMoveX(5, 2);                             //�� �������� 2�ʵ��� X�� 5�� �̵� ��Ų��
        //transform.DORotate(new Vector3(0, 0, 180), 2);       //�� �������� 2�ʵ��� Z������ 180�� ȸ�� ��Ų��
        //transform.DOScale(new Vector3(2, 2, 2), 2);          //�� �������� 2�ʵ��� scale�� 2�� �ǵ��� Ű���

        //��ü �ְ� �� ����   STrl + K+ C Ctrl + K + U
        //sequence sequence = dotween.sequence();             //tween�� �̾ ������� ���� �����ִ� ����
        //sequence.append(transform.domovex(5, 2));
        //sequence.append(transform.dorotate(new vector3(0, 0, 180), 1));
        //sequence.append(transform.doscale(new vector3(2, 2, 2), 1));

        //transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce);                    //Ease �ɼ��� ����Ͽ� �ٿ ȿ�� ����
        //transform.DOShakeRotation(2f, new Vector3(0, 0, 90), 10, 90);        //ȸ���� Z�� 90�� ���� 10 ���� 90���� ���� �ش�

        /*transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(TweenEnd); */  //Ʈ���� �Ϸ�Ǹ� TweenEnd �Լ��� ȣ���Ѵ�

        sequence = DOTween.Sequence();             //tween�� �̾ ������� ���� �����ִ� ����
        sequence.Append(transform.DOMoveX(5, 1));          //tween ����
        sequence.SetLoops(-1, LoopType.Yoyo);             //tween ������·� �ݺ� ��Ų��
    }

    void TweenEnd()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sequence.Kill();
            //tween.Kill();
        }
    }
}
