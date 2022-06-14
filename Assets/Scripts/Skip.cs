using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    public AudioSource audioSource;
    public Button skipButton;

    // void Start () {
    //     skipButton = this.GetComponent<Button>();
	// 	Button btn = skipButton.GetComponent<Button>();
	// 	btn.onClick.AddListener(TaskOnClick);
	// }	
    // void Update()
    // {
    //     if(Input.GetButtonDown("Green Ninja"))
    //     {
    //          TaskOnClick();
    //     }
    // }

    public void TaskOnClick(){
		audioSource.Play();
        GameObject.Find("TextForScene").GetComponent<Typewriter>().StopAudio();
        GameObject.Find("TextForScene").GetComponent<Typewriter>().enabled = false;
        this.GetComponent<LevelLoader>().LoadHowTo();
	}
}
