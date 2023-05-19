using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhangai : MonoBehaviour
{
    public GameObject longZhu;
    private bool isDeath = false;
    public int maxHp = 1;
    public int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }
    public void underAtk(int atk)
    {
        currentHp -= atk;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Vector4 ZhangAaiColor = transform.GetComponent<SpriteRenderer>().color;
            ZhangAaiColor.w = ZhangAaiColor.w > 0 ? ZhangAaiColor.w - Time.deltaTime * 1 : 0;
            if (ZhangAaiColor.w <= 0) {
                Destroy(gameObject, 0);//两秒之后删除他;
                if (isDeath == false)
                {
                    Instantiate(longZhu, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                isDeath = true;
            }
            transform.GetComponent<SpriteRenderer>().color = ZhangAaiColor;


        }
    }
}
