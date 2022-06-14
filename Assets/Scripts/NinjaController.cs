using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public GameObject blackNinja;
    public GameObject redNinja;
    public GameObject greenNinja;
    public GameObject currentNinja;
    public GameObject uzai;

    public bool levelOver;

    // Start is called before the first frame update
    void Start()
    {
        levelOver = this.GetComponent<Manager>().levelOver;
        // get all the ninjas
        blackNinja = GameObject.Find("BlackNinja");
        redNinja = GameObject.Find("RedNinja");
        greenNinja = GameObject.Find("GreenNinja");
        uzai = GameObject.Find("Uzai");
        enableBlack();
        disableRed();
        disableGreen();
    }

    // Update is called once per frame
    void Update()
    {   
        // if game is over, disable ninjas
        levelOver = this.GetComponent<Manager>().levelOver;
        if(levelOver)
        {
            disableAll();
        }
        // check if a ninja is dead, if so, disable it
        if (!blackNinja.GetComponent<NinjaData>().isAlive)
        {
            killBlack();
        }
        if (!redNinja.GetComponent<NinjaData>().isAlive)
        {
            killRed();
        }
        if (!greenNinja.GetComponent<NinjaData>().isAlive)
        {
            killGreen();
        }

        // if current ninja is dead, switch to a different ninja
        if(!currentNinja.GetComponent<NinjaData>().isAlive)
        {
            if(blackNinja.GetComponent<NinjaData>().isAlive)
            {
                enableBlack();
                disableRed();
                disableGreen();
            }
            else if(redNinja.GetComponent<NinjaData>().isAlive)
            {
                enableRed();
                disableBlack();
                disableGreen();
            }
            else if(greenNinja.GetComponent<NinjaData>().isAlive)
            {
                enableGreen();
                disableRed();
                disableBlack();
            }
        }

        // enable back
        if (Input.GetButtonDown("Black Ninja"))
        {
            if (blackNinja.GetComponent<NinjaData>().isAlive == true)
            {
                enableBlack();
                disableRed();
                disableGreen();
            }
            else if (blackNinja.GetComponent<NinjaData>().isAlive == false)
            {
                Debug.Log("Cant enable black");
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }
        }
        

        // enable red
        if (Input.GetButtonDown("Red Ninja"))
        { 
            if (redNinja.GetComponent<NinjaData>().isAlive)
            {
                enableRed();
                disableBlack();
                disableGreen();
            }
            else if (!redNinja.GetComponent<NinjaData>().isAlive)
            {
                Debug.Log("Cant enable red");
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }
        }
        
        
        // enable green
        if (Input.GetButtonDown("Green Ninja"))
        {
            if(greenNinja.GetComponent<NinjaData>().isAlive)
            {
                enableGreen();
                disableBlack();
                disableRed();
            }
            else if (!greenNinja.GetComponent<NinjaData>().isAlive)
            {
                Debug.Log("Cant enable green");
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }
        }
    }

    public void enableBlack()
    {
        Debug.Log("enabling black");
        blackNinja.GetComponent<Ninja>().enabled = true;
        blackNinja.GetComponent<AutoNinja>().enabled = false;
        blackNinja.GetComponent<ThrowShuriken>().enabled = true;
        blackNinja.GetComponent<SpriteOutline>().outlineColor = Color.yellow; 
        currentNinja = blackNinja;
    }

    public void enableRed()
    {
        Debug.Log("enabling red");
        redNinja.GetComponent<Ninja>().enabled = true;
        redNinja.GetComponent<AutoNinja>().enabled = false;
        redNinja.GetComponent<SwordSlash>().enabled = true;
        redNinja.GetComponent<SpriteOutline>().outlineColor = Color.yellow;
        currentNinja = redNinja;
    }

    public void enableGreen()
    {
        Debug.Log("enabling green");
        greenNinja.GetComponent<Ninja>().enabled = true;
        greenNinja.GetComponent<AutoNinja>().enabled = false;
        greenNinja.GetComponent<SpikesAppear>().enabled = true;
        greenNinja.GetComponent<SpriteOutline>().outlineColor = Color.yellow;
        currentNinja = greenNinja;
    }

    void disableBlack()
    {
        blackNinja.GetComponent<Ninja>().enabled = false;
        blackNinja.GetComponent<AutoNinja>().enabled = true;
        blackNinja.GetComponent<ThrowShuriken>().enabled = false;
        blackNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear; 
    }

    void disableRed()
    {
        redNinja.GetComponent<Ninja>().enabled = false;
        redNinja.GetComponent<AutoNinja>().enabled = true;
        redNinja.GetComponent<SwordSlash>().enabled = false;
        redNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear;
    }

    void disableGreen()
    {
        greenNinja.GetComponent<Ninja>().enabled = false;
        greenNinja.GetComponent<AutoNinja>().enabled = true;
        greenNinja.GetComponent<SpikesAppear>().enabled = false;
        greenNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear;
    }

    void killBlack()
    {
        blackNinja.GetComponent<Ninja>().enabled = false;
        blackNinja.GetComponent<AutoNinja>().enabled = false;
        blackNinja.GetComponent<ThrowShuriken>().enabled = false;
        blackNinja.GetComponent<CapsuleCollider2D>().enabled  = false;
        blackNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear; 
        blackNinja.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        blackNinja.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        
    }

    void killRed()
    {
        redNinja.GetComponent<Ninja>().enabled = false;
        redNinja.GetComponent<AutoNinja>().enabled = false;
        redNinja.GetComponent<SwordSlash>().enabled = false;
        redNinja.GetComponent<CapsuleCollider2D>().enabled  = false;
        redNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear;
        redNinja.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        redNinja.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }

    void killGreen()
    {
        greenNinja.GetComponent<Ninja>().enabled = false;
        greenNinja.GetComponent<AutoNinja>().enabled = false;
        greenNinja.GetComponent<SpikesAppear>().enabled = false;
        greenNinja.GetComponent<CapsuleCollider2D>().enabled  = false;
        greenNinja.GetComponent<SpriteOutline>().outlineColor = Color.clear;
        greenNinja.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        greenNinja.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }
    void killUzai()
    {
        //uzai.GetComponent<AILerp>().enabled = false;
        uzai.GetComponent<Uzai>().enabled = false;
        uzai.GetComponent<CapsuleCollider2D>().enabled  = false;
        uzai.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        uzai.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        uzai.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void stopMovement(GameObject ninja)
    {
        ninja.GetComponent<Animator>().SetFloat("Horizontal", 0);
        ninja.GetComponent<Animator>().SetFloat("Vertical", -1);
        ninja.GetComponent<Animator>().SetFloat("Speed", 0);
        ninja.GetComponent<Animator>().SetBool("isAttacking", false);
    }
    void disableAll(){
        // disable black
        killBlack();
        stopMovement(blackNinja);
        // disable red
        killRed();
        stopMovement(redNinja);
        // disable green
        killGreen();
        stopMovement(greenNinja);
        // disable uzai
        //killUzai();
       // stopMovement(uzai);
    }
}
