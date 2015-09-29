using UnityEngine;
using System.Collections;

public class MyDragItem : UIDragDropItem {
	

	// 新版本的NGUI中surface不再存在可能为空的情况
	protected override void OnDragDropRelease(GameObject surface)
	{
		// 调用父类的方法
		base.OnDragDropRelease(surface);
		// 接下来时对父类方法的补充
		if (surface.tag == "cell" ) {
			this.transform.parent = surface.transform;
			this.transform.localPosition = Vector3.zero;
		} else if (surface.tag == "Untagged") {
			// 回到拖动前的位置
			this.transform.localPosition = Vector3.zero;
		} else if (surface.tag != "cell" && surface.tag != "Untagged") {
			Transform tempParent = this.transform.parent;
			this.transform.parent = surface.transform.parent;
			this.transform.localPosition = Vector3.zero;
			surface.transform.parent = tempParent;
			surface.transform.localPosition = Vector3.zero;
		}
		Debug.Log(surface);
	}

}
