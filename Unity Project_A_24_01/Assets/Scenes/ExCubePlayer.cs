using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;             //�ؽ�Ʈ UI
    public int Count = 0;                  //���콺 Ŭ�� ī����
    public float Power = 100.0f;           //���� �� ��ġ
    
    public int Point = 0;                  //���� ��ġ
    public float checkTime = 0.0f;         //�ð� üũ ǥ��

    public Rigidbody m_Rigidbody;          //������Ʈ�� ��ü
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�����̽��� ������
        {
            Power = Random.Range(100, 200);                // 100 ~ 200 ������ ���� ���� �ش�
            m_Rigidbody.AddForce(transform.up * Power);    //Y������ ������ ���� �ش�
        }

        TextUI.text = Point.ToString();                    //UI�� ���� ǥ�ø� �Ѵ�.
    } 
    
    void OnCollisionEnter(Collision collision)             //�浹�� �Ǿ��� ��
    {
        //Debug.Log(collision.gameObject.name);
        Point = 0;
        gameObject.transform.position = Vector3.zero;      //�÷��̾ �������� �ޤ���Ų��
    }
}