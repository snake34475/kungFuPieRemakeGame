using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cama : MonoBehaviour
{

	// 我的背景图片为关于 y 轴对称的
	// 摄像机的延迟时间
	public float smoothTime = 0.2f;
	// 背景图片
	public SpriteRenderer bgBounds;
	// 角色
	public Transform target;
	// 用于缓冲摄像机
	private Vector3 velocity = Vector3.one;
	// 摄像机
	private Camera mainCamera;
	// 背景图片的宽度
	private float bgWidth;
	// 背景图片的宽度
	private float bgHeight;

    private void Start()
    {
		//bgBounds = transform.Find("边框/background").GetComponent<SpriteRenderer>();
		// 拿到摄像机
		mainCamera = GetComponent<Camera>();
		bgBounds = GameObject.Find("backgound").GetComponent<SpriteRenderer>();
		// 获取背景图片宽度
		bgWidth = bgBounds.sprite.bounds.size.x * bgBounds.transform.localScale.x;
		// 获取背景图片宽度
		bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
        if (target==null)
        {
			target = GameObject.Find("play").transform;

		}
	}
	// 比 Update 慢一帧执行
	void LateUpdate()
	{
		//不存在就拦截
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
		//	// 获取背景图片宽度
		//	bgHeight = bgBounds.sprite.bounds.size.y * bgBounds.transform.localScale.y;
		//}
		// 摄像机的一半宽度
		float hight = mainCamera.orthographicSize;
		// 摄像机的一半高度，会随分辨率的宽高比成正比
		// 用高度乘以分辨率的宽高比得到宽度
		float width = hight * Screen.width / Screen.height;
		// 要移动到的位置
		Vector3 temp;
        // 当角色的横坐标 + 摄像机的一半宽度大于背景图片的一半宽度，则为到了边界，把摄像机的宽度设为临界点
        //if (width + Mathf.Abs(target.position.x) > bgWidth / 2)
        if ((width + Mathf.Abs(target.position.x) > bgWidth))
        {
            temp = new Vector3(Mathf.Sign(target.position.x) * (bgWidth - width), target.position.y, transform.position.z);
        }
        else
        {
            // 否则则为正常移动
            temp = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
		if ((hight + Mathf.Abs(target.position.y) > bgHeight))
		{
			temp = new Vector3(temp.x, Mathf.Sign(target.position.y) * (bgHeight - hight), transform.position.z);
		}
		else
		{
			// 否则则为正常移动
			temp = new Vector3(temp.x, target.position.y, transform.position.z);
		}

		//Debug.Log("position，x："+bgBounds.transform.position.x+"，y："+bgBounds.transform.position.y);
		//添加临界
		//图片边界
		temp.y = temp.y <= bgBounds.transform.position.y - bgHeight / 2+ hight ? bgBounds.transform.position.y - bgHeight / 2+ hight-1 : temp.y;
		temp.y = temp.y >= bgBounds.transform.position.y + bgHeight / 2- hight ? bgBounds.transform.position.y + bgHeight / 2- hight : temp.y;
		temp.x = temp.x <= bgBounds.transform.position.x - bgWidth / 2+width ? bgBounds.transform.position.x - bgWidth / 2 + width-2 : temp.x;
		temp.x = temp.x >= bgBounds.transform.position.x + bgWidth / 2 - width ? bgBounds.transform.position.x + bgWidth / 2-width+1 : temp.x;
		transform.position = Vector3.SmoothDamp(transform.position, temp, ref velocity, smoothTime);
		// 摄像机高度的临界点同理...

		// 实现摄像机的延迟移动
	}
}

