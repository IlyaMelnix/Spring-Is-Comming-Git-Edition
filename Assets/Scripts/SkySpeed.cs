using UnityEngine;
using System.Collections;

public class SkySpeed : MonoBehaviour {
    float speed;
    public float y;
    float timer;
	// Use this for initialization
	void Start () {
        timer = 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * 2 * Time.deltaTime);
        if (transform.position.x < - 13 || transform.position.x > 16)
        {
            Destroy(gameObject);
        }
    }
}
