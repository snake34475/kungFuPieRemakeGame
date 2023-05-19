using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maps : MonoBehaviour
{
    public Sprite map1;
    public Sprite map2;

    private SpriteRenderer img;
    // ����ͼƬ�Ŀ��
    private float bgWidth;
    public SpriteRenderer bgBounds;
    // ����ͼƬ�Ŀ��
    private float bgHeight;
    private Vector2 position;
    public bool isCity = true;
    // Start is called before the first frame update
    void Start()
    {
        bgBounds = this.transform.GetComponent<SpriteRenderer>();
        position = this.transform.position;
        bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;
        // ��ȡ����ͼƬ���
        bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
        switch (this.gameObject.scene.name)
        {
            case "������-1":
                isCity = false;
                //��λ
                position.x = position.x - bgWidth / 2 ;
                position.y = position.y - 2;
                GameObject.Find("play").transform.position = position;
                checkSkillBox();
                break;
            case "������-2":
                isCity = false;
                //��λ
                position.x = position.x - bgWidth / 2+1;
                position.y = position.y - 2;
                GameObject.Find("play").transform.position = position;
                checkSkillBox();
                break;
            case "�������":
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
                if (GameObject.FindGameObjectsWithTag("����").Length == 0 || GameObject.FindGameObjectsWithTag("����") == null)
                {
                    item.gameObject.SetActive(true);
                    if(gameObject.scene.name== "������ - 2")
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
    //�л���ͼʹ�õ��ظ�����
    void checkSkillBox()
    {
        if (isCity)
        {
            GameObject.Find("Canvas").transform.Find("ս�����±߿�").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("�±߿�").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("�ؿ�����").gameObject.SetActive(false);

        }
        else
        {
            GameObject.Find("Canvas").transform.Find("ս�����±߿�").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("�±߿�").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("�ؿ�����").gameObject.SetActive(true);
        }
        emptyAtkImg();
    }
    //��չ�����Ļ
    void emptyAtkImg()
    {
        Destroy(GameObject.Find("�չ�"));
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
