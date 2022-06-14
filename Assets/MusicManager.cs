using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
     public static MusicManager instance;
    void Awake()
    {
        if(instance == null)
            instance = this;
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartDelay());
        FindObjectOfType<AudioManager>().Play("Theme");
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
