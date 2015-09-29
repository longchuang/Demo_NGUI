using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	public static GameObject CellGroup;
	public static GameObject [] cells;
		

	void Start () {
		CellGroup = GameObject.Find("CellGroup");
		cells = new GameObject[CellGroup.transform.childCount]; 
		for (int i = 0; i < cells.Length; i++) {
			cells[i] = CellGroup.transform.GetChild(i).gameObject;
		}
	}





}
