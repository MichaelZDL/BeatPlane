using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float bulletRate = 0.2f;
    public GameObject bullet;
    public GameObject Container;

    void Start() {
    }
    public void fire() {
        GameObject o = GameObject.Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;

    }

    public void openFire() {
        InvokeRepeating("fire", 0, bulletRate);
    }

    public void stopFire() {
        CancelInvoke("fire");
    }
	// Update is called once per frame
	void Update () {
	
	}

}
