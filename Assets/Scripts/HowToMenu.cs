using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToMenu : MonoBehaviour
{
    public GameObject howto;
    // Start is called before the first frame update
    void Start()
    {
       howto = GameObject.Find("InstructionsCanvas");
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButton("Menu")){
           howto.SetActive(true);
       } 
       else
       {
           howto.SetActive(false);
       }
    }
}
