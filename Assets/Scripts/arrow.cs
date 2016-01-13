using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

    public float lifetime; //время жизни стрелы
    public int damage; //урон от стрелы
    float stuckY;
    
    Vector2 arrowVelocity;

    bool isRotate = true; //вращение стрелы включено

    // Use this for initialization
    void Start () {
        Destroy(gameObject, lifetime); //уничтожить стрелу через заданное время жизни
        stuckY = Random.Range(-4.0f, -2.5f);
        if(transform.position.y<=-2.4f) //чтобы при опущенном луке стрелы не сразу втыкались, а немного пролетали
            stuckY = Random.Range(-4.0f, -3.0f);
    }

    // Update is called once per frame
    void Update()
    { 
        if(isRotate) //вращение стрелы по направлению полета
        {
            arrowVelocity = GetComponent<Rigidbody2D>().velocity;
            if(arrowVelocity.x<=0)
            {
                transform.Rotate(0, 0, 120 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, -120 * Time.deltaTime);
            }
        }  
        if(transform.position.y <= stuckY)
        {
            GetComponent<Rigidbody2D>().isKinematic = true; //отключение физики стрелы
            GetComponent<BoxCollider2D>().enabled = false; //отключение столкновений
            isRotate = false; //отключение врщения
        }
    }
    
    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag != "arrow")
        {
            GetComponent<Rigidbody2D>().isKinematic = true; //отключение физики стрелы
            GetComponent<BoxCollider2D>().enabled = false; //отключение столкновений
            isRotate = false; //отключение врщения
            if(other.gameObject.tag == "airEnemy" || other.gameObject.tag == "groundEnemy")
            {
                transform.parent = other.transform;
            }
        }
    }
}
