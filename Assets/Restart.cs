using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    void OnMouseUpAsButton() {
        print("restart");
        Application.LoadLevel(0);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
