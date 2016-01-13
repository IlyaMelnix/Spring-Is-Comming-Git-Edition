using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public GameObject fire;

    public float speed;
    public float deathTime;
    bool isRotate = false;

    public float health;
    float currentHealth;
    float heathBarLength;

    //public GUIStyle myStyle;

	// Use this for initialization
	void Start () {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (isRotate)
        {
            transform.RotateAround(new Vector2(transform.position.x, transform.position.y - gameObject.GetComponent<BoxCollider2D>().size.y / 2), new Vector3(0, 0, -1), 90 * Time.deltaTime);
        }
        if (transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
        heathBarLength = currentHealth / health;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "arrow")
        {
            --currentHealth;
            //GameObject.FindGameObjectWithTag("heath").transform.localScale = new Vector3(0.5f, 0.0f, 0.0f);
            if(currentHealth >= 0)
                transform.Find("health").gameObject.transform.localScale -= new Vector3(1.0f/health, 0.0f, 0.0f);
            // Debug.Log(transform.Find("health").gameObject.transform.localScale.x);
            if(currentHealth <= 0)
            {
                speed = 0;
                GetComponent<BoxCollider2D>().enabled = false;
                isRotate = true;
                Destroy(gameObject, deathTime);
                if (PlayerPrefs.HasKey("killedEnemiesCount") && PlayerPrefs.HasKey("killEnemiesToGetFire"))
                {
                    int count = PlayerPrefs.GetInt("killedEnemiesCount");
                    ++count;
                    if (count == PlayerPrefs.GetInt("killEnemiesToGetFire"))
                    {
                        count = 0;
                        GameObject fireInstance = (GameObject) Instantiate(fire, transform.position, transform.rotation);
                        //GameObject fireInstance = (GameObject) Instantiate(fire, transform.position, transform.rotation);
                        //fireInstance.transform.position= new Vector2(transform.position.x, transform.position.y - 3*transform.localScale.y);
                        if (gameObject.tag == "airEnemy")
                            fireInstance.GetComponent<fire>().dy = 4.57f;
                        if (gameObject.tag == "groundEnemy")
                            fireInstance.GetComponent<fire>().dy = 1.2f;
                        PlayerPrefs.SetInt("killEnemiesToGetFire", Random.Range(3, 9)); 
                        PlayerPrefs.Save();
                    }
                    PlayerPrefs.SetInt("killedEnemiesCount", count);
                    PlayerPrefs.Save();
                }
            }            
        }
    }

    

}
