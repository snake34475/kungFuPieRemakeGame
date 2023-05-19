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
    public int lv ;//等级
    public float cur_exp;//当前经验
    public float pre_exp ;//经验条
    public int pre_hp ;//生命
    public int cur_hp ;//生命
    public int pre_mp;//法力
    public int cur_mp;//法力
    public int atk ;//攻击
    public int dt ;//防御
    public int baoJi ;//暴击
    public int baoAtk ;//爆伤
    public int dodge ;//闪避
    public int hit ;//命中
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
    Transform bkTranform = GameObject.Find("背包父").transform;
    //存档
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
    //读档
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
            Debug.Log("没有存档");
        }

       
    }

    //存人物属性
    public void savePlayAttr()
    {
            playdata.attr.lv = attr.lv;//等级
            playdata.attr.cur_exp = attr.cur_exp;//当前经验
            playdata.attr.pre_exp = attr.pre_exp;//经验条
            playdata.attr.pre_hp = attr.pre_hp;//生命
            playdata.attr.cur_hp = attr.cur_hp;//生命
            playdata.attr.pre_mp = attr.pre_mp;//法力
            playdata.attr.cur_mp = attr.cur_mp;//法力
            playdata.attr.atk = attr.atk;//攻击
            playdata.attr.dt = attr.dt;//防御
            playdata.attr.baoJi = attr.baoJi;//暴击
            playdata.attr.baoAtk = attr.baoAtk;//爆伤
            playdata.attr.dodge = attr.dodge;//闪避
            playdata.attr.hit = attr.hit;//命中
    }
    //读人物属性
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