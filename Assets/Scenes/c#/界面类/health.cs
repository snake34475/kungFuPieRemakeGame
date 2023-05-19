using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    /// <summary>
    /// 判断是否在触发范围内
    /// </summary>
    private bool isTriggle=false;
    // Start is called before the first frame update
    public Transform myTextObject;
    private Text myText;
    void Start()
    {
        myTextObject = GameObject.Find("Text").transform;
    }
    /// <summary>
    /// 进入药品，状态改为true
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "play")
        {
            isTriggle = true;
            GameObject.Find("play").GetComponent<player>().isGoodsTrigger = true;

            //Debug.Log("进入药品");
        }
    }
    /// <summary>
    /// 离开药品，状态改为false
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "play")
        {
            isTriggle =false;
            GameObject.Find("play").GetComponent<player>().isGoodsTrigger = false;
            //Debug.Log("进入药品");

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTriggle)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject.Find("role").transform.GetComponent<Animator>().SetBool("isget",true);
                Destroy(this.gameObject);
                myTextObject.GetComponent<textget>().setIsShow(true,this.transform.GetChild(0).name);
                GameObject background = GameObject.Find("Canvas").transform.Find("背包").Find("背包父").gameObject;
                background.GetComponent<background>().addBackgItem(transform.GetChild(0).name);
            }
        }
       
    }
}
