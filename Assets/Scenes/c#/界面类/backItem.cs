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
    /// 对外，提供一个num和type，name，图片路径和子节点单项绑定
    /// 对内
    /// 自己判断下限和隐藏
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //数目为0隐藏

    }
    // Update is called once per frame
    void Update()
    {
        //更新图片
        changeImage();
        //数字部分
        changeNum();

        isHpMp();

    }
    private void changeNum()
    {
        //数字临界
        Text text = transform.Find("num").GetComponent<Text>();
        if (num <= 1)
        {
            //字体透明度为零
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
        transform.Find("Image").transform.GetComponent<Image>().sprite = Resources.Load("物品/材料/"+ name + "", typeof(Sprite)) as Sprite;
        transform.Find("Image").transform.GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
       transform.Find("Image").transform.localScale = new Vector3(0.175f, 0.175f, 1);
        transform.Find("Image").GetComponent<RectTransform>();
    }
    private void isHpMp()
    {
        if (name == "百草丸")
        {
            GameObject.Find("Canvas").transform.Find("战斗中下边框").Find("药物").GetChild(0).Find("数量").transform.GetComponent<Text>().text = "" + num + "";
            GameObject.Find("Canvas").transform.Find("战斗中下边框").Find("药物").GetChild(0).Find("图片").transform.GetComponent<Image>().sprite = Resources.Load("物品/材料/" + name + "", typeof(Sprite)) as Sprite;

        }
    }
}
