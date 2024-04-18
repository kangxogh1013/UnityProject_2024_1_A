using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchScaleTween : MonoBehaviour
{
    public bool isPunch = false;  //�÷��� �� ����

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //������ũ Ű�� ������
        {
            if (!isPunch)         //��ġ��
            {
                isPunch = true;     //��ġ ������ ���°��� �����
                //��ġ ȿ���� �ְ� ȿ���� ������ EndPunch �Լ��� ȣ��
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);
            }
        }
    }

    void EndPunch()
    {
        isPunch = false;
    }
}
