using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRay : MonoBehaviour
{
    public Text UIText;                  //텍스트의 정의
    public int Point;                    //포인트의 정의
    public float checkEndTime = 30.0f;   //게임종료시간설정

    void Update()
    {
        checkEndTime -= Time.deltaTime;        //초를 지속적으로 뺸다

        if(checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);           //게임이 끝나기 전에 점수를 저장한다
            SceneManager.LoadScene("ResultScene");        //결과 창으로 이동한다
        }

        if (Input.GetMouseButtonDown(1))                                      //GetMouseButtonDown(1) 오른쪽 버튼 마우스다 눌렸을 때
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);    //Ray를 정의하고 카메라의 마우스 위치에서 Ray를 쓴다

            RaycastHit hit;                                                  //Ray를 쏘고 충돌할 물체의 값을 hit 넣기 위한 정의

            if (Physics.Raycast(cast, out hit))                              //충돌후에 값이 hit있을 경우
            {
                Debug.Log(hit.collider.gameObject.name);                     //충돌한 오브젝트의 이름을 받아온다.  
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);     //RayCast 선을 디버그로 볼 수 있게 한다.

                if(hit.collider.gameObject.tag == "Target")                  //충동한 오브젝트의 tag이름이 Target 일 경우
                {
                    Destroy(hit.collider.gameObject);                       //해당 오브젝트를 파괴한다.
                    Point += 1;                                             //파괴시 포인트 +1
                    //if (Point >= 10) DoChangeScene();                       //포인트가 10점을 넘기면 scene을 전환한다.
                }
            }
            else
            {
                Point = 0;                                                  //Miss t시 포인트
            }
            UIText.text = Point.ToString();                                 //UI에표시
        }
    }

    void DoChangeScene()                                   //씬 전환을 위한 함수 선완
    {
        SceneManager.LoadScene("ResultScene");            //ResultScene 으로 전환 된다.
    }
}
