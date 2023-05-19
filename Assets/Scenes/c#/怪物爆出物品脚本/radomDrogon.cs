using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class radomDrogon : MonoBehaviour
{
    public ArrayList longzhu =new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        longzhu.Add("金熊珠");
        longzhu.Add("木熊珠");
        longzhu.Add("水熊珠");
        longzhu.Add("火熊珠");
        longzhu.Add("土熊珠");
        longzhu.Add("风熊珠");
        //随机
        System.Random rd = new System.Random();
        int index = rd.Next(0, longzhu.Count) ;
        transform.name =(string) longzhu[index];

        transform.GetComponent<SpriteRenderer>().sprite= Resources.Load("物品/材料/" + transform.name + "", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
