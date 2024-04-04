using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenltem : MonoBehaviour
{
    public GameObject ItemBox;                                                           //아이템 박스의 정의 
    public float checkTime;                                                              //시간 검사할 변수 선언
    void Update()
    {
        checkTime += Time.deltaTime;                                                    //프레임 시간을 쌓아르서 초를 검사한다.
        if(checkTime >= 2.0f)                                                           //2초의시간이 흐르면 
        {
            checkTime = 0.0f;                                                           //시간 초기화를 시킨다 
            GameObject temp = Instantiate(ItemBox);                                     //아이템 박스 프리팸을 Instantiate로 생선한다. 
            temp.transform.position = this.gameObject.transform.position;               //생선할때 스크립트가 있는 오브젝트 위치로 생선 
            int RandomNumberY = Random.Range(0, 4);                                    //0에서3까지의 랜덤 값을 받아서
            temp.transform.position += new Vector3(0.0f, RandomNumberY, 0.0f);         //Y값 위치에 더해준다.

            Destroy(temp, 2.0f);
        }
    }

}
