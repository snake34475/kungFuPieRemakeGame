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
        longzhu.Add("������");
        longzhu.Add("ľ����");
        longzhu.Add("ˮ����");
        longzhu.Add("������");
        longzhu.Add("������");
        longzhu.Add("������");
        //���
        System.Random rd = new System.Random();
        int index = rd.Next(0, longzhu.Count) ;
        transform.name =(string) longzhu[index];

        transform.GetComponent<SpriteRenderer>().sprite= Resources.Load("��Ʒ/����/" + transform.name + "", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
