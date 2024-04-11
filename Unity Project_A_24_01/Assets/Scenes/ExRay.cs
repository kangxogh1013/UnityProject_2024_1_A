using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRay : MonoBehaviour
{
    public Text UIText;                  //�ؽ�Ʈ�� ����
    public int Point;                    //����Ʈ�� ����
    public float checkEndTime = 30.0f;   //��������ð�����

    void Update()
    {
        checkEndTime -= Time.deltaTime;        //�ʸ� ���������� �A��

        if(checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);           //������ ������ ���� ������ �����Ѵ�
            SceneManager.LoadScene("ResultScene");        //��� â���� �̵��Ѵ�
        }

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
                    //if (Point >= 10) DoChangeScene();                       //����Ʈ�� 10���� �ѱ�� scene�� ��ȯ�Ѵ�.
                }
            }
            else
            {
                Point = 0;                                                  //Miss t�� ����Ʈ
            }
            UIText.text = Point.ToString();                                 //UI��ǥ��
        }
    }

    void DoChangeScene()                                   //�� ��ȯ�� ���� �Լ� ����
    {
        SceneManager.LoadScene("ResultScene");            //ResultScene ���� ��ȯ �ȴ�.
    }
}
