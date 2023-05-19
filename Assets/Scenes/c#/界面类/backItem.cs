using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backItem : MonoBehaviour
{
    public new string name;
    public string type;
    public int num=0;
    /// <summary>
    /// ���⣬�ṩһ��num��type��name��ͼƬ·�����ӽڵ㵥���
    /// ����
    /// �Լ��ж����޺�����
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //��ĿΪ0����

    }
    // Update is called once per frame
    void Update()
    {
        //����ͼƬ
        changeImage();
        //���ֲ���
        changeNum();

        isHpMp();

    }
    private void changeNum()
    {
        //�����ٽ�
        Text text = transform.Find("num").GetComponent<Text>();
        if (num <= 1)
        {
            //����͸����Ϊ��
            this.transform.Find("num").GetComponent<Text>().color = new Vector4(text.color.r, text.color.g, text.color.b, 0);
            //Debug.Log("num" + num);
            if (num == 0)
            {
                
                Image image = this.transform.Find("Image").GetComponent<Image>();
                this.transform.Find("Image").GetComponent<Image>().color = new Vector4(image.color.r, image.color.g, image.color.b, 0);
                this.transform.Find("Image").GetComponent<Image>().sprite =null;
            }
        }
        else
        {
            this.transform.Find("num").GetComponent<Text>().color = new Vector4(text.color.r, text.color.g, text.color.b, 255);
        }
        this.transform.Find("num").GetComponent<Text>().text = "" + this.num + "";
    }
    private void changeImage()
    {
        transform.Find("Image").transform.GetComponent<Image>().sprite = Resources.Load("��Ʒ/����/"+ name + "", typeof(Sprite)) as Sprite;
        transform.Find("Image").transform.GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
       transform.Find("Image").transform.localScale = new Vector3(0.175f, 0.175f, 1);
        transform.Find("Image").GetComponent<RectTransform>();
    }
    private void isHpMp()
    {
        if (name == "�ٲ���")
        {
            GameObject.Find("Canvas").transform.Find("ս�����±߿�").Find("ҩ��").GetChild(0).Find("����").transform.GetComponent<Text>().text = "" + num + "";
            GameObject.Find("Canvas").transform.Find("ս�����±߿�").Find("ҩ��").GetChild(0).Find("ͼƬ").transform.GetComponent<Image>().sprite = Resources.Load("��Ʒ/����/" + name + "", typeof(Sprite)) as Sprite;

        }
    }
}
