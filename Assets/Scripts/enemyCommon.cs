using UnityEngine;
using System.Collections;

public class enemyCommon : MonoBehaviour {

    public GameObject fire;
    
    public float speed;
    public float deathTime;
    bool isRotate = false;

    public float health;
    float healthScaleX;
    float currentHealth;
    
	void Start () {
        currentHealth = health;
        healthScaleX = transform.Find("health").gameObject.transform.localScale.x;
    }
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (isRotate)
        {
            transform.RotateAround(new Vector2(transform.position.x, transform.position.y - transform.localScale.y*2), new Vector3(0, 0, -1), 90 * Time.deltaTime);
        }
        if (transform.position.x <= -13) //удалять врага, если он вышел за пределы игрового поля (за Бабу, слева)
        {
            Destroy(gameObject);
        }        
    }

    public void bubble()
    {
        --currentHealth;
        if (currentHealth >= 0)
            transform.Find("health").gameObject.transform.localScale -= new Vector3(healthScaleX / health, 0.0f, 0.0f);
        if (currentHealth <= 0)
        {
            speed = 0;            
            foreach (Transform child in transform) //после смерти врага в него не будут больше втыкаться стрелы
            {
                if (child.gameObject.tag == "enemyParts")
                {
                    child.GetComponent<enemyParts>().disableCollider();
                }
            }
            //isRotate = true;
            Destroy(gameObject, deathTime);
            if (PlayerPrefs.HasKey("killedEnemiesCount") && PlayerPrefs.HasKey("killEnemiesToGetFire"))
            {
                int count = PlayerPrefs.GetInt("killedEnemiesCount");
                ++count;
                if (count == PlayerPrefs.GetInt("killEnemiesToGetFire"))
                {
                    count = 0;
                    GameObject fireInstance = (GameObject)Instantiate(fire, transform.position, transform.rotation);
                    if (gameObject.tag == "airEnemy")//падение огня на 4.57 вниз от места создания для летающих врагов
                        fireInstance.GetComponent<fire>().dy = 4.57f;
                    if (gameObject.tag == "groundEnemy")//падение огня на 1.2 вниз от места создания для наземных врагов
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
