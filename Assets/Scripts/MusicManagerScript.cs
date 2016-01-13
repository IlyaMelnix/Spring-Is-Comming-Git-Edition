using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour
{

    public void SetVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }
}