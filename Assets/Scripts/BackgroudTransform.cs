using UnityEngine;
using System.Collections;

public class BackgroudTransform : MonoBehaviour {

    private float moveSpeed = 2f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Vector3 position = this.transform.position;
        if (position.y <= -8.52f) {
            this.transform.position = new Vector3(position.x, position.y + 2*8.52f, position.z);
        }
	}
}
