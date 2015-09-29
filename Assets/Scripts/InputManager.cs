using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public UITextList _textList;
	public UIInput _inputText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddTextToTextList()
	{
		_textList.Add(_inputText.value);
		_inputText.value = null;
	
	}
}
