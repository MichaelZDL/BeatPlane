using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy0Prefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject awardType0Prefab;
    public GameObject awardType1Prefab;
    public GameObject Container;

    public float enemy0Rate = 0.5f; // spawn one per second
    public float enemy1Rate = 5f;
    public float enemy2Rate = 8f;
    public float awardType0Rate = 7f;
    public float awardType1Rate = 10f; 

	// Use this for initialization
	void Start () {
        InvokeRepeating("createEnemy0", 1, enemy0Rate);
        InvokeRepeating("createEnemy1", 1, enemy1Rate);
        InvokeRepeating("createEnemy2", 1, enemy2Rate);
        InvokeRepeating("createawardType0", 10, awardType0Rate);
        InvokeRepeating("createawardType1", 10, awardType1Rate);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void createEnemy0() {
        float x = Random.Range(-2.15f, 2.15f);
        GameObject o = GameObject.Instantiate(enemy0Prefab, new Vector3(x,transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;
    }

    public void createEnemy1() {
        float x = Random.Range(-2.06f, 2.06f);
        GameObject o = GameObject.Instantiate(enemy1Prefab, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;
    }

    public void createEnemy2() {
        float x = Random.Range(-1.59f, 1.59f);
        GameObject o = GameObject.Instantiate(enemy2Prefab, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;
    }

    public void createawardType0() {
        float x = Random.Range(-2.1f, 2.1f);
        GameObject o = GameObject.Instantiate(awardType0Prefab, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;
        GetComponent<AudioSource>().Play();
    }

    public void createawardType1() {
        float x = Random.Range(-2.1f, 2.1f);
        GameObject o = GameObject.Instantiate(awardType1Prefab, new Vector3(x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        o.transform.parent = Container.transform;
        GetComponent<AudioSource>().Play();
    }
}
