using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maps : MonoBehaviour
{
    public Sprite map1;
    public Sprite map2;

    private SpriteRenderer img;
    // 背景图片的宽度
    private float bgWidth;
    public SpriteRenderer bgBounds;
    // 背景图片的宽度
    private float bgHeight;
    private Vector2 position;
    public bool isCity = true;
    // Start is called before the first frame update
    void Start()
    {
        bgBounds = this.transform.GetComponent<SpriteRenderer>();
        position = this.transform.position;
        bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;
        // 获取背景图片宽度
        bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
        switch (this.gameObject.scene.name)
        {
            case "机关巷-1":
                isCity = false;
                //定位
                position.x = position.x - bgWidth / 2 ;
                position.y = position.y - 2;
                GameObject.Find("play").transform.position = position;
                checkSkillBox();
                break;
            case "机关巷-2":
                isCity = false;
                //定位
                position.x = position.x - bgWidth / 2+1;
                position.y = position.y - 2;
                GameObject.Find("play").transform.position = position;
                checkSkillBox();
                break;
            case "功夫城西":
                isCity = true;
                position.x = position.x - bgWidth / 2 + 1;
                position.y = position.y - 2;
                GameObject.Find("play").transform.position = position;
                checkSkillBox();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

        foreach (Transform item in GameObject.Find("backgound").transform)
        {
            if (item.tag == "tranform")
            {
                if (GameObject.FindGameObjectsWithTag("怪物").Length == 0 || GameObject.FindGameObjectsWithTag("怪物") == null)
                {
                    item.gameObject.SetActive(true);
                    if(gameObject.scene.name== "机关巷 - 2")
                    {

                    }
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
            
    }
    //切换地图使用的重复代码
    void checkSkillBox()
    {
        if (isCity)
        {
            GameObject.Find("Canvas").transform.Find("战斗中下边框").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("下边框").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("关卡弹框").gameObject.SetActive(false);

        }
        else
        {
            GameObject.Find("Canvas").transform.Find("战斗中下边框").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("下边框").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("关卡弹框").gameObject.SetActive(true);
        }
        emptyAtkImg();
    }
    //清空攻击弹幕
    void emptyAtkImg()
    {
        Destroy(GameObject.Find("普攻"));
    }
    public void setMaps(int num)
    {
       // switch (num)
       // {
       //     case 1:
       //         img.sprite = map1;
       //         break;
       //     case 2:
       //         img.sprite = map2;
       //         break;
       //     default:
       //         break;
       // }
    }
}
