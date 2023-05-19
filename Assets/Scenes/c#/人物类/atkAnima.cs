using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkAnima : MonoBehaviour
{
    float speed = 4;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.tag == "�չ�")
        {
            //Debug.Log("�����չ�");
            Destroy(this.gameObject, 2);
        }
        else
        {
            //Debug.Log("��������");
            Destroy(this.gameObject, 1);
        }
        
    }
    //���˹���
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "����":
                other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk());
                break;
            case "�ϰ�":
                other.GetComponent<zhangai>().underAtk(1);
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
