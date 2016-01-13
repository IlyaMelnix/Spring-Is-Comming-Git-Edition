using UnityEngine;
using System.Collections;

public class bow : MonoBehaviour {

    Vector2 point;
    bool isReady = false;

	// Use this for initialization
	void Start () {
        point = new Vector2(transform.position.x , transform.position.y); //- transform.parent.localScale.x, - transform.parent.localScale.y
        transform.RotateAround(point, new Vector3(0, 0, -1), 90f); //лук поднимается снизу вверх в начале
    }
	
	// Update is called once per frame
	void Update () {
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
        if (!isReady)//начальное поднятие лука
        {
            transform.Rotate(new Vector3(0, 0, -1), -90 * Time.deltaTime);
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 90)
                isReady = true;
        }
        else
        {
            Vector3 worldPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(worldPos);
            float dx = (worldPos.x - transform.position.x);
            float dy = (worldPos.y - transform.position.y);
            float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            if (dx < 0)
                angle = 90;
            if (dy < 0)
                angle = 0;

            if (transform.eulerAngles.z > angle + 2)
            {
                transform.RotateAround(point, new Vector3(0, 0, -1), 90 * Time.deltaTime);
            }
            if (transform.eulerAngles.z < angle - 2)
            {
                transform.RotateAround(point, new Vector3(0, 0, -1), -90 * Time.deltaTime);
            }
        }
        //---------------конец-----------------------    
    }
}
