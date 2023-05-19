using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cama : MonoBehaviour
{

	// �ҵı���ͼƬΪ���� y ��ԳƵ�
	// ��������ӳ�ʱ��
	public float smoothTime = 0.2f;
	// ����ͼƬ
	public SpriteRenderer bgBounds;
	// ��ɫ
	public Transform target;
	// ���ڻ��������
	private Vector3 velocity = Vector3.one;
	// �����
	private Camera mainCamera;
	// ����ͼƬ�Ŀ��
	private float bgWidth;
	// ����ͼƬ�Ŀ��
	private float bgHeight;

    private void Start()
    {
		//bgBounds = transform.Find("�߿�/background").GetComponent<SpriteRenderer>();
		// �õ������
		mainCamera = GetComponent<Camera>();
		bgBounds = GameObject.Find("backgound").GetComponent<SpriteRenderer>();
		// ��ȡ����ͼƬ���
		bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;
		// ��ȡ����ͼƬ���
		bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
        if (target==null)
        {
			target = GameObject.Find("play").transform;

		}
	}
	// �� Update ��һִ֡��
	void LateUpdate()
	{
		//�����ھ�����
		if (!GameObject.Find("play")) return;
		if (!bgBounds) return;


		if (target == null && GameObject.Find("play"))
		{
			target = GameObject.Find("play").transform;
		}

		//  if (bgBounds == null)
		//  {
		//	bgBounds = transform.Find("background").GetComponent<SpriteRenderer>();
		//	bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;
		//	// ��ȡ����ͼƬ���
		//	bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
		//}
		// �������һ����
		float hight = mainCamera.orthographicSize;
		// �������һ��߶ȣ�����ֱ��ʵĿ�߱ȳ�����
		// �ø߶ȳ��Էֱ��ʵĿ�߱ȵõ����
		float width = hight * Screen.width / Screen.height;
		// Ҫ�ƶ�����λ��
		Vector3 temp;
        // ����ɫ�ĺ����� + �������һ���ȴ��ڱ���ͼƬ��һ���ȣ���Ϊ���˱߽磬��������Ŀ����Ϊ�ٽ��
        //if (width + Mathf.Abs(target.position.x) > bgWidth / 2)
        if ((width + Mathf.Abs(target.position.x) > bgWidth))
        {
            temp = new Vector3(Mathf.Sign(target.position.x) * (bgWidth - width), target.position.y, transform.position.z);
        }
        else
        {
            // ������Ϊ�����ƶ�
            temp = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
		if ((hight + Mathf.Abs(target.position.y) > bgHeight))
		{
			temp = new Vector3(temp.x, Mathf.Sign(target.position.y) * (bgHeight - hight), transform.position.z);
		}
		else
		{
			// ������Ϊ�����ƶ�
			temp = new Vector3(temp.x, target.position.y, transform.position.z);
		}

		//Debug.Log("position��x��"+bgBounds.transform.position.x+"��y��"+bgBounds.transform.position.y);
		//����ٽ�
		//ͼƬ�߽�
		temp.y = temp.y <= bgBounds.transform.position.y - bgHeight / 2+ hight ? bgBounds.transform.position.y - bgHeight / 2+ hight-1 : temp.y;
		temp.y = temp.y >= bgBounds.transform.position.y + bgHeight / 2- hight ? bgBounds.transform.position.y + bgHeight / 2- hight : temp.y;
		temp.x = temp.x <= bgBounds.transform.position.x - bgWidth / 2+width ? bgBounds.transform.position.x - bgWidth / 2 + width-2 : temp.x;
		temp.x = temp.x >= bgBounds.transform.position.x + bgWidth / 2 - width ? bgBounds.transform.position.x + bgWidth / 2-width+1 : temp.x;
		transform.position = Vector3.SmoothDamp(transform.position, temp, ref velocity, smoothTime);
		// ������߶ȵ��ٽ��ͬ��...

		// ʵ����������ӳ��ƶ�
	}
}

