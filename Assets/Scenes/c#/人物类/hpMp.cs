using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class hpMp : MonoBehaviour
{
    Vector3 scale;
    public Image hp;
    public Image Mp;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ִ����");
        hp = this.transform.Find("Ѫ��").GetComponent<Image>();
        Mp = this.transform.Find("����").GetComponent<Image>();
    }
    public void updataHp(float curAmount, float amount)
    {
        hp.fillAmount = (float)curAmount / (float)amount;
    }
    public void updataMp(float curAmount, float amount)
    {
        Mp.fillAmount = (float)curAmount / (float)amount;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
