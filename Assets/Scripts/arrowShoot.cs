using UnityEngine;
using System.Collections;

public class arrowShoot : MonoBehaviour {

    public GameObject arrow;
    float timer; //таймер до следующего выстрела
    public float reload; //время перезарядки лука

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime; //уменьшение времени до следующего выстрела
        if(Input.GetMouseButton(0) && timer<=0)
        {
            float delta = (Input.mousePosition.x / (Screen.width / 2) - 1) * 1.5f;
            GameObject arrowInstance = (GameObject) Instantiate(arrow, transform.position, transform.rotation); //создание стрелы
            //arrowInstance.transform.Rotate(0, 0, 45); //поворот стрелы на 45 градусов
            //arrowInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 + delta, 3)); //добавляем силу, действующую вперед и вверх
            arrowInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(7, 0));
            timer = reload; //"обнуление" таймера
        }
	}
}
