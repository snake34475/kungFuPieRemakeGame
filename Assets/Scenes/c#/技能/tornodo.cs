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
        Debug.Log("�����������");
        if (other.tag == "����")
        {
            Debug.Log("�����������");
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isbyfly", true);
            //�Ƿ�۹�
            //other.transform.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity;
            isfly = true;
            StartCoroutine(Timer(other)); // ��ʼЭͬ����
        }
        if(other.tag == "�ϰ�")
        {
            other.GetComponent<zhangai>().underAtk(1);
        }

    }
    IEnumerator Timer(Collider2D other)
    {
        float timer = 3;
        while (timer > 0)
        {
            //��Ҫ�ظ�ִ�еĴ���ͷ����ڴ˴�
            other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk() * 2);
            timer -= 0.5f;
            yield return new WaitForSeconds(0.5f); // ִֹͣ��1��

        }
    }
    //�����Ǿ���һֱ�ٿ���
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk());
    //    other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk()*Time.deltaTime);
    //}
    //�뿪�������ѣ��Ȼ��վ����Ϊ��ֹû���ڿչ��Ĺ��ﴥ��ѣ�Σ���Ҫ�洢һ������
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("�뿪�������");
        if (other.tag == "����"&&isfly==true)
        {
            Debug.Log("�����뿪�������");
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isYunXuan", true);
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("isbyfly", false);
        }
    }
    private void tranfPosY()
    {
        Vector3 pos = transform.position;
        //���y�ĸ߶���Ҫ�����ڶ�λ����������ʼ�����أ�ͨ���˵�����-�˸߶�/2+�����ĸ�/2+�����߶ȣ���Ҫ����Ϊ�˵ĸ߶�ֻ��ͼƬ�߶ȣ�������һЩ����ʲô������Ҫ���ϲ����߶ȣ�
        transform.position = new Vector3(pos.x, playPosY-playHeight/2+transform.GetComponent<SpriteRenderer>().bounds.size.y/2+0.6f, pos.z);
    }
}
