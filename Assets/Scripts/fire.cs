using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

    public float lifetime; //время жизни огня
    public float dy;
    float startY;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, lifetime); //уничтожить огонь через заданное время жизни
        transform.eulerAngles = new Vector3(0, 0, 0); //убирает повороты огня; огонь всегда повернут на 0 градусов
        startY = transform.position.y; // сохраняет начальное положение огня по y
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y <= startY - dy) // падение огня на 1.2 вниз и остановка
            GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown() {
        //int count = 0;
        //int burnCou;
        Destroy(this.gameObject);
        if(PlayerPrefs.HasKey("fire") && PlayerPrefs.HasKey("burning"))
        {
            //count = PlayerPrefs.GetInt("fire");
            //count++;
            PlayerPrefs.SetInt("fire", PlayerPrefs.GetInt("fire")+1);
            //burnCount = PlayerPrefs.GetInt("burning");
            //burnCount++;
            if(PlayerPrefs.GetInt("burning") < 11)
            {
                PlayerPrefs.SetInt("burning", PlayerPrefs.GetInt("burning") + 1);
            }
            PlayerPrefs.Save();
        }
        //Debug.Log(count);
    }

    //void OnTriggerEnter2D (Collider2D other)
    //{
    //    if(other.gameObject.tag == "ground")
    //    {
    //        GetComponent<Rigidbody2D>().isKinematic = true;
    //    }
    //}
}
