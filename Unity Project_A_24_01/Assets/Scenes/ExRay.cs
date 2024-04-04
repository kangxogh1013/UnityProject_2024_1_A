using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExRay : MonoBehaviour
{
    public Text UIText;                  //�ؽ�Ʈ�� ����
    public int Point;                    //����Ʈ�� ����
    void Update()
    {
        if (Input.GetMouseButtonDown(1))                                      //GetMouseButtonDown(1) ������ ��ư ���콺�� ������ ��
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);    //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ����

            RaycastHit hit;                                                  //Ray�� ��� �浹�� ��ü�� ���� hit �ֱ� ���� ����

            if (Physics.Raycast(cast, out hit))                              //�浹�Ŀ� ���� hit���� ���
            {
                Debug.Log(hit.collider.gameObject.name);                     //�浹�� ������Ʈ�� �̸��� �޾ƿ´�.  
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);     //RayCast ���� ����׷� �� �� �ְ� �Ѵ�.

                if(hit.collider.gameObject.tag == "Target")                  //�浿�� ������Ʈ�� tag�̸��� Target �� ���
                {
                    Destroy(hit.collider.gameObject);                       //�ش� ������Ʈ�� �ı��Ѵ�.
                    Point += 1;                                             //�ı��� ����Ʈ +1
                }
            }
            else
            {
                Point = 0;                                                  //Miss t�� ����Ʈ
            }
            UIText.text = Point.ToString();                                 //UI��ǥ��
        }
    }
}