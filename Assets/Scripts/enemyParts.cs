using UnityEngine;
using System.Collections;

public class enemyParts : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "arrow")
        {
            bubble();
        }        
    }

    void bubble()
    {
        if (transform.parent.GetComponent<enemyParts>())
            transform.parent.GetComponent<enemyParts>().bubble();
        else
            transform.parent.GetComponent<enemyCommon>().bubble();
    }

    public void disableCollider()
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "enemyParts")
            {
                child.GetComponent<enemyParts>().disableCollider();
            }
        }
    }
}
