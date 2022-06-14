using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour
{
	string option1 = "hello";
	string option2 = "goodbye";
	string option3 = "nice weather today";
	string option4 = "oops";

    // Start is called before the first frame update
    void Start()
    {


		
    }

    // Update is called once per frame
    void Update()
    {
		// int rand = UnityEngine.Random.Range(1,5);
		
        // if(rand==1){
		// 	Debug.Log(option1);
		// }
		// else if(rand==2){
		// 	Debug.Log(option2);
		// }
		// else if(rand==3){
		// 	Debug.Log(option3);
		// }
		// else if(rand==4){
		// 	Debug.Log(option4);
		// }

    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collided");
	}
}
