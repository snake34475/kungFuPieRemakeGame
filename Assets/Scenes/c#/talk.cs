using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class talk : MonoBehaviour
{
    public string conText = "";
    public string btnOkText;
    public string btnCancelText;
    public string npcName;
    private Transform talkTransfrom;
    // Start is called before the first frame update
    void Start()
    {
        talkTransfrom = GameObject.Find("Canvas").transform.Find("talkToNpc");
        if (talkTransfrom)
        {
            talkTransfrom.gameObject.SetActive(false);
            talkTransfrom.localPosition = new Vector3(talkTransfrom.localPosition.x, -75, talkTransfrom.localPosition.z);
            talkTransfrom.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void open()
    {
        Debug.Log("他还不存在呢");
        if (talkTransfrom)
        {
        Debug.Log("他存在了");
            talkTransfrom.gameObject.SetActive(true);
            talkTransfrom.Find("ok").Find("Text").GetComponent<Text>().text = btnOkText == "" ? "我知道了" : btnOkText;
            talkTransfrom.Find("cancel").Find("Text").GetComponent<Text>().text = btnCancelText == "" ? "关闭" : btnCancelText;
            talkTransfrom.Find("content").GetComponent<Text>().text = conText == "" ? "暂无它事" : conText;
        }
    }
    //此方法是按钮的方法
    public void btnOk()
    {
        transform.gameObject.SetActive(false);
        switch (transform.Find("ok").Find("Text").GetComponent<Text>().text)
        {
            case "我要一雪前耻，复活":
                GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
                GameObject.Find("role").GetComponent<Animator>().SetBool("isDeath", false);
                break;

        }
    }
    public void btnCancel()
    {
        transform.gameObject.SetActive(false);
        Debug.Log("执行取消1");
        switch (transform.Find("cancel").Find("Text").GetComponent<Text>().text)
        {
            case "算了吧，我要退出":
                Debug.Log("执行了退出");
                SceneManager.LoadScene("功夫城西");
                GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
                GameObject.Find("role").GetComponent<Animator>().SetBool("isDeath", false);
                break;

        }
    }
}
