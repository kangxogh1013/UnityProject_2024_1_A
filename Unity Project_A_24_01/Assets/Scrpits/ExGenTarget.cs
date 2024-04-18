using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenTarget : MonoBehaviour
{
    public GameObject Target;                                                          //아이템 박스의 정의 
    public float checkTime;                                                            //시간 검사할 변수 선언

    void Update()
    {
        checkTime += Time.deltaTime;                                                    //프레임 시간을 쌓아르서 초를 검사한다.
        if (checkTime >= 1.0f)                                                           //1초의시간이 흐르면 
        {
            checkTime = 0.0f;                                                           //시간 초기화를 시킨다 
            GameObject temp = Instantiate(Target);                                     //아이템 박스 프리팸을 Instantiate로 생선한다. 
            temp.transform.position = new Vector3(-4.0f, -4.0f, 0.0f);               //생선할때 스크립트가 있는 오브젝트 위치로 생선 
            int RandomNumberX = Random.Range(0, 8);                                       //0~8값을  랜덤 생선한다.
            int RandomNumberY = Random.Range(0, 8);
            temp.transform.position += new Vector3(RandomNumberX, RandomNumberY, 0.0f);          //X, Y값 위치에 더해준다.

            Destroy(temp, 2.0f);
        }
    }
}
