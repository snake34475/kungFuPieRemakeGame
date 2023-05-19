using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class PlayData
{
    public roleAttrData attr=new roleAttrData();
    public List<goods> backGround = new List<goods>();
}
[System.Serializable]
public class roleAttrData
{
    public int lv ;//�ȼ�
    public float cur_exp;//��ǰ����
    public float pre_exp ;//������
    public int pre_hp ;//����
    public int cur_hp ;//����
    public int pre_mp;//����
    public int cur_mp;//����
    public int atk ;//����
    public int dt ;//����
    public int baoJi ;//����
    public int baoAtk ;//����
    public int dodge ;//����
    public int hit ;//����
}

[System.Serializable]
public class goods
{
    public int num;
    public string name;
}
public class SaveData
{
    public PlayData playdata = new PlayData();
    roleAttr attr = GameObject.Find("role").GetComponent<roleAttr>();
    Transform bkTranform = GameObject.Find("������").transform;
    //�浵
    public void saveData()
    {
         savePlayAttr();
        saveBackGround();
        Debug.Log("roleAttr"+ playdata.attr.pre_exp);
        string Json = JsonUtility.ToJson(playdata, true);
        string filepath = Application.streamingAssetsPath + "/playAttrList.json";
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(Json);
            sw.Close();
            sw.Dispose();
        }
    }
    //����
    public void loadData()
    {
        string Json;
        string filepath = Application.streamingAssetsPath + "/playAttrList.json";

        if(File.Exists(Application.streamingAssetsPath + "/playAttrList.json"))
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                Json = sr.ReadToEnd();
                sr.Close();
            }
            playdata = JsonUtility.FromJson<PlayData>(Json);
            loadPlayAttr();
            loadBackGround();
        }
        else
        {
            Debug.Log("û�д浵");
        }

       
    }

    //����������
    public void savePlayAttr()
    {
            playdata.attr.lv = attr.lv;//�ȼ�
            playdata.attr.cur_exp = attr.cur_exp;//��ǰ����
            playdata.attr.pre_exp = attr.pre_exp;//������
            playdata.attr.pre_hp = attr.pre_hp;//����
            playdata.attr.cur_hp = attr.cur_hp;//����
            playdata.attr.pre_mp = attr.pre_mp;//����
            playdata.attr.cur_mp = attr.cur_mp;//����
            playdata.attr.atk = attr.atk;//����
            playdata.attr.dt = attr.dt;//����
            playdata.attr.baoJi = attr.baoJi;//����
            playdata.attr.baoAtk = attr.baoAtk;//����
            playdata.attr.dodge = attr.dodge;//����
            playdata.attr.hit = attr.hit;//����
    }
    //����������
    public void loadPlayAttr()
    {
        attr.lv = playdata.attr.lv;
        attr.cur_exp = playdata.attr.cur_exp;
        attr.pre_exp = playdata.attr.pre_exp;
        attr.pre_hp = playdata.attr.pre_hp;
        attr.cur_hp = playdata.attr.cur_hp;
        attr.pre_mp = playdata.attr.pre_mp;
        attr.cur_mp = playdata.attr.cur_mp;
        attr.atk=playdata.attr.atk;
        attr.dt=playdata.attr.dt;
        attr.baoJi=playdata.attr.baoJi;
        attr.baoAtk = playdata.attr.baoAtk;
        attr.dodge = playdata.attr.dodge;
        attr.hit = playdata.attr.hit;
    }
    public void saveBackGround()
    {

        foreach (Transform child in bkTranform)
        {
            if (child.GetComponent<backItem>().name != "" && child.GetComponent<backItem>().num > 0)
            {
                goods goodOne = new goods();
                goodOne.name = child.GetComponent<backItem>().name;
                goodOne.num = child.GetComponent<backItem>().num;
                playdata.backGround.Add(goodOne);
            }
        }
    }
    public void loadBackGround()
    {
        bkTranform.GetComponent<background>().getBackGroundData(playdata.backGround);
    }

}