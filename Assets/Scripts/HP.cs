using UnityEngine;
using System.Collections;
/// <summary>
/// 脚本功能：NGUI血条实现自动跟随人物位置进行方法和缩小，人物在视野消失时，血条消失
/// 知识要点：NGUI，unity中3D坐标到NGUI的2D坐标的转换
/// 创建时间：2015年9月29日
/// 脚本位置：人物主角
/// </summary>
public class HP : MonoBehaviour {

	private Transform HeadPoint;
	private float headToCameraDis;
	private float newHeadToCameraDis;
	public Transform HP_UI;
	private bool uiNeedShow = true;
	// Use this for initialization
	void Start () {
	HeadPoint = GameObject.Find("HeadPoint").transform;
	headToCameraDis = Vector3.Distance(HeadPoint.position,Camera.main.transform.position);
	}

	void OnBecameVisible()
	{
	uiNeedShow = true;
	}

	void OnBecameInvisible()
	{
	uiNeedShow = false;
	}


	// Update is called once per frame
	void Update () {
		if (uiNeedShow) {
			HP_UI.gameObject.SetActive(true);
		} else {
			HP_UI.gameObject.SetActive(false);
		}
		newHeadToCameraDis = headToCameraDis / Vector3.Distance(HeadPoint.position,Camera.main.transform.position);
		HP_UI.position = WorldToUI(HeadPoint.position);
		HP_UI.localScale = Vector3.one * newHeadToCameraDis;
	}


	public static Vector3 WorldToUI(Vector3 point)
	{	
		
		// 空间3D坐标到空间2D坐标的转换
		Vector3 main_point_2d = Camera.main.WorldToScreenPoint(point);
		// UI摄像机将屏幕2D坐标转换成NGUI摄像机的3D坐标
		Vector3 ui_point_3d = UICamera.mainCamera.ScreenToWorldPoint(main_point_2d);
		// UI的Z轴置零
		ui_point_3d.z = 0;
		return ui_point_3d;

	}
}
