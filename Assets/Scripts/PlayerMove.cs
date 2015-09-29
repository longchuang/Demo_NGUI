using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	void Update () {
		transform.Translate(Vector3.forward * Input.GetAxis("Vertical")) ;
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
	}

}
