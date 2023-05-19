using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jump : MonoBehaviour
{
    public Rigidbody2D gongJi;
    public Rigidbody2D tornodo;
    public float speed = 10;
    public int keyBoard;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void staticPlay()
    {
        animator.SetBool("ispuGong", false);
        animator.SetBool("isRun", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isget", false);
        animator.SetBool("isTruePugong", false);
    }

    public void ispuGongFn()
    {
        animator.SetBool("ispuGong", false);
        animator.SetBool("isTruePugong", false);
        // Debug.Log("执行了攻击关闭");
        ispuGongAnFn();

    }
    public void ispuGongAnFn()
    {
        switch (keyBoard)
        {
             case 0:
                //初始化子弹函数，
                Rigidbody2D bulletInstance = Instantiate(gongJi, transform.position, Quaternion.Euler(new Vector3(0, 1, 0))) as Rigidbody2D;
                //防止其自动旋转
                bulletInstance.transform.localScale = transform.parent.transform.localScale.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
                // Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                // Vector3 pos = Camera.main.ScreenToWorldPoint(m_MousePos);
                //bulletInstance.velocity=(pos - transform.position) * 2;
                bulletInstance.velocity = transform.parent.transform.localScale.x > 0 ? new Vector2(speed, 0) : new Vector2(-speed, 0);
                break;
            case 1:
                Vector3 pos = transform.position;
                //监视一下人物朝向

                Vector3 longV3 = this.transform.parent.transform.localScale.x > 0 ? new Vector3(pos.x + 2, pos.y + 1, pos.y) : new Vector3(pos.x - 2, pos.y + 1, pos.y);
                Rigidbody2D tor = Instantiate(tornodo, longV3, Quaternion.Euler(new Vector3(0, 1, 0))) as Rigidbody2D;
                //防止其自动旋转
                tor.transform.localScale = transform.parent.transform.localScale.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
                tor.velocity = transform.parent.transform.localScale.x > 0 ? new Vector2(speed*1.3f, 0) : new Vector2(-speed*1.3f, 0);
                break;
        }
           
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
