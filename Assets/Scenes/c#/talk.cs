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
        Debug.Log("������������");
        if (talkTransfrom)
        {
        Debug.Log("��������");
            talkTransfrom.gameObject.SetActive(true);
            talkTransfrom.Find("ok").Find("Text").GetComponent<Text>().text = btnOkText == "" ? "��֪����" : btnOkText;
            talkTransfrom.Find("cancel").Find("Text").GetComponent<Text>().text = btnCancelText == "" ? "�ر�" : btnCancelText;
            talkTransfrom.Find("content").GetComponent<Text>().text = conText == "" ? "��������" : conText;
        }
    }
    //�˷����ǰ�ť�ķ���
    public void btnOk()
    {
        transform.gameObject.SetActive(false);
        switch (transform.Find("ok").Find("Text").GetComponent<Text>().text)
        {
            case "��Ҫһѩǰ�ܣ�����":
                GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
                GameObject.Find("role").GetComponent<Animator>().SetBool("isDeath", false);
                break;

        }
    }
    public void btnCancel()
    {
        transform.gameObject.SetActive(false);
        Debug.Log("ִ��ȡ��1");
        switch (transform.Find("cancel").Find("Text").GetComponent<Text>().text)
        {
            case "���˰ɣ���Ҫ�˳�":
                Debug.Log("ִ�����˳�");
                SceneManager.LoadScene("�������");
                GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
                GameObject.Find("role").GetComponent<Animator>().SetBool("isDeath", false);
                break;

        }
    }
}
