using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roleAttr : MonoBehaviour
{
    public GameObject expTextObj;
    public int lv = 1;//等级
    public float cur_exp=0;//当前经验
    public float pre_exp = 100;//经验条
    public int pre_hp = 200;//生命
    public int cur_hp = 200;//生命
    public int pre_mp = 50;//法力
    public int cur_mp = 50;//法力
    public int atk = 20;//攻击
    public int dt = 5;//防御
    public int baoJi = 0;//暴击
    public int baoAtk = 1;//爆伤
    public int dodge = 0;//闪避
    public int hit = 0;//命中
    public GameObject textbyAtk;
    public Transform talkTransfrom;
    // Start is called before the first frame update
    private float timerdo;
    public int getLv()
    {
        return lv;
    }
    public int getAtk()
    {
        return atk;
    }
    public int getDt()
    {
        return dt;
    }
    public int getBaoJi()
    {
        return baoJi;
    }
    public int getBaoAtk()
    {
        return baoAtk;
    }
    public int getDodge()
    {
        return dodge;
;
    }
    public int getHit()
    {
        return hit;
    }
    public int getCur_hp()
    {
        return cur_hp;
    }
    public int getPre_hp()
    {
        return pre_hp;
    }

    public void hpMpReset()
    {
        cur_hp = pre_hp;
        cur_mp = pre_mp;
    }
    private Transform expObj;
    private Transform attrPlaneObj;
    void Start()
    {
        expObj = GameObject.Find("exp_value").transform;
        attrPlaneObj = GameObject.Find("属性面板").transform;
        ExpVue();
        attrPlaneFn();
    }

    // Update is called once per frame
    void Update()
    {
        //经验面板
        ExpVue();
        //属性面板
        attrPlaneFn();
        //判断是否满足升级条件
        upLv();
        //血量和法力发生改变
        changeHpMp();
        //等级
        changeLv();
        //暂存经验值

       
    }
    //加血
    public void upHpFn1(int addhp, float upHpTime)
    {
        StartCoroutine(Timer( addhp, upHpTime)); // 开始协同程序
    }
    IEnumerator Timer(int addhp, float upHpTime)
    {
        while (upHpTime > 0)
        {
            //需要重复执行的代码就放于在此处
            if (cur_hp < pre_hp)
            {
                upHpFn(addhp);
                upHpTime -= 2f;
                yield return new WaitForSeconds(0.5f); // 停止执行1秒
            }
            else
            {
                cur_hp = pre_hp;
                upHpTime = 0;
            }


        }
    }
    //血量提升
    public void upHpFn(int addhp)
    {
                cur_hp += addhp;
                atkText("+", addhp);
    }
    //经验条的视图
    private void ExpVue()
    {
        if (cur_exp < 0) cur_exp = 0;
        expObj.transform.GetComponent<Image>().fillAmount = cur_exp /pre_exp;
    }
    //人物面板
    private void attrPlaneFn()
    {
        attrPlaneObj.GetChild(0).GetComponent<InputField>().text =""+baoAtk+"";
        attrPlaneObj.GetChild(1).GetComponent<InputField>().text = "" + dodge + "";
        attrPlaneObj.GetChild(2).GetComponent<InputField>().text = "" + dt + "";
        attrPlaneObj.GetChild(3).GetComponent<InputField>().text = "" + pre_mp + "";
        attrPlaneObj.GetChild(4).GetComponent<InputField>().text = "" + baoJi + "";
        attrPlaneObj.GetChild(5).GetComponent<InputField>().text = "" + hit + "";
        attrPlaneObj.GetChild(6).GetComponent<InputField>().text = "" + atk + "";
        attrPlaneObj.GetChild(7).GetComponent<InputField>().text = "" + pre_hp + "";
                             
    }
    private void changeHpMp()
    {
        //左上角状态
        GameObject mpk= GameObject.Find("法力框");
        GameObject hpk= GameObject.Find("血条框");
        mpk.transform.GetChild(0).transform.GetComponent<Image>().fillAmount = (float)cur_mp / (float)pre_mp;
        mpk.transform.GetChild(1).transform.GetComponent<Text>().text = ""+cur_mp+""+"/"+ ""+(float)pre_mp+"";
        hpk.transform.GetChild(0).transform.GetComponent<Image>().fillAmount = (float)cur_hp / (float)pre_hp;
        hpk.transform.GetChild(1).transform.GetComponent<Text>().text = "" + cur_hp + "" + "/" + "" + (float)pre_hp + "";
        //人物头上状态
        GameObject mpt = GameObject.Find("画布").transform.Find("蓝条").gameObject;
        GameObject hpt = GameObject.Find("画布").transform.Find("血条").gameObject;
        mpt.transform.transform.GetComponent<Image>().fillAmount = (float)cur_mp / (float)pre_mp;
        hpt.transform.transform.GetComponent<Image>().fillAmount = (float)cur_hp / (float)pre_hp;
    }
    private void changeLv()
    {
         GameObject.Find("roleLv").transform.Find("等级").GetComponent<Text>().text=""+lv+"";
    }
    public void expAdd(int value)
    {
        GameObject expText = Instantiate(expTextObj, new Vector2(300, -170), Quaternion.Euler(new Vector3(0, 0, 0)));
        expText.transform.SetParent(GameObject.Find("Canvas").transform);
        expText.transform.localPosition = new Vector3(300, -170,0);
        expText.transform.GetChild(0).GetComponent<Text>().text = ""+value+"";
        cur_exp += value;
    }
    //受到伤害
    public void underAtk(int atk_fn)
    {
        //Debug.Log("当前" + cur_hp);
        //受到的伤害减去防御值，并且取0.8到12的倍率进行计算
        int value = (int)System.Math.Floor((atk_fn - dt) * new System.Random().Next(8, 12) * 0.1f);

        cur_hp -= value;
        atkText("-", value);
        //Vector3 textpos = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        //GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        //byatk.transform.SetParent(transform);
        //byatk.transform.GetChild(0).GetComponent<Text>().text = "-" + value + "";

        //Debug.Log("之后" + cur_hp);
        //受击状态
        transform.GetComponent<Animator>().SetInteger("byatk", value);
        Invoke("byatkReset", 1);
        //更新一下血量
        changeHpMp();
        //判断死亡了么
        roleDeath();
    }
    void atkText(string iszero,int value )
    {
        Vector3 textpos = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        byatk.transform.SetParent(transform);
        byatk.transform.GetChild(0).GetComponent<Text>().text = iszero + value + "";
    }
    //攻击重置
    void byatkReset()
    {
        transform.GetComponent<Animator>().SetInteger("byatk", 0);
    }
    //人物死亡
    public void roleDeath()
    {
        //死亡
        if (cur_hp <= 0)
        {
            transform.GetComponent<Animator>().SetBool("isDeath",true);//播放死亡动画
            talkTransfrom.localPosition = new Vector3(talkTransfrom.localPosition.x, 130, talkTransfrom.localPosition.z);
            talkTransfrom.GetComponent<Image>().color = new Vector4(1,1,1,0.8f);

            talkTransfrom.gameObject.SetActive(true);
            if (talkTransfrom)
            {
                talkTransfrom.Find("ok").Find("Text").GetComponent<Text>().text = "我要一雪前耻，复活";
                talkTransfrom.Find("cancel").Find("Text").GetComponent<Text>().text = "算了吧，我要退出";
                talkTransfrom.Find("content").GetComponent<Text>().text = "小侠士，你已经阵亡，是否借用天神之力复活";
            }
        }
    }
    private void upLv()
    {
        //是否满足升级条件
        if (cur_exp >= pre_exp)
        {
            //存差值
            float xd = cur_exp - pre_exp;
            //属性提升
            lv +=1;
            pre_hp += 200;//生命
            pre_mp+= 50;//法力
            atk += 10;//攻击
            dt += 10;//防御
            baoJi += 2;//暴击
            baoAtk = 10;//爆伤
            dodge = 0;//闪避
            hit = 0;//命中
            pre_exp *= 1.2f;
            cur_exp = xd;

            //升级回满血量
            hpMpReset();
        }
    }
 
}
