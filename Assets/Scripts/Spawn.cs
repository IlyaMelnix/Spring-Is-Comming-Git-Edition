using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
    float timer;
    public float minReloadTime;
    public float maxReloadTime;
    float reload = 1.0f;

    // Use this for initialization
    void Start()
    {
        timer = reload;
        //timer = Random.Range(1, 5);
        //Debug.Log(timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            float y = Random.Range(transform.position.y-1, transform.position.y + 1); // -5, -3 ok
            //Instantiate(enemy, transform.position, transform.rotation);
            Instantiate(enemy, new Vector3(10, y, 0), transform.rotation);
            reload = Random.Range(minReloadTime, maxReloadTime);
            timer = reload;
        }
    }
}
