using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime;
    public GameObject loadingScreen;

    //public Slider slider;
    
    void Start()
    {
        //loadingScreen = GameObject.FindGameObjectWithTag("LoadScreen");
        loadingScreen.SetActive(false);
    }
    public void LoadNextLevel()
    {
        // load the nect scene in the build hierarchy
        StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevelAsync(12));
    }
    public void LoadMenu()
    {
        StartCoroutine(LoadLevelAsync(0));
    }
    public void LoadHowTo()
    {
        StartCoroutine(LoadLevelAsync(11));
    }

      public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    // IEnumerator LoadLevel(int levelIndex)
    // {
    //     yield return new WaitForSeconds(transitionTime);
    //     // load level
    //     SceneManager.LoadScene(levelIndex);
    // }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(transitionTime);
        Application.Quit();
    }

    IEnumerator LoadLevelAsync(int levelIndex)
    {
        Debug.Log("Loading" + levelIndex);
        yield return new WaitForSeconds(transitionTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        Debug.Log("Activating Loading Screen");
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
           // slider.value = progress;
            

            yield return null;

        }
    }
}
