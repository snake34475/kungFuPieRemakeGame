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
    public bool isMove = true; //是否开始移动
    private Vector2 movePlay; //移动向量
    public float moveTimer; //移动计时器
    public float moveTime=3; // 移动时间
    public float atkTime = 3;//攻击间隔
    public float atkTimer;//攻击间隔定时器
    public GameObject longZhu;
    private bool isDeath=false;
    public GameObject textbyAtk;
    //生命值
    public float maxHp=500;
    public int atk = 40;//攻击
    public float currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        rigBody = GetComponent<Rigidbody2D>();
        animator = this.transform.Find("bosser").GetComponent<Animator>();
        //自动生成移动
        moveAuto();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }
    private void FixedUpdate()
    {
        //死亡
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
        //被击飞的情况
        else if (transform.GetChild(1).GetComponent<Animator>().GetBool("isbyfly"))
        {
            resetMoveTimer();
        }
        else
        {
            Vector2 position = rigBody.position;
            //发现人了
            
            if (GameObject.Find("play"))
            {
                //如果在范围内
                if ((GameObject.Find("play").transform.position - transform.position).magnitude <8
                    && !GameObject.Find("role").GetComponent<Animator>().GetBool("isDeath") 
                    && !animator.GetBool("isYunXuan") )
                {
                    //向量
                    Vector3 BossToPlayV3 = GameObject.Find("play").transform.position - transform.position;
                    //判断攻击距离
                    if (Math.Abs(GameObject.Find("play").transform.position.x - transform.position.x) > 1.8f 
                        ||  Math.Abs(GameObject.Find("play").transform.position.y - transform.position.y)  > 0.5f
                       )
                    {
                        animator.SetBool("isatk", false);

                        //判断移动向量
                        BossToPlayV3.x = BossToPlayV3.x > 0 ? 1 : -1;
                        BossToPlayV3.y = BossToPlayV3.y > 0 ? 1 : -1;
                        movePlay = BossToPlayV3;
                        position += movePlay * speed * Time.deltaTime * 0.2f;///乘以0.5是让怪物移动的慢一点

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
                        //到了就重新计时
                        else
                        {
                            moveAuto();
                            moveTimer = moveTime;
                        }
                    }
                    //在攻击范围内
                    else
                    {

                        movePlay = new Vector3(0, 0, 0);
                        animator.SetBool("isatk", true);
                        atkTimer = atkTime;
                    }
                    rigBody.MovePosition(position);
                

                }
                //不追人情况
                else
                {
                    //看计时时间到了么
                    animator.SetBool("isatk", false);
                    if (moveTimer >= 0)
                    {
                        position += movePlay * speed * Time.deltaTime*0.2f;
                        rigBody.MovePosition(position);
                        moveTimer -= Time.deltaTime;
                    }
                    //到了就重新计时
                    else
                    {
                        moveAuto();
                        moveTimer = moveTime;
                    }
                }
            }

        }
        // 切换方向
        checkoutMove(movePlay.x); 
    }
    //头顶血量和伤害
    public void underAtk(float atk)
    {
        currentHp -= atk;
        this.transform.Find("画布").GetComponent<hpMp>().updataHp(currentHp, maxHp);
        Vector3 textpos =new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        byatk.transform.SetParent(transform);
        byatk.transform.GetChild(0).GetComponent<Text>().text = "-" + atk + "";
    }
    //移动动画切换
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
    //切换人物移动方向
    void checkoutMove(float x)
    {
        if (x != 0)
        {
            Vector3 thisScale = this.transform.localScale;
            thisScale.x = Math.Abs(thisScale.x) * x;
            transform.localScale = thisScale;
        }
        //判断是否移动
        animator.SetFloat("speed", movePlay.magnitude);
    }
}
