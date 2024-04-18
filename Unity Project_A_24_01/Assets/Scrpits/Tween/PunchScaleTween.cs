using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchScaleTween : MonoBehaviour
{
    public bool isPunch = false;  //플레그 값 선언

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //스페이크 키를 누르면
        {
            if (!isPunch)         //펀치중
            {
                isPunch = true;     //펀치 중으로 상태값을 만든다
                //펀치 효과를 주고 효과가 끝나면 EndPunch 함수를 호출
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);
            }
        }
    }

    void EndPunch()
    {
        isPunch = false;
    }
}
