using UnityEngine;
using System.Collections;

public class CreateSomething : MonoBehaviour
{

	public GameObject[] somethings;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			PickUp ();
		}
	}

	void PickUp ()
	{
		//  无需先生成装备，如果装备栏中不存在再生成装备
		string goName = somethings[Random.Range(0,somethings.Length)].GetComponent<UISprite>().spriteName;
		bool needCreate = true;
		// 格子有子物体的时候
		for (int i = 0; i < Global.cells.Length; i++) {
			if (Global.cells [i].transform.childCount > 0) {
				string zbName = Global.cells [i].transform.GetChild (0).GetComponent<UISprite> ().spriteName;
				// 在格子的子物体中，找到了和生成的物体名字相同的装备
				if (goName == zbName) {
					string somethingNumber = Global.cells [i].transform.GetChild (0).transform.GetChild (0).GetComponent<UILabel> ().text;
					Global.cells [i].transform.GetChild (0).transform.GetChild (0).GetComponent<UILabel> ().text = (int.Parse (somethingNumber) + 1).ToString ();
					needCreate = false;
					break;
				}
			}
		}


		//  如果能执行到现在的代码，说明在上面中没有找到同名的装备，需要手动创建新装备
		if (needCreate) {
			for (int i = 0; i < Global.cells.Length; i++) {
				if (Global.cells[i].transform.childCount == 0) {
					GameObject go = NGUITools.AddChild(Global.cells[i].gameObject,somethings[0]);
					go.GetComponent<UISprite>().spriteName = goName;
					go.transform.localPosition = Vector3.zero;
					break;
				}
			}
		}

	}
}
