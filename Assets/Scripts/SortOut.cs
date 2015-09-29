using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SortOut : MonoBehaviour {

	private List<Transform> zbTransforms = new List<Transform> ();

	public void zbSort()
	{
		zbTransforms.Clear();

		for (int i = 0; i < Global.cells.Length; i++) {
			if (Global.cells[i].transform.childCount > 0) {
				zbTransforms.Add(Global.cells[i].transform.GetChild(0));
			}
		}

		for (int i = 0; i < zbTransforms.Count; i++) {
			zbTransforms[i].parent = Global.cells[i].transform;
			zbTransforms[i].localPosition = Vector3.zero;
		}

	}
}
