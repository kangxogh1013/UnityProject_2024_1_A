using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;            //���콺 drag �Ǵ�
    public bool isUsed;            //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;       //2D ��ü ����
    
    public int index;              //���� ��ȣ ����
                                   // Start is called before the first frame update
    public float EndTime = 0.0f;   //���� �� �ð� üũ ����(float)
    public SpriteRenderer spriteRenderer;       //����� ��������Ʈ ���� ��ȯ ��Ű�� ���ؼ� ���� ����
    public GameManager gameManager;             //���� �Ŵ��� ������
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    //������Ʈ�� ��ü�� ����
        isUsed = false;                              //�����Ҷ� ����� �ȵǾ��ٰ� �Է� 
        rigidbody2D.simulated = false;                //���� �ൿ�� ó������ �������� �ʰ� ���� 

        spriteRenderer = GetComponent<SpriteRenderer>();    //������Ʈ�� �پ��ִ� ������Ʈ�� ����
    }
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();    //���� �޴����� ���´�
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)                 //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ���� ������. (���콺 Input ������ ���� ����)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //ȭ�� ��ũ������ ����Ƽ scene ������ ��ǥ�� �����´�

            float IeftBorder = -5.0f + transform.localScale.x / 2f;    //������ ��ŭ �̵� ����
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < IeftBorder) mousePos.x = IeftBorder;      //���콺 ��ġ�� �̵� ���� �Ѱ� �̻�, ���Ϸ� ���� ���� �����ؼ� ���д�
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                            //������Ʈ Y�� �� ����
            mousePos.z = 0;                                            //������Ʈ Z�� �� ����
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);      //�� ������Ʈ�� ���콺 ��ġ�� ���Ͼ����ϰ� 0.2 ����ŭ �̵����� ���󰣴�

        }

        if (Input.GetMouseButtonDown(0)) Drag();      //���콺 ��ư�� ������ �� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();        //���콺 ��ư�� ������ �� Dr���� �Լ� ����
    }

    void Drag()                          //�巡�� �� �� ���� �� �Լ�
    {
        isDrag = true;                   //�巡�� ���̴� true
        rigidbody2D.simulated = false;   //���� �ùķ��̼�  false
    }

    void Drop()                          //��� �Ҷ� ���� �� �Լ�
    {
        isDrag = false;                  //�巡�� ���̴�  false
        isUsed = true;                   //��� �Ϸ� �Ǿ���  true
        rigidbody2D.simulated = true;    //�ĸ� �ùķ��̼� �����  true

        gameManager.GemObject();
    }

    public void Used()
    {
        isDrag = false;                  //�巡�� ���̴�  false
        isUsed = true;                   //��� �Ϸ� �Ǿ���  true
        rigidbody2D.simulated = true;    //�ĸ� �ùķ��̼� �����  true
    }

    public void OnTriggerStay2D(Collider2D collision)      //Trigger�� ������
    {
        if(collision.tag == "EndLine")                     //�浹���� ��ü�� Tag��  EndLine �� ���
        {
            EndTime += Time.deltaTime;                     //������ �ð���ŭ ���� ���Ѽ� �ʸ� ī��� �Ѵ�

            if(EndTime > 1)                               //1�� �̻� �� ���
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f); //������ ó��
            }
            if(EndTime > 3)                                //3�� �̻� �� ���
            {
                //Debug.Log("���� ����");                       //�켱 ���� ���� ó��
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)      //Trigger�� ���� ��
    {
        if(collision.tag == "EndLine")                     //�浹���� ��ü�� Tag��  EndLine �� ���
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;              //�⺻ �������� ����
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)                        //�ش� ������Ʈ�� �浹 ���� �� OnCollisionEnter2D
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag == "Fruit")                                     //�浹�� ���� ������ ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();   //�浹�� ��ü���� ���� Class�� �޾ƿ´�

            if(temp.index == index)                                                //�浹 indwx�� �� index�� ����
            {

                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) //2�� ���ļ� 1���� ����� ���ؼ� ID �˻� �� ū�͸�
                {
                    //GameManager���� ��ģ ������Ʈ�� ����
                    gameManager.MergeObject(index, gameObject.transform.position);
                    Destroy(temp.gameObject);                                               //�浹�� ��ü ����
                    Destroy(gameObject);                                                    //�ڽŵ� ����
                }

            }
        }
    }
}
    