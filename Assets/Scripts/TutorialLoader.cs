using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLoader : MonoBehaviour
{
    public float transitionTime; 

    void Start()
    {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        // load the nect scene in the build hierarchy
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        // load level
        SceneManager.LoadScene(levelIndex);
    }
}

