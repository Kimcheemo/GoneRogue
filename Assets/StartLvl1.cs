using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLvl1 : MonoBehaviour
{
    public AudioSource audioSource;
    public Button skipButton;

    void Start () {
        skipButton = this.GetComponent<Button>();
		Button btn = skipButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}	
    void Update()
    {
        if(Input.GetButtonDown("Green Ninja"))
        {
             TaskOnClick();
        }
    }

     void TaskOnClick(){
		audioSource.Play();
        this.GetComponent<LevelLoader>().LoadLevel1();
	}
}
