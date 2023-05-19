using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class boss : MonoBehaviour
{
    public float speed = 0.2f;
    Animator animator;
    Rigidbody2D rigBody;
    public bool isMove = true; //�Ƿ�ʼ�ƶ�
    private Vector2 movePlay; //�ƶ�����
    public float moveTimer; //�ƶ���ʱ��
    public float moveTime=3; // �ƶ�ʱ��
    public float atkTime = 3;//�������
    public float atkTimer;//���������ʱ��
    public GameObject longZhu;
    private bool isDeath=false;
    public GameObject textbyAtk;
    //����ֵ
    public float maxHp=500;
    public int atk = 40;//����
    public float currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        rigBody = GetComponent<Rigidbody2D>();
        animator = this.transform.Find("bosser").GetComponent<Animator>();
        //�Զ������ƶ�
        moveAuto();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }
    private void FixedUpdate()
    {
        //����
        if (currentHp <= 0)
        {

            animator.SetBool("isDeath", true);
            resetMoveTimer();
            if (isDeath == false)
            {
                Instantiate(longZhu, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            isDeath = true;
        }
        //�����ɵ����
        else if (transform.GetChild(1).GetComponent<Animator>().GetBool("isbyfly"))
        {
            resetMoveTimer();
        }
        else
        {
            Vector2 position = rigBody.position;
            //��������
            
            if (GameObject.Find("play"))
            {
                //����ڷ�Χ��
                if ((GameObject.Find("play").transform.position - transform.position).magnitude <8
                    && !GameObject.Find("role").GetComponent<Animator>().GetBool("isDeath") 
                    && !animator.GetBool("isYunXuan") )
                {
                    //����
                    Vector3 BossToPlayV3 = GameObject.Find("play").transform.position - transform.position;
                    //�жϹ�������
                    if (Math.Abs(GameObject.Find("play").transform.position.x - transform.position.x) > 1.8f 
                        ||  Math.Abs(GameObject.Find("play").transform.position.y - transform.position.y)  > 0.5f
                       )
                    {
                        animator.SetBool("isatk", false);

                        //�ж��ƶ�����
                        BossToPlayV3.x = BossToPlayV3.x > 0 ? 1 : -1;
                        BossToPlayV3.y = BossToPlayV3.y > 0 ? 1 : -1;
                        movePlay = BossToPlayV3;
                        position += movePlay * speed * Time.deltaTime * 0.2f;///����0.5���ù����ƶ�����һ��

                    }else if (atkTimer >= 0)
                    {
                        atkTimer -= Time.deltaTime;
                        animator.SetBool("isatk", false);
                        if (moveTimer >= 0)
                        {
                            position += movePlay * speed * Time.deltaTime * 0.2f;
                            rigBody.MovePosition(position);
                            moveTimer -= Time.deltaTime;
                        }
                        //���˾����¼�ʱ
                        else
                        {
                            moveAuto();
                            moveTimer = moveTime;
                        }
                    }
                    //�ڹ�����Χ��
                    else
                    {

                        movePlay = new Vector3(0, 0, 0);
                        animator.SetBool("isatk", true);
                        atkTimer = atkTime;
                    }
                    rigBody.MovePosition(position);
                

                }
                //��׷�����
                else
                {
                    //����ʱʱ�䵽��ô
                    animator.SetBool("isatk", false);
                    if (moveTimer >= 0)
                    {
                        position += movePlay * speed * Time.deltaTime*0.2f;
                        rigBody.MovePosition(position);
                        moveTimer -= Time.deltaTime;
                    }
                    //���˾����¼�ʱ
                    else
                    {
                        moveAuto();
                        moveTimer = moveTime;
                    }
                }
            }

        }
        // �л�����
        checkoutMove(movePlay.x); 
    }
    //ͷ��Ѫ�����˺�
    public void underAtk(float atk)
    {
        currentHp -= atk;
        this.transform.Find("����").GetComponent<hpMp>().updataHp(currentHp, maxHp);
        Vector3 textpos =new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        byatk.transform.SetParent(transform);
        byatk.transform.GetChild(0).GetComponent<Text>().text = "-" + atk + "";
    }
    //�ƶ������л�
    void moveAuto()
    {
       
        System.Random rd = new System.Random();
        float x = rd.Next(-1, 2);
        float y = rd.Next(-1, 2);
        movePlay = new Vector2(x, y);
       
       
    }

    void resetMoveTimer()
    {
        movePlay = new Vector2(0, 0);
        moveTimer = moveTime;
    }
    //�л������ƶ�����
    void checkoutMove(float x)
    {
        if (x != 0)
        {
            Vector3 thisScale = this.transform.localScale;
            thisScale.x = Math.Abs(thisScale.x) * x;
            transform.localScale = thisScale;
        }
        //�ж��Ƿ��ƶ�
        animator.SetFloat("speed", movePlay.magnitude);
    }
}
