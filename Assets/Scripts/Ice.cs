using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pointOfNoReturnForBird")
        {
            Rigidbody2D rig = GetComponent<Rigidbody2D>();
            rig.constraints = RigidbodyConstraints2D.None;
        }

        if (other.gameObject.tag == "groundBABA")
        {
                if (PlayerPrefs.HasKey("burning"))
                {
                    PlayerPrefs.SetInt("burning", PlayerPrefs.GetInt("burning") - 1);
                    PlayerPrefs.Save();
                }
        }
    }
}
