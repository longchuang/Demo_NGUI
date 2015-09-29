using UnityEngine;
using System.Collections;

public class CD_Manager : MonoBehaviour {
	private UISprite _sprite;
	private float cdTime = 2f;
	private bool cdIsCold = false;
	// Use this for initialization
	void Start () {
	_sprite = gameObject.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.B) && cdIsCold == false ) {
			_sprite.fillAmount = 1f;
			cdIsCold = true;
		}
		if (cdIsCold) {
			cdTime -= Time.deltaTime;
			_sprite.fillAmount = cdTime / 2;
			if (cdTime <= 0) {
				cdTime = 2;
				_sprite.fillAmount = 0;
				cdIsCold = false;
			}


		}
	}

}
