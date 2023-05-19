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
        if (transform.parent.name == "技能" || !transform.Find("图片").GetComponent<Image>().sprite)
        {
            transform.Find("数量").GetComponent<Text>().text = null;
        }
        //清空技能计时
        transform.Find("遮罩").GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //onkeyValue();
        SkilltimeOut();
        //冷却计时情况
        timer -= Time.deltaTime;
        transform.Find("遮罩").GetComponent<Image>().fillAmount = timer/time;
        if (timer <= 0) transform.Find("遮罩").GetComponent<Image>().fillAmount = 0;
        //图层
        imgPlay();
    }
    //监听按下的按键
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
        if (transform.Find("图片").GetComponent<Image>().sprite)
        {
            transform.Find("图片").GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
        }
        else
        {
            transform.Find("图片").GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        }

    }
    //赋予倒计时
    public void startTime(float num)
    {
        //赋冷却时间
        timer = num;
        time = timer;
        transform.Find("遮罩").GetComponent<Image>().fillAmount = 1;
    }
    //冷却计时
    private void SkilltimeOut()
    {
       // Debug.Log(onkeyValue());
       
        if (onkeyValue() =="Alpha" + transform.Find("按键").GetComponent<Text>().text)
        {
            Debug.Log("onkeyValue()"+onkeyValue());
            //如果在冷却时间内又点击了
            if (timer >= 0) {
                //Debug.Log("你又点击了一次");
                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "小侠士，频繁使用药品容易伤身体，注意节制，等下再试吧");
                return;
            } 

            //使用药品的时候，在背包里面更新一次
            if(transform.parent.name == "药物")
            {
                foreach(Transform child in GameObject.Find("Canvas").transform.Find("背包").Find("背包父").transform)
                {
                    if(child.GetComponent<backItem>().name == "百草丸")
                    {
                        if (child.GetComponent<backItem>().num <= 0) {
                            GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "小侠士，你的药品不够哦，快去收集药品吧");
                        }
                        else
                        {
                            Transform role = GameObject.Find("role").transform;
                            if (role.GetComponent<roleAttr>().getCur_hp() >= role.GetComponent<roleAttr>().getPre_hp()) {
                                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "你的状态很健康，不需要回复");
                            }
                            else
                            {
                                startTime(5);
                                child.GetComponent<backItem>().num -= 1;
                                role.GetComponent<roleAttr>().upHpFn1(20, 10);
                                GameObject.Find("Canvas").transform.Find("Text").GetComponent<textget>().setSkillTime(true, "你使用了百草丸，持续恢复生命");
                            }
                           

                        }
               
                    }
                }
            }

        }
    }
}
