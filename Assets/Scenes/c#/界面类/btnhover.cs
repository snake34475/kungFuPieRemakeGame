using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class btnhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator animator;
    public Transform tranf;
    private Sprite beforemap;
    public GameObject scrrolobj;
    public Sprite aftermap;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "关闭")
        {
           // Debug.Log("执行了关闭");
        }
        beforemap = transform.GetComponent<Image>().sprite;
        if (this.name == "背景")
        {

            Debug.Log("存档弹力"+transform.parent.name);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (aftermap)
        {
            transform.GetComponent<Image>().sprite = aftermap;
            Vector3 btnScale = transform.localScale;
            btnScale.x = btnScale.x + 0.05f;
            btnScale.y = btnScale.y + 0.05f;
            transform.localScale = btnScale;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Vector3 btnScale = transform.localScale;
            btnScale.x = btnScale.x + 0.2f;
            btnScale.y = btnScale.y + 0.2f;
            transform.localScale = btnScale;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        //Debug.Log("我进来了");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (aftermap)
        {
            transform.GetComponent<Image>().sprite = beforemap;
            Vector3 btnScale = transform.localScale;
            btnScale.x = btnScale.x - 0.05f;
            btnScale.y = btnScale.y - 0.05f;
            transform.localScale = btnScale;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Vector3 btnScale = transform.localScale;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            btnScale.x = btnScale.x - 0.2f;
            btnScale.y = btnScale.y - 0.2f;
            transform.localScale = btnScale;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == "收起来")
        {
            animator = transform.GetComponentInParent<Animator>();
            bool isshow = animator.GetBool("isshow");
            animator.SetBool("isshow", !isshow);
        }
        if (this.name == "背包")
        {
            animator = tranf.GetComponent<Animator>();
            animator.SetBool("isopen", true);
        }
        if (this.name == "关闭")
        {
            Debug.Log("点击了关闭");
            animator = transform.GetComponentInParent<Animator>();
            animator.SetBool("isopen", false);
        }
        if (this.name == "关卡关闭")
        {
            animator = transform.GetComponentInParent<Animator>();
            bool isshow = animator.GetBool("isShow");
            animator.SetBool("isShow", !isshow);
        }
        if (this.name == "关卡重开")
        {
            animator = transform.GetComponentInParent<Animator>();
            SceneManager.LoadScene("机关巷-1");
            GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
            animator.SetBool("isShow", false);
        }
        if (this.name == "离开关卡")
        {
            animator = transform.GetComponentInParent<Animator>();
            SceneManager.LoadScene("功夫城西");
            GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
            animator.SetBool("isShow", false);
        }
        if (this.name == "设置")
        {
            SaveData saveData = new SaveData();
            saveData.saveData();
           // UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            
        }
        if (this.name == "返回")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isMapopen", false);
        }
        if (this.name == "地图")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isMapopen", true);
        }
        if (this.name == "开始游戏")
        {
            animator = transform.GetComponentInParent<Animator>();
            animator.SetBool("isshow", false);
        }
        if (this.name == "喇叭")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isshow", true);

        }
        if (this.name == "设置小按钮")
        {
            SaveData saveData = new SaveData();
            saveData.saveData();
        }
        if (this.name == "团队")
        {
            SaveData saveData = new SaveData();
            saveData.loadData();
        }
        if (this.name == "团队")
        {
            SaveData saveData = new SaveData();
            saveData.loadData();
        }
    }
}
