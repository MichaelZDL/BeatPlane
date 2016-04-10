using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BombManager : MonoBehaviour {

    public GameObject bomb;
    public Text bombNum;

    public int count;
    public static BombManager instance;
    void Awake() {
        instance = this;
        bomb.SetActive(false);
        bombNum.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && count > 0) {
            this.UseABomb();
        }
    }
    public void AddBomb() {
        bomb.SetActive(true);
        bombNum.gameObject.SetActive(true);

        count++;
        bombNum.text = " X" + count;
    }

    public void UseABomb() {
        if (count > 0) {
            count--;
            bombNum.text = " X" + count;
            if (count <= 0) {
                bomb.SetActive(false);
                bombNum.gameObject.SetActive(false);
            }
        }
        
    }

}
