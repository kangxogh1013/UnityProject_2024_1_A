using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenltem : MonoBehaviour
{
    public GameObject ItemBox;                                                           //������ �ڽ��� ���� 
    public float checkTime;                                                              //�ð� �˻��� ���� ����
    void Update()
    {
        checkTime += Time.deltaTime;                                                    //������ �ð��� �׾Ƹ��� �ʸ� �˻��Ѵ�.
        if(checkTime >= 2.0f)                                                           //2���ǽð��� �帣�� 
        {
            checkTime = 0.0f;                                                           //�ð� �ʱ�ȭ�� ��Ų�� 
            GameObject temp = Instantiate(ItemBox);                                     //������ �ڽ� �������� Instantiate�� �����Ѵ�. 
            temp.transform.position = this.gameObject.transform.position;               //�����Ҷ� ��ũ��Ʈ�� �ִ� ������Ʈ ��ġ�� ���� 
            int RandomNumberY = Random.Range(0, 4);                                    //0����3������ ���� ���� �޾Ƽ�
            temp.transform.position += new Vector3(0.0f, RandomNumberY, 0.0f);         //Y�� ��ġ�� �����ش�.

            Destroy(temp, 2.0f);
        }
    }

}
