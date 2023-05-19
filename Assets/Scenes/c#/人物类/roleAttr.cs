using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roleAttr : MonoBehaviour
{
    public GameObject expTextObj;
    public int lv = 1;//�ȼ�
    public float cur_exp=0;//��ǰ����
    public float pre_exp = 100;//������
    public int pre_hp = 200;//����
    public int cur_hp = 200;//����
    public int pre_mp = 50;//����
    public int cur_mp = 50;//����
    public int atk = 20;//����
    public int dt = 5;//����
    public int baoJi = 0;//����
    public int baoAtk = 1;//����
    public int dodge = 0;//����
    public int hit = 0;//����
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
        attrPlaneObj = GameObject.Find("�������").transform;
        ExpVue();
        attrPlaneFn();
    }

    // Update is called once per frame
    void Update()
    {
        //�������
        ExpVue();
        //�������
        attrPlaneFn();
        //�ж��Ƿ�������������
        upLv();
        //Ѫ���ͷ��������ı�
        changeHpMp();
        //�ȼ�
        changeLv();
        //�ݴ澭��ֵ

       
    }
    //��Ѫ
    public void upHpFn1(int addhp, float upHpTime)
    {
        StartCoroutine(Timer( addhp, upHpTime)); // ��ʼЭͬ����
    }
    IEnumerator Timer(int addhp, float upHpTime)
    {
        while (upHpTime > 0)
        {
            //��Ҫ�ظ�ִ�еĴ���ͷ����ڴ˴�
            if (cur_hp < pre_hp)
            {
                upHpFn(addhp);
                upHpTime -= 2f;
                yield return new WaitForSeconds(0.5f); // ִֹͣ��1��
            }
            else
            {
                cur_hp = pre_hp;
                upHpTime = 0;
            }


        }
    }
    //Ѫ������
    public void upHpFn(int addhp)
    {
                cur_hp += addhp;
                atkText("+", addhp);
    }
    //����������ͼ
    private void ExpVue()
    {
        if (cur_exp < 0) cur_exp = 0;
        expObj.transform.GetComponent<Image>().fillAmount = cur_exp /pre_exp;
    }
    //�������
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
        //���Ͻ�״̬
        GameObject mpk= GameObject.Find("������");
        GameObject hpk= GameObject.Find("Ѫ����");
        mpk.transform.GetChild(0).transform.GetComponent<Image>().fillAmount = (float)cur_mp / (float)pre_mp;
        mpk.transform.GetChild(1).transform.GetComponent<Text>().text = ""+cur_mp+""+"/"+ ""+(float)pre_mp+"";
        hpk.transform.GetChild(0).transform.GetComponent<Image>().fillAmount = (float)cur_hp / (float)pre_hp;
        hpk.transform.GetChild(1).transform.GetComponent<Text>().text = "" + cur_hp + "" + "/" + "" + (float)pre_hp + "";
        //����ͷ��״̬
        GameObject mpt = GameObject.Find("����").transform.Find("����").gameObject;
        GameObject hpt = GameObject.Find("����").transform.Find("Ѫ��").gameObject;
        mpt.transform.transform.GetComponent<Image>().fillAmount = (float)cur_mp / (float)pre_mp;
        hpt.transform.transform.GetComponent<Image>().fillAmount = (float)cur_hp / (float)pre_hp;
    }
    private void changeLv()
    {
         GameObject.Find("roleLv").transform.Find("�ȼ�").GetComponent<Text>().text=""+lv+"";
    }
    public void expAdd(int value)
    {
        GameObject expText = Instantiate(expTextObj, new Vector2(300, -170), Quaternion.Euler(new Vector3(0, 0, 0)));
        expText.transform.SetParent(GameObject.Find("Canvas").transform);
        expText.transform.localPosition = new Vector3(300, -170,0);
        expText.transform.GetChild(0).GetComponent<Text>().text = ""+value+"";
        cur_exp += value;
    }
    //�ܵ��˺�
    public void underAtk(int atk_fn)
    {
        //Debug.Log("��ǰ" + cur_hp);
        //�ܵ����˺���ȥ����ֵ������ȡ0.8��12�ı��ʽ��м���
        int value = (int)System.Math.Floor((atk_fn - dt) * new System.Random().Next(8, 12) * 0.1f);

        cur_hp -= value;
        atkText("-", value);
        //Vector3 textpos = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        //GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        //byatk.transform.SetParent(transform);
        //byatk.transform.GetChild(0).GetComponent<Text>().text = "-" + value + "";

        //Debug.Log("֮��" + cur_hp);
        //�ܻ�״̬
        transform.GetComponent<Animator>().SetInteger("byatk", value);
        Invoke("byatkReset", 1);
        //����һ��Ѫ��
        changeHpMp();
        //�ж�������ô
        roleDeath();
    }
    void atkText(string iszero,int value )
    {
        Vector3 textpos = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        GameObject byatk = Instantiate(textbyAtk, textpos, Quaternion.Euler(new Vector3(0, 0, 0)));
        byatk.transform.SetParent(transform);
        byatk.transform.GetChild(0).GetComponent<Text>().text = iszero + value + "";
    }
    //��������
    void byatkReset()
    {
        transform.GetComponent<Animator>().SetInteger("byatk", 0);
    }
    //��������
    public void roleDeath()
    {
        //����
        if (cur_hp <= 0)
        {
            transform.GetComponent<Animator>().SetBool("isDeath",true);//������������
            talkTransfrom.localPosition = new Vector3(talkTransfrom.localPosition.x, 130, talkTransfrom.localPosition.z);
            talkTransfrom.GetComponent<Image>().color = new Vector4(1,1,1,0.8f);

            talkTransfrom.gameObject.SetActive(true);
            if (talkTransfrom)
            {
                talkTransfrom.Find("ok").Find("Text").GetComponent<Text>().text = "��Ҫһѩǰ�ܣ�����";
                talkTransfrom.Find("cancel").Find("Text").GetComponent<Text>().text = "���˰ɣ���Ҫ�˳�";
                talkTransfrom.Find("content").GetComponent<Text>().text = "С��ʿ�����Ѿ��������Ƿ��������֮������";
            }
        }
    }
    private void upLv()
    {
        //�Ƿ�������������
        if (cur_exp >= pre_exp)
        {
            //���ֵ
            float xd = cur_exp - pre_exp;
            //��������
            lv +=1;
            pre_hp += 200;//����
            pre_mp+= 50;//����
            atk += 10;//����
            dt += 10;//����
            baoJi += 2;//����
            baoAtk = 10;//����
            dodge = 0;//����
            hit = 0;//����
            pre_exp *= 1.2f;
            cur_exp = xd;

            //��������Ѫ��
            hpMpReset();
        }
    }
 
}
