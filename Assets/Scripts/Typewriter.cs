using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
    TextMeshProUGUI tmp;
    int totalChar;
    int counter;
    int visible;
    string text;
    AudioSource audioSource;

    public bool doneTyping;

    public float typeSpeed = .007f;

    // Start is called before the first frame update
    void Awake()
    { 
        doneTyping = false;
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.ForceMeshUpdate();
        totalChar = tmp.textInfo.characterCount;
    }
    IEnumerator Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        text = tmp.text;
        //totalChar = tmp.TMP_Text.characterCount;
        int counter = 0;

       for (int i = 0; i < totalChar; i ++)
       {
            visible = counter % (totalChar + 1);
            tmp.maxVisibleCharacters = visible;
            
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            
            counter += 1;

            yield return new WaitForSeconds(typeSpeed);
       }
       tmp.maxVisibleCharacters = totalChar;
       audioSource.Stop();
       doneTyping = true;
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
    

}
