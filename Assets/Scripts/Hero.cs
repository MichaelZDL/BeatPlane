using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public bool heroAnimation = true;
    public int frameCountPerSecond = 10;
    public float timer = 0;
    public Sprite[] sprites;
    private SpriteRenderer spriteRender;
    public float superGunTime = 10f;
    private float resetSupterGunTime;

    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private int gunCount = 1;

    public Gun gunTop;
    public Gun gunLeft;
    public Gun gunRight;
	// Use this for initialization
	void Start () {
        spriteRender = this.GetComponent<SpriteRenderer>();
        resetSupterGunTime = superGunTime;
        superGunTime = 0;
        gunTop.openFire();
	}
  
	// Update is called once per frame
	void Update () {
        if (heroAnimation) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / frameCountPerSecond));//the same to static frame++ in Update
            int frame = frameIndex % 2;
            spriteRender.sprite = sprites[frame];
        }

        if (Input.GetMouseButtonDown(0)) {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }

        if (isMouseDown&&GameManager._instance.gameState==GameState.Running) {
            if (lastMousePosition != Vector3.zero) {
                //Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                
                transform.position = transform.position + offset;
                checkPosition();
                
            }

            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (superGunTime > 0) {
            superGunTime-=Time.deltaTime;
            if (gunCount == 1) {
                transformToSuperGun();
            }
        } else if (gunCount == 2) {
            transformToNormalGun();
        }
	}

    private void transformToSuperGun() {
        gunCount = 2;
        gunLeft.openFire();
        gunRight.openFire();
        gunTop.stopFire();
    }

    private void transformToNormalGun() {
        gunCount = 1;
        gunLeft.stopFire();
        gunRight.stopFire();
        gunTop.openFire();
    }
    private void checkPosition() {
        //check x -2.22f~2.22f  y -3.9f~3.4f
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;
        x = x < -2.22f?-2.22f : x;
        x = x > 2.22f ? 2.22f : x;
        y = y < -3.9f ? -3.9f : y;
        y = y > 3.4f ? 3.4f : y;

        transform.position = new Vector3(x, y, 0);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Award") {
            GetComponent<AudioSource>().Play();
            Award award = other.GetComponent<Award>();
            if (award.type == 0) {
                //chang to double guns
                superGunTime = resetSupterGunTime;
                Destroy(award.gameObject);
            } else if (award.type == 1) {
                BombManager.instance.AddBomb();
                Destroy(award.gameObject);
             
            }
        } else if (other.tag == "Enemy") {
            Destroy(this.gameObject);
            GameOver.instance.Show(GameManager._instance.score);
            BombManager.instance.gameObject.SetActive(false);
        }
    }
    
}
