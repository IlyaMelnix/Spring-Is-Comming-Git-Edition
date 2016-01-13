using UnityEngine;
using System.Collections;

public class SavePrefs : MonoBehaviour {

	// Use this for initialization
	public static void Start () {
        PlayerPrefs.SetInt("fire", 1);
        PlayerPrefs.SetInt("burning", 1);
        PlayerPrefs.SetInt("killedEnemiesCount", 0);
        PlayerPrefs.SetInt("killEnemiesToGetFire", Random.Range(3, 9));

        PlayerPrefs.Save();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
