using UnityEngine;
using System.Collections;

public class Award : MonoBehaviour {

	public int type = 0;//0 gun 1 bomb

    public float awardSpeed = 1.5f;

    void Update(){
        this.transform.Translate(Vector3.down*awardSpeed*Time.deltaTime);
        if (this.transform.position.y < -4.7f) {
            Destroy(this.gameObject);
        }

    }
	
}
