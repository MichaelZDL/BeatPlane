using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState {
    Running,
    Pause
}

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public int score = 0;
    public GameState gameState = GameState.Running;
    public Text scoreShow;

    void Awake() {
        _instance = this;        
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        scoreShow.text = "Score : "+score;	
	}

    public void transformGameState() {
        if (gameState == GameState.Running) {
            PauseGame();
        } else if (gameState == GameState.Pause) {
            ResumeGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0; //time.deltaTime = 0;
        gameState = GameState.Pause;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        gameState = GameState.Running;
    }

}
