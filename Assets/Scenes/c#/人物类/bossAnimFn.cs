using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAnimFn : MonoBehaviour
{
    public Rigidbody2D atkObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void isDeathFn()
    {
        Destroy(this.transform.parent.gameObject);
        GameObject.Find("play").transform.Find("role").GetComponent<roleAttr>().expAdd(50);
    }
    void isYunXuan()
    {
        transform.GetComponent<Animator>().SetBool("isYunXuan", false);
    }
    void puGong()
    {
        Rigidbody2D bossAtk = Instantiate(atkObj, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        bossAtk.transform.SetParent(transform);
        bossAtk.transform.localPosition = new Vector2(1.5f, -1.5f);
        bossAtk.transform.localScale=new Vector3(1,1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
