using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textget : MonoBehaviour
{
    private Text text;
    private bool isShow = false;
    private float textTimer;
    private float textTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "你拾取了";
        textTimer = textTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (isShow)
        {
            if (textTimer <= 0)
            {
                isShow = false;

            }
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime/2);
            textTimer -= Time.deltaTime;
        }
    }
    public void setIsShow(bool isTrue,string texts)
    {
        isShow = isTrue;
        text.text = "你拾取了";
        text.text = text.text + texts;
        textTimer = textTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
    public void setSkillTime(bool isTrue, string texts)
    {
        isShow = isTrue;
        text.text = texts;
        textTimer = textTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
}
