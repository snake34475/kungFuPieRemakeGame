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
        if (transform.tag == "普攻")
        {
            //Debug.Log("我是普攻");
            Destroy(this.gameObject, 2);
        }
        else
        {
            //Debug.Log("我是其他");
            Destroy(this.gameObject, 1);
        }
        
    }
    //龙人攻击
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "怪物":
                other.GetComponent<boss>().underAtk(GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().getAtk());
                break;
            case "障碍":
                other.GetComponent<zhangai>().underAtk(1);
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
