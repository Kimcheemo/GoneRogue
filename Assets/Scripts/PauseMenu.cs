using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, howToMenu;
    public GameObject pauseFirst, howToFirst, howToClosed;

    public GameObject loadingScreen;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Menu") || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            // clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // set resume to selected in pause menu
            EventSystem.current.SetSelectedGameObject(pauseFirst);


        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            
        }

    }

    public void openHowTo()
    {
        howToMenu.SetActive(true);

        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set back to selected in pause menu
        EventSystem.current.SetSelectedGameObject(howToFirst);
    }

    public void closeHowTo()
    {
        howToMenu.SetActive(false);

        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set back to selected in pause menu
        EventSystem.current.SetSelectedGameObject(howToClosed);
    }

    public void ReturnToMenu()
    {
        StartCoroutine(Menu());
    }

    public IEnumerator Menu()
    {
        float delay = .5f;
        float pauseTime = Time.realtimeSinceStartup + delay;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        Debug.Log("Activating Loading Screen");
        loadingScreen.SetActive(true);
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Music"));//.GetComponent<MusicClass>().StopMusic();

    }

    
}
