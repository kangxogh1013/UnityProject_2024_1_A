using System;                             //Action�� ����ϱ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] circleObject;      //��ü �������� �����´�.  (�迭�� ����)
    public Transform genTransform;       //���� ��ġ ����
    public float timCheck;               //���� �ð� ���� ����(float)
    public bool isGen;                   //���� üũ (bool)

    public int Point;                //����
    public int BestScore;            //�ְ� ����
    public static event Action<int> OnPointChanged;       //������ ���� �Ǿ����� �̺�Ʈ�� �߻� ��Ų��
    public static event Action<int> OnBestScoreChanged;   //�ְ� ������ ����  �Ǿ����� �̺�Ʈ�� �߻� ��Ų��
    public void GemObject()              //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;                   //���� �Ϸ� �Ǿ����� bool�� false ����
        timCheck = 1.0f;                 //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }

    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        GemObject();
        OnPointChanged?.Invoke(Point);             //������ �� ���� 1�� ����
        OnBestScoreChanged?.Invoke(BestScore);     //������ �� �ְ� ���� 1�� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                               //isGen �÷��װ� false �ϰ��
        {
            timCheck -= Time.deltaTime;                                  //�� ������ ���ư��鼭 �ð��� ���� ��Ų��
            if(timCheck <= 0.0f)                                         //0�� ���ϰ� �Ƿ��� ���
            {
                int RandNumber = UnityEngine.Random.Range(0, 3);                     //0~2�� ���� �ѹ� ����
                GameObject Temp = Instantiate(circleObject[RandNumber]);           //������ ������ Temp������Ʈ
                Temp.transform.position = genTransform.position;         //���� ��ġ�� ���� ��Ų��
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)                   //�浹�� ��ü�� index ��ȣ�� ��ġ�� �����´�
    {
        GameObject Temp = Instantiate(circleObject[index]);        //������ ���� ������Ʈ�� Temp�� �ִ´�
        Temp.transform.position = position;                         //Temp ������Ʈ�� ��ġ�� �Լ��� �޾ƿ� ��ġ��
        Temp.GetComponent<CircleObject>().Used();                 //�����Ǿ������� ���Ǿ��ٰ� ǥ�� �������

        Point += (int)Mathf.Pow(index, 2) * 10;                        //index�� 2������ ����Ʈ ���� pow �Լ� Ȱ��
        OnPointChanged?.Invoke(Point);                                 //����Ʈ�� ����Ǿ����� �̺�Ʈ�� ���� �Ǿ��ٰ� �˸�
    }

    public void EndGame()                                       //���� ���� �Ǿ��� �� �Լ�
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");          //������ ����� ������ �ҷ��´�

        if(Point > BestScore)                                  //���� ����Ʈ�� ���Ѵ�
        {
            BestScore = Point;
            PlayerPrefs.SetInt("BestScore", Point);               //����Ʈ�� �� Ŭ ��� �����Ѵ�
            OnBestScoreChanged?.Invoke(BestScore);
        }
        //���� �� �ؾ� ���� ���߿� �߰�
    }
}
