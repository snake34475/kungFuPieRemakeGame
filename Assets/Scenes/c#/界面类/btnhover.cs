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
        if (this.name == "�ر�")
        {
           // Debug.Log("ִ���˹ر�");
        }
        beforemap = transform.GetComponent<Image>().sprite;
        if (this.name == "����")
        {

            Debug.Log("�浵����"+transform.parent.name);
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

        //Debug.Log("�ҽ�����");
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
        if (this.name == "������")
        {
            animator = transform.GetComponentInParent<Animator>();
            bool isshow = animator.GetBool("isshow");
            animator.SetBool("isshow", !isshow);
        }
        if (this.name == "����")
        {
            animator = tranf.GetComponent<Animator>();
            animator.SetBool("isopen", true);
        }
        if (this.name == "�ر�")
        {
            Debug.Log("����˹ر�");
            animator = transform.GetComponentInParent<Animator>();
            animator.SetBool("isopen", false);
        }
        if (this.name == "�ؿ��ر�")
        {
            animator = transform.GetComponentInParent<Animator>();
            bool isshow = animator.GetBool("isShow");
            animator.SetBool("isShow", !isshow);
        }
        if (this.name == "�ؿ��ؿ�")
        {
            animator = transform.GetComponentInParent<Animator>();
            SceneManager.LoadScene("������-1");
            GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
            animator.SetBool("isShow", false);
        }
        if (this.name == "�뿪�ؿ�")
        {
            animator = transform.GetComponentInParent<Animator>();
            SceneManager.LoadScene("�������");
            GameObject.Find("role").GetComponent<roleAttr>().hpMpReset();
            animator.SetBool("isShow", false);
        }
        if (this.name == "����")
        {
            SaveData saveData = new SaveData();
            saveData.saveData();
           // UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            
        }
        if (this.name == "����")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isMapopen", false);
        }
        if (this.name == "��ͼ")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isMapopen", true);
        }
        if (this.name == "��ʼ��Ϸ")
        {
            animator = transform.GetComponentInParent<Animator>();
            animator.SetBool("isshow", false);
        }
        if (this.name == "����")
        {
            animator = tranf.GetComponentInParent<Animator>();
            animator.SetBool("isshow", true);

        }
        if (this.name == "����С��ť")
        {
            SaveData saveData = new SaveData();
            saveData.saveData();
        }
        if (this.name == "�Ŷ�")
        {
            SaveData saveData = new SaveData();
            saveData.loadData();
        }
        if (this.name == "�Ŷ�")
        {
            SaveData saveData = new SaveData();
            saveData.loadData();
        }
    }
}
