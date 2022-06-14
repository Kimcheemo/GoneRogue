using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public float fadeTime;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu Song");
    }

    public void FadeOutMusic()
    {
       StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("Menu Song", fadeTime));
    }

    // void Update()
    // {
    //     if(Input.GetButtonDown("Green Ninja"))
    //     {
    //         audioSource.Play();
    //         this.GetComponent<LevelLoader>().LoadNextLevel();
    //         this.FadeOutMusic();
    //     }
    // }
}
