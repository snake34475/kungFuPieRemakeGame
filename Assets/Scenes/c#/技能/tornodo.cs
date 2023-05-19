using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornodo : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isfly = false;
    public float longScale = 0.2f;
    public float ddtime = 500f;
    private float playPosY;
    private float playHeight;
    void Start()
    {
        transform.localScale = transform.localScale * 0.3f;
        playPosY = GameObject.Find("play").transform.position.y;
        playHeight = GameObject.Find("play").transform.Find("role").transform.GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log("playHeight:" + playHeight + "playPosY:" + playPosY);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.localScale.x <= -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity*0.95f;
        }
        else if (transform.localScale.x >= 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity * 0.95f;
        }
        else
        {
            transform.localScale = transform.localScale * 1.006f;
        }
        tranfPosY();
    }
    public void isEnd()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("进入龙卷风了");
        if (other.tag == "怪物")
        {
            Debug.Log("怪物龙卷风了");
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isbyfly", true);
            //是否聚怪
            //other.transform.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity;
            isfly = true;
            StartCoroutine(Timer(other)); // 开始协同程序
        }
        if(other.tag == "障碍")
        {
            other.GetComponent<zhangai>().underAtk(1);
        }

    }
    IEnumerator Timer(Collider2D other)
    {
        float timer = 3;
        while (timer > 0)
        {
            //需要重复执行的代码就放于在此处
            other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk() * 2);
            timer -= 0.5f;
            yield return new WaitForSeconds(0.5f); // 停止执行1秒

        }
    }
    //呆在那就是一直再空中
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk());
    //    other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk()*Time.deltaTime);
    //}
    //离开就是落地眩晕然后站立，为防止没有腾空过的怪物触发眩晕，需要存储一个变量
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("离开龙卷风了");
        if (other.tag == "怪物"&&isfly==true)
        {
            Debug.Log("怪物离开龙卷风了");
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isYunXuan", true);
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isbyfly", false);
        }
    }
    private void tranfPosY()
    {
        Vector3 pos = transform.position;
        //这的y的高度主要是用于定位，让龙卷风的始终贴地，通过人的中心-人高度/2+龙卷风的高/2+补偿高度（主要是因为人的高度只是图片高度，还包括一些底座什么的所以要加上补偿高度）
        transform.position = new Vector3(pos.x, playPosY-playHeight/2+transform.GetComponent<SpriteRenderer>().bounds.size.y/2+0.6f, pos.z);
    }
}
