using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 测试脚本 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("测试bug");
        if (GameObject.Find("play"))
        {
           // Debug.Log("角色加载成功");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
