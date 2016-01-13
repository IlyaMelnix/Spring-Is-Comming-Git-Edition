using UnityEngine;
using System.Collections;

public class RoundMeln : MonoBehaviour {
    public int x;
    Collider2D col;
	void Start () {
       // col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z +z );
        transform.Rotate(0, 0, x);
        
	}
}
