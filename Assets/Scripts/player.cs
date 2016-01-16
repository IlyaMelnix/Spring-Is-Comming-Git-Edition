using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public Animator IvanAnimator;
    // Use this for initialization
    void Start () {
        SavePrefs.Start(); //сохранение начальных значений переменных
	}
	
	// Update is called once per frame
	void Update () {
	}
}
