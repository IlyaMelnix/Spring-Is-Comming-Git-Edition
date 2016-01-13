using UnityEngine;
using System.Collections;

public class pointOfNoReturn : MonoBehaviour {
    

    // CHECKOUT ERE!!!
    // переделать полностью скрипт для врага - общее в одно, индивидуальное в другое
    // либо тут сделать проверку, чтоб на летающем не срабытвало
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "airEnemy" || other.gameObject.tag == "groundEnemy")
        {
            Debug.Log("Enemy Here");
            if (PlayerPrefs.HasKey("burning"))
            {
                PlayerPrefs.SetInt("burning", PlayerPrefs.GetInt("burning") - 1);
                PlayerPrefs.Save();
            }
        }
    }
}
