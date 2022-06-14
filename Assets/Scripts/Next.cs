using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public AudioSource audioSource;
    public Button nextButton;

    // void Start () {
    //     this.GetComponent<LevelLoader>().transitionTime = .5f;
    //     nextButton = this.GetComponent<Button>();
	// 	Button btn = nextButton.GetComponent<Button>();
	// 	btn.onClick.AddListener(TaskOnClick);
	// }	
    // void Update()
    // {
    //     if(Input.GetButtonDown("Red Ninja"))
    //     {
    //          TaskOnClick();
    //     }
    // }

    public void TaskOnClick()
     {
        
        audioSource.Play();
        // if text is not done, quick fill
        if (GameObject.Find("TextForScene").GetComponent<Typewriter>().doneTyping == false)
        {
             GameObject.Find("TextForScene").GetComponent<Typewriter>().typeSpeed = .001f;
             this.GetComponent<LevelLoader>().transitionTime = 1.5f;
        }
		//StartCoroutine(WaitForSound());
        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
             this.GetComponent<LevelLoader>().LoadMenu();
        }
        this.GetComponent<LevelLoader>().LoadNextLevel();
        
        
	}

    // IEnumerator WaitForTextRead()
    // {
    //     //GameObject.Find("TextForScene").GetComponent<Typewriter>().typeSpeed = .007f;
    //     yield return new WaitForSeconds(3f);
    //     //this.GetComponent<LevelLoader>().LoadNextLevel();
    // }

//     IEnumerator WaitForSound()
//     {
//         //GameObject.Find("TextForScene").GetComponent<Typewriter>().typeSpeed = .007f;
//         yield return new WaitForSeconds(.5f);
//         //this.GetComponent<LevelLoader>().LoadNextLevel();
//     }
 }
