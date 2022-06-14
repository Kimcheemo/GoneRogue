using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameStart : MonoBehaviour
{
    bool musicStarted;
    // Start is called before the first frame update
    void Start()
    {
        musicStarted = false;
        StartCoroutine(StartDelay());
        
    }

    void Update()
    {
        if(!musicStarted)
        {
            FindObjectOfType<AudioManager>().Play("Music");
            musicStarted = true;
        }
    }

    IEnumerator StartDelay()
    {
        float delay = 1.5f;
        if(PlayerPrefs.GetInt("Rounds") == 0)
        {
            delay = 4;
            FindObjectOfType<AudioManager>().Play("PacMan Start");
        }
        Time.timeScale = 0f;
        float pauseTime = Time.realtimeSinceStartup + delay;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
    }
}
