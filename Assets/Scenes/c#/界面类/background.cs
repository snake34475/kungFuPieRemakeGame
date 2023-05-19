using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class background : MonoBehaviour
{
    public List<goods> backGroundList = new List<goods>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //���������Ƿ񿪹�
        isOpen();

    }
    private void isOpen()
    {
        if (transform.GetComponentInParent<Animator>().GetBool("isopen"))
        {
           // Debug.Log(transform.GetComponentInParent<Animator>().GetBool("isopen"));
        }
    }
    public void addBackgItem(string name, int num = 1)
    {
        //�ж��Ƿ����
        bool isTobe = false;


        backGroundList.ForEach(item =>
        {
            Debug.Log("ִ���������");
            if (item.name == name)
            {
                int index = backGroundList.IndexOf(item);
                item.num += num;
                transform.GetChild(index).GetComponent<backItem>().num = item.num;
                transform.GetChild(index).GetComponent<backItem>().name = item.name;
                isTobe = true;
            }
           

        });
        //�����ڵ�������ٿ���һ���¶���
        if (!isTobe)
        {
            Debug.Log("ִ�������Ʒ");
            int count = backGroundList.Count > 0 ? backGroundList.Count : 0;
            transform.GetChild(count).GetComponent<backItem>().num = num;
            transform.GetChild(count).GetComponent<backItem>().name = "" + name + "";
            goods good = new goods();
            good.name = name;
            good.num = num;
            backGroundList.Add(good);

        }

    }
    public void getBackGroundData(List<goods> list)
    {
        list.ForEach(item =>
        {

            int index = list.IndexOf(item);
            transform.GetChild(index).GetComponent<backItem>().num = item.num;
            transform.GetChild(index).GetComponent<backItem>().name =item.name;
        });
        backGroundList = list;
    }
}
