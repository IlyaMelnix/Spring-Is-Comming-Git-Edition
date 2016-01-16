using UnityEngine;
using System.Collections;

public class bow : MonoBehaviour {

    Vector2 point;
    bool isReady = false;

    public GameObject arrow;
    float timer; //таймер до следующего выстрела
    public float reload; //время перезарядки лука

    float maxDistance;
    float mouseDistance;
    float delta;

    void Start () {
        point = new Vector2(transform.position.x , transform.position.y); //- transform.parent.localScale.x, - transform.parent.localScale.y
        transform.RotateAround(point, new Vector3(0, 0, -1), 90f); //лук поднимается снизу вверх в начале
        maxDistance = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,10)), transform.position);
    }
	
	void Update () {
        timer -= Time.deltaTime; //уменьшение времени до следующего выстрела

        //поворот лука только относительно положения мыши по x
        //--------------начало------------------
        //float delta = ( (Input.mousePosition.x - transform.position.x) / (Screen.width - transform.position.x) );
        //if( transform.eulerAngles.z > (365 + 45 * (delta - 1)) )
        //{
        //    transform.RotateAround(point, new Vector3(0, 0, -1), 70 * Time.deltaTime);
        //}
        //if( transform.eulerAngles.z < (355 + 45 * (delta - 1)) )
        //{
        //    transform.RotateAround(point, new Vector3(0, 0, -1), -70 * Time.deltaTime);
        //}
        //---------------конец-----------------------



        //поворот лука за курсором мыши
        //--------------начало------------------
        if (!isReady) //поднятие лука в начале уровня
        {
            transform.Rotate(new Vector3(0, 0, -1), -120 * Time.deltaTime); // some_number * Time.deltaTime - скорость поднятия лука в начале уровня
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 90)
                isReady = true;
        }
        else //слежение лука за курсором мыши
        {
            Vector3 worldPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(worldPos);
            float dx = (worldPos.x - transform.position.x);
            float dy = (worldPos.y - transform.position.y);
            float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            if (dx < 0 || angle > 90)
                angle = 90 + 45;
            if (dy < 0 || angle < 0)
                angle = 0 + 45;

            if (transform.eulerAngles.z > angle + 5 + 45)
            {
                transform.RotateAround(point, new Vector3(0, 0, -1), 160 * Time.deltaTime); // some_number * Time.deltaTime - скорость наводки лука
            }
            if (transform.eulerAngles.z < angle - 5 + 45)
            {
                transform.RotateAround(point, new Vector3(0, 0, -1), -160 * Time.deltaTime); // some_number * Time.deltaTime - скорость наводки лука
            }
            if (Input.GetMouseButton(0) && timer <= 0)
            {
                //float delta = (Input.mousePosition.x / (Screen.width / 2) - 1) * 1.5f;
                GameObject arrowInstance = (GameObject)Instantiate(arrow, transform.position, transform.rotation); //создание стрелы
                gameObject.GetComponent<AudioSource>().Play();
                mouseDistance = Vector3.Distance(new Vector3(dx,dy,0), transform.position);
                delta = mouseDistance / maxDistance;
                if (delta > 1)
                    delta = 1;
                //arrowInstance.transform.Rotate(0, 0, 45); //поворот стрелы на 45 градусов
                arrowInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(10*delta, 0));
                timer = reload; //"обнуление" таймера
            }
        }
        //---------------конец-----------------------    
    }
}
