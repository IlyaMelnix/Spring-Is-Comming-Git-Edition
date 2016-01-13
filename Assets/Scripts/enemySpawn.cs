using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

    public GameObject enemy;
    float timer;
    public float minReloadTime;
    public float maxReloadTime;
    float reload = 1.0f;

	// Use this for initialization
	void Start () {
        timer = reload;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            reload = Random.Range(minReloadTime, maxReloadTime);
            timer = reload;
        }
	}
}
