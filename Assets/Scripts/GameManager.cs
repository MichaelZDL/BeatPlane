using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public int score = 0;
    public Text scoreShow;

    void Awake() {
        _instance = this;        
    }
	// Use this for initialization
	void Start () {
        scoreShow.text = "Score :123";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
