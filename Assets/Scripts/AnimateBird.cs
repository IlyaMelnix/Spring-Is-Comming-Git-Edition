using UnityEngine;
using System.Collections;

public class AnimateBird : MonoBehaviour {
    Animator anim;
    bool n = true;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (n)
        {
            anim.SetTrigger("fly");
            n = false;
        }
        else
        {
            anim.SetTrigger("idle");
            n = true;
        }
    }
}
