using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class player : MonoBehaviour
{
    public float speed = 4f; //移动速度
    public float height = 1000f; //跳跃高度
    public Vector2 movePlay;
    public GameObject[] attkJudge;
    public bool isGoodsTrigger = false;
    Rigidbody2D rigBody;
    Animator animator;
    // Start is called before the first frame update
    //AnimationClip animation_main;
    public float x;
    private float timelostW, timelostA, timelostS, timelostD, timelostX, timelostC, timelosta;
    private float timeslot;
    private string keyDowm;
    private Vector3 mouseXY;
    AnimatorStateInfo stateinfo;

    void Start()
    {
        rigBody =GetComponent<Rigidbody2D>();
        animator = GameObject.Find("role").GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (!animator.GetBool("isDeath"))
        {
            isRunFn();
        }
       
    }
    //物理移动
    private void FixedUpdate()
    {
        //如果没死
        if (!animator.GetBool("isDeath"))
           // || animator.GetFloat("byatk") < 1f
        {
            //如果没被攻击
            if(animator.GetInteger("byatk") < 1)
            {
                playMoveFn();
            }

        }
        else
        {
            Debug.Log("我死亡了，或者正在被攻击");
        }
    }
    //管理人物的移动平移
    void playMoveFn()
    {
        Vector3 thisScale = this.transform.localScale;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //获取鼠标的坐标
        // Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        // //屏幕坐标转化成世界坐标
        // Vector3 pos = Camera.main.ScreenToWorldPoint(m_MousePos);
        // thisScale.x = pos.x < transform.position.x ? Math.Abs(thisScale.x) * -1 : Math.Abs(thisScale.x);
        // transform.localScale = thisScale;

        //切换方向
        if (moveX != 0)
        {
            thisScale.x = Math.Abs(thisScale.x) * moveX;
            transform.localScale = thisScale;
        }
        movePlay = new Vector2(moveX, moveY);
        //位移
        Vector2 position = rigBody.position;

        position += movePlay * speed * Time.deltaTime;

        //判断动画QSkill是否正在播放
        stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        position += animator.GetBool("isRun") || stateinfo.IsName("run") ? movePlay * speed * Time.deltaTime * 4 : movePlay * speed * Time.deltaTime;
        rigBody.MovePosition(position);
        animator.SetFloat("speed", movePlay.magnitude);
    }
    //动画函数，用于管理人物移动的动画
    void isRunFn()
    {
        //移动

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           // Debug.Log("执行了上");
            if (Time.time - timelostW < 0.5f)///0.5秒之内按下有效
           {
             //   Debug.Log("执行了双上");
               animator.SetBool("isRun", true);
           }
           else
            {
                animator.SetBool("isRun", false);
            }
            timelostW = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Time.time - timelostA < 0.5f)///0.5秒之内按下有效
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }
            timelostA = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Time.time - timelostS < 0.5f)///0.5秒之内按下有效
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }
            timelostS = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Time.time - timelostD < 0.5f)///0.5秒之内按下有效
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }
            timelostD = Time.time;
        }
        //设置跳跃
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Time.time - timelostX < 0.8f)///0.5秒之内按下有效
            {
                return;
            }
            else
            {
                //查看对话框的显示状态
                if (GameObject.Find("Canvas").transform.Find("talkToNpc").gameObject.activeSelf)
                {
                    GameObject.Find("Canvas").transform.Find("talkToNpc").gameObject.SetActive(false);
                }
                else
                {
                    animator.SetBool("isJump", true);
                }
            }
            timelostX = Time.time;
        }
        //判断是否在城镇里面
        if (GameObject.Find("backgound").GetComponent<maps>().isCity)

        {
          
            //攻击
           if (Input.GetKeyDown(KeyCode.C))
           {
                //查看对话框的显示状态
                if (GameObject.Find("Canvas").transform.Find("talkToNpc").gameObject.activeSelf)
                {
                    GameObject.Find("Canvas").transform.Find("talkToNpc").gameObject.SetActive(false);
                }
                else
                {
                    RaycastHit2D hit = Physics2D.Raycast(rigBody.position, movePlay, 2f, LayerMask.GetMask("npc"));
                    if (hit.collider != null)
                    {
                        Debug.Log("撞到npc了");
                        hit.transform.GetComponent<talk>().open();
                    }
                }
              
           }
        }
        else
        {
            //攻击
            if (Input.GetKeyDown(KeyCode.C))
            {
                //设置攻击间隔
                if (Time.time - timelostC < 0.5f)
                {
                    return;

                }
                else
                {//设置普通攻击,先检查有没有触发捡东西，没有就普攻
                    if (!isGoodsTrigger)
                    {
                        transform.GetChild(1).GetComponent<jump>().keyBoard=0;
                        animator.SetBool("ispuGong", true);
                        animator.SetBool("isTruePugong", true);
                    }

                }
                timelostC = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Transform skill1 = GameObject.Find("Canvas").transform.Find("战斗中下边框").Find("技能").Find("药物栏1");
                if (Time.time - timelosta < 5f)///0.5秒之内按下有效
                {
                    GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "小伙子，你的黄金龙卷冷却时间还没结束哦，偶尔使用一下普通攻击可以使攻击更加连贯");
                   
                    return;
                }
                else
                {
                    animator.SetBool("ispuGong", true);
                    transform.GetChild(1).GetComponent<jump>().keyBoard = 1;
                    GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "你使用了黄金龙卷");
                    skill1.GetComponent<skillbox>().startTime(5f);
                    timelosta = Time.time;



                }
               
            }
        }
       
    }

}
