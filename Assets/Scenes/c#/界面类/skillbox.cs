using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class skillbox : MonoBehaviour
{
    private string keydownValue;
    private float timer=0;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {

        imgPlay();
        if (transform.parent.name == "����" || !transform.Find("ͼƬ").GetComponent<Image>().sprite)
        {
            transform.Find("����").GetComponent<Text>().text = null;
        }
        //��ռ��ܼ�ʱ
        transform.Find("����").GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //onkeyValue();
        SkilltimeOut();
        //��ȴ��ʱ���
        timer -= Time.deltaTime;
        transform.Find("����").GetComponent<Image>().fillAmount = timer/time;
        if (timer <= 0) transform.Find("����").GetComponent<Image>().fillAmount = 0;
        //ͼ��
        imgPlay();
    }
    //�������µİ���
     private string onkeyValue()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    return keyCode.ToString();
                }
            }
        }
        return null;
    }
    private void imgPlay()
    {
        if (transform.Find("ͼƬ").GetComponent<Image>().sprite)
        {
            transform.Find("ͼƬ").GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
        }
        else
        {
            transform.Find("ͼƬ").GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        }

    }
    //���赹��ʱ
    public void startTime(float num)
    {
        //����ȴʱ��
        timer = num;
        time = timer;
        transform.Find("����").GetComponent<Image>().fillAmount = 1;
    }
    //��ȴ��ʱ
    private void SkilltimeOut()
    {
       // Debug.Log(onkeyValue());
       
        if (onkeyValue() =="Alpha" + transform.Find("����").GetComponent<Text>().text)
        {
            Debug.Log("onkeyValue()"+onkeyValue());
            //�������ȴʱ�����ֵ����
            if (timer >= 0) {
                //Debug.Log("���ֵ����һ��");
                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "С��ʿ��Ƶ��ʹ��ҩƷ���������壬ע����ƣ��������԰�");
                return;
            } 

            //ʹ��ҩƷ��ʱ���ڱ����������һ��
            if(transform.parent.name == "ҩ��")
            {
                foreach(Transform child in GameObject.Find("Canvas").transform.Find("����").Find("������").transform)
                {
                    if(child.GetComponent<backItem>().name == "�ٲ���")
                    {
                        if (child.GetComponent<backItem>().num <= 0) {
                            GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "С��ʿ�����ҩƷ����Ŷ����ȥ�ռ�ҩƷ��");
                        }
                        else
                        {
                            Transform role = GameObject.Find("role").transform;
                            if (role.GetComponent<roleAttr>().getCur_hp() >= role.GetComponent<roleAttr>().getPre_hp()) {
                                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "���״̬�ܽ���������Ҫ�ظ�");
                            }
                            else
                            {
                                startTime(5);
                                child.GetComponent<backItem>().num -= 1;
                                role.GetComponent<roleAttr>().upHpFn1(20, 10);
                                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "��ʹ���˰ٲ��裬�����ָ�����");
                            }
                           

                        }
               
                    }
                }
            }

        }
    }
}
