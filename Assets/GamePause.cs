﻿using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

    void OnMouseUpAsButton() {
        GameManager._instance.transformGameState();
        audio.Play();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
