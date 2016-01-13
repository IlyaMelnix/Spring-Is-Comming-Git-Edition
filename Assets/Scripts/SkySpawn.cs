using UnityEngine;
using System.Collections;

public class SkySpawn : MonoBehaviour {
    int speed;
    bool orientation;
    public GameObject[] objects;
    float timer;
    public int n;
    float y;
	void Start () {
        timer = 1;
	}

	void Update () {
        timer -= Time.deltaTime; 
        if (timer <=0)
        {
            y = Random.Range(transform.position.y - 1, transform.position.y + 2);
            n = Random.Range(0, 3);
            Instantiate(objects[n], new Vector3(transform.position.x, y, transform.position.z), transform.rotation);
            timer = 5;
        }
	}
}
