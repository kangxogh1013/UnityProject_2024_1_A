using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircleObject;      //��ü �������� �����´�.
    public Transform genTransform;       //���� ��ġ ����
    public float timCheck;               //���� �ð� ���� ����(float)
    public bool isGen;                   //���� üũ (bool)

    public void GenObject()              //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;                   //���� �Ϸ� �Ǿ����� bool�� false ����
        timCheck = 1.0f;                 //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                               //isGen �÷��װ� false �ϰ��
        {
            timCheck -= Time.deltaTime;                                  //�� ������ ���ư��鼭 �ð��� ���� ��Ų��
            if(timCheck <= 0.0f)                                         //0�� ���ϰ� �Ƿ��� ���
            {
                GameObject Temp = Instantiate(CircleObject);           //������ ������ Temp������Ʈ
                Temp.transform.position = genTransform.position;         //���� ��ġ�� ���� ��Ų��
                isGen = true;
            }
        }
    }
}
