using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 1;
    private Transform atkTrf;
    void Start()
    {
        Destroy(gameObject, 1f);
        //Debug.Log("name" + transform.name);
        //Debug.Log(gameObject.transform.parent.name);
        atkTrf = gameObject.transform.parent.parent;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (atkTrf.tag == "����")
        {
            Debug.Log("���ǹ���");
            //if (other.tag == "playr")
            if (other.tag == "play")
            {
                Debug.Log("������");
                other.transform.Find("role").GetComponent<roleAttr>().underAtk( transform.parent.parent.GetComponent<boss>().atk);
                Debug.Log("name" + transform.parent.parent.GetComponent<boss>().atk);
            }
        }
    }
   //private void OnTriggerStay2D(Collider2D other)
   //{
   //    Debug.Log("name" + other.name);
   //    Debug.Log("name" + atkTrf.tag);
   //    if (atkTrf.tag == "����")
   //    {
   //        Debug.Log("�����������");
   //
   //        if (other.tag == "play")
   //        {
   //            Debug.Log("������");
   //            other.transform.Find("role").GetComponent<roleAttr>().underAtk(transform.parent.parent.GetComponent<boss>().atk);
   //            Debug.Log("name" + transform.parent.parent.GetComponent<boss>().atk);
   //        }
   //    }
   //}
    // Update is called once per frame
    void Update()
    {
        //���﹥��
        if (transform.parent.tag == "����")
        {

            if (!transform.parent.GetComponent<Animator>().GetBool("isatk"))
                Destroy(this.gameObject);
        }
    }
}
