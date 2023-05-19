using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);//在加载新场景时不销毁脚本挂载的对象
        if (GameObject.Find(this.name).gameObject != this.gameObject)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
