﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.left);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.Translate (Vector2.down);
		}
	}
}