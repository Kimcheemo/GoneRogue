using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool levelOver;
    GameObject uzai;
    public GameObject[] coins;
    public int numCoins;
    public float uzaiHealth;
    public GameObject winLevelUI;
    public GameObject loseLevelUI;
    public GameObject gameOverUI;
    public GameObject youWinUI;
    // Full and empty hearts
    public GameObject fullHeart;
    public GameObject emptyHeart;
    // Location of hearts
     public Transform hearts;
     public List<Transform> heartList;
     Transform[] heartSpots;
     Transform location1;
     Transform location2;
     Transform location3;
     GameObject heart1;
     GameObject heart2;
     GameObject heart3;

    LevelLoader loader;

     // number of lives during game
    public int lives;

    // endstate reached
    bool endStateReached;
    
    // number of dead ninjas, game ends if all three ninjas died
    public int numDeadNinjas;
    // Start is called before the first frame update
    void Start()
    {
        numDeadNinjas = 0;
        // put all the hearts in an array
        foreach(Transform node in hearts)
        {
            heartList.Add(node);
        }
        heartSpots = heartList.ToArray();
        // get heart spot locations
        location1 = heartSpots[0];
        location2 = heartSpots[1];
        location3 = heartSpots[2];

        StartCoroutine(StartDelay());
        levelOver = false;
        endStateReached = false;
        uzai = GameObject.Find("Uzai");
        uzaiHealth = uzai.GetComponent<Uzai>().currentHealth;
        loader = this.GetComponent<LevelLoader>();
        lives = PlayerPrefs.GetInt("Lives");
        winLevelUI = GameObject.Find("Win_LoseUICanvas").transform.GetChild(0).gameObject;
        loseLevelUI = GameObject.Find("Win_LoseUICanvas").transform.GetChild(1).gameObject;
        gameOverUI = GameObject.Find("Win_LoseUICanvas").transform.GetChild(2).gameObject;
        youWinUI = GameObject.Find("Win_LoseUICanvas").transform.GetChild(3).gameObject;


        // instantiate hearts
        if (lives == 3)
        {
            heart1 = Instantiate(fullHeart, location1.position, Quaternion.Euler(0f, 0f, 0f));

            heart2 = Instantiate(fullHeart, location2.position, Quaternion.Euler(0f, 0f, 0f));

            heart3 = Instantiate(fullHeart, location3.position, Quaternion.Euler(0f, 0f, 0f));
        }

        if (lives == 2)
        {
            heart1 = Instantiate(fullHeart, location1.position, Quaternion.Euler(0f, 0f, 0f));

            heart2 = Instantiate(fullHeart, location2.position, Quaternion.Euler(0f, 0f, 0f));

            heart3 = Instantiate(emptyHeart, location3.position, Quaternion.Euler(0f, 0f, 0f));
        }

        if (lives == 1)
        {
            heart1 = Instantiate(fullHeart, location1.position, Quaternion.Euler(0f, 0f, 0f));

            heart2 = Instantiate(emptyHeart, location2.position, Quaternion.Euler(0f, 0f, 0f));

            heart3 = Instantiate(emptyHeart, location3.position, Quaternion.Euler(0f, 0f, 0f));
        }

         if (lives == 0)
        {
            heart1 = Instantiate(emptyHeart, location1.position, Quaternion.Euler(0f, 0f, 0f));

            heart2 = Instantiate(emptyHeart, location2.position, Quaternion.Euler(0f, 0f, 0f));

            heart3 = Instantiate(emptyHeart, location3.position, Quaternion.Euler(0f, 0f, 0f));
        }

             
        // Get number of coins
        coins = GameObject.FindGameObjectsWithTag("Coin");
        numCoins = coins.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Get number of coins
        coins = GameObject.FindGameObjectsWithTag("Coin");
        numCoins = coins.Length;
        uzaiHealth = uzai.GetComponent<Uzai>().currentHealth;

        if(numCoins > 0 && uzaiHealth <= 0 && !endStateReached)
        {
            if (PlayerPrefs.GetInt("CurrentLevel") == 4)
            {
                StartCoroutine(wingame());
            }
            else
            {
                StartCoroutine(win());
            }
            
        }
        if(numCoins <= 0 && lives > 0 && !endStateReached)
        {
            StartCoroutine(lose());
            
        }  
        if (numDeadNinjas == 3 && lives > 0 && !endStateReached)
        {
            StartCoroutine(lose());
        } 
        if(numCoins <= 0 && lives == 0 && !endStateReached) 
        {
            StartCoroutine(gameover());
        } 
        if(numDeadNinjas == 3 && lives == 0 && !endStateReached) 
        {
            StartCoroutine(gameover());

        } 
           
    }

    
    IEnumerator lose()
    {
        endStateReached = true;
        levelOver = true;
        PlayerPrefs.SetInt("Rounds", PlayerPrefs.GetInt("Rounds") + 1);
        // activate lose UI
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Play("Lose Level");
        loseLevelUI.SetActive(true);
        yield return new WaitForSeconds(3f);

        // lose a life and pop heart
        if (lives == 3)
        {
            heart3 = Instantiate(emptyHeart, location3.position, Quaternion.Euler(0f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Heart Pop");
        }
        else if (lives == 2)
        {
            heart2 = Instantiate(emptyHeart, location2.position, Quaternion.Euler(0f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Heart Pop");
        }
        else if (lives == 1)
        {
            heart1 = Instantiate(emptyHeart, location1.position, Quaternion.Euler(0f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Heart Pop");
        }

        PlayerPrefs.SetInt("Lives", lives - 1);
    
        yield return new WaitForSeconds(1.5f);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        
    }

    IEnumerator win()
    {
        endStateReached = true;
        levelOver = true;
        PlayerPrefs.SetInt("Rounds", PlayerPrefs.GetInt("Rounds") + 1);
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        // activate win UI
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Play("Win Level");
        winLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        loader.LoadNextLevel();
    }

    IEnumerator gameover()
    {
        endStateReached = true;
        levelOver = true;
        PlayerPrefs.SetInt("Rounds", PlayerPrefs.GetInt("Rounds") + 1);
        // activate game over UI
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Play("Game Over");
        if( GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        }
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        loader.LoadMenu();
    }

    IEnumerator wingame()
    {
        endStateReached = true;
        levelOver = true;
        PlayerPrefs.SetInt("Rounds", PlayerPrefs.GetInt("Rounds") + 1);
        // activate game over UI
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Play("Win Level");
        if( GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        }
        youWinUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        loader.LoadNextLevel();
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
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
}
