using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 对话框类 : MonoBehaviour
{
    public string npcName;
    public string npcId;
    public ArrayList npcTalk;
    struct talkContent
    {
        public string conText;
        public string btnOkText;
        public string btnCancelText;
    }
    // Start is called before the first frame update
    void Start()
    {
        npcTalk.Add(new talkArry());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
