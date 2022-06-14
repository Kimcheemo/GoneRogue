using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;
		public Animator animator;
		public GameObject blackNinja;
		public GameObject redNinja;
		public GameObject greenNinja;
		public int state;
		public Transform moveSpots;
		public GameObject shieldEffect;
		public List<GameObject> items;
		float coinTimer = 0f;
		
		public Transform FleeDestination;
		public Transform left, right, top, bottom;
		public Transform[] moveSpotsArr;
		public int randomSpot;
		public LayerMask mask;


		void OnEnable () {

			blackNinja = GameObject.Find("BlackNinja");
        	redNinja = GameObject.Find("RedNinja");
        	greenNinja = GameObject.Find("GreenNinja");
			ai = GetComponent<IAstarAI>();

			
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
			
		}
        
		void Start()
		{	
			// uzai will start collecting coins (state 0) and will not have the shield activated
			state = 0;
			shieldEffect.GetComponent<Animator>().enabled = false;
			shieldEffect.SetActive(false);

			moveSpotsArr = moveSpots.GetComponentsInChildren<Transform>();
			randomSpot = 0;

		
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
			Animate();
		
			// get position of each ninja with uzai
			float blackDist = Vector2.Distance(blackNinja.transform.position, this.transform.position);
			float redDist = Vector2.Distance(redNinja.transform.position, this.transform.position);
			float greenDist = Vector2.Distance(greenNinja.transform.position, this.transform.position);
			
			float max = 0f;
			float min = 500f; //if he stops, this min variable should be about 500f
			
			string[] collidableLayers = {"Ninjas", "Environment"};
			int layersToCheck = LayerMask.GetMask(collidableLayers);

			RaycastHit2D hitBlack = Physics2D.Linecast(transform.position, blackNinja.transform.position, layersToCheck);
			RaycastHit2D hitRed = Physics2D.Linecast(transform.position, redNinja.transform.position, layersToCheck);
			RaycastHit2D hitGreen = Physics2D.Linecast(transform.position, greenNinja.transform.position, layersToCheck);
			
			
			// if state 0, collect coins
			if (state == 0){

				// ensures that the shield is not present when not in state 1
				shieldEffect.GetComponent<Animator>().enabled = false;
				shieldEffect.SetActive(false);
				
				int coinCount = 0;
				coinTimer += Time.deltaTime;

				// prevents uzai from not being able to choose between two paths that are the same distance
				// if(coinTimer > 0.25f){

					// collect coins
					foreach(GameObject silgol in items){
						if(silgol != null){

							float coinDist = Vector2.Distance(silgol.transform.position, this.transform.position);
							coinCount++;

							// get smallest distance 
							if(coinDist < min - .2){
								min = coinDist;		// found smallest distance
								target = silgol.transform;	// set target to the specific coin with the smallest distance
							}		
						}
					}
					//coinTimer = 0f;	
				//}
				
				// this is to prevent "coin guarding" 
				// if there is less than 10 coins left, he will no longer run from the ninjas
				if(coinCount > 10){

					// only measures distance if ninja is in line of sight
					if(blackDist < 5f && blackNinja != null && hitBlack.collider.gameObject == blackNinja.gameObject)
					{
						StartCoroutine(flee());

						shieldEffect.GetComponent<Animator>().enabled = false;
						shieldEffect.SetActive(false);
						
						
						// foreach(Transform node in moveSpots){
						// 	if(node != null){
						// 		float nodeDistBlack = Vector2.Distance(node.position, blackNinja.transform.position);
						// 		if(nodeDistBlack > max){
						// 			max = nodeDistBlack;	
						// 			target = node;	// set target to the specific node with the farthest distance from each ninja
						// 		}
						// 	}
						// }					
					}
					else if(redDist < 5f && redNinja != null && hitRed.collider.gameObject == redNinja.gameObject)
					{
						StartCoroutine(flee());

						shieldEffect.GetComponent<Animator>().enabled = false;
						shieldEffect.SetActive(false);
						
						// foreach(Transform node in moveSpots){
						// 	if(node != null){
						// 		float nodeDistRed = Vector2.Distance(node.position, redNinja.transform.position);
						// 		if(nodeDistRed > max){
						// 			max = nodeDistRed;	
						// 			target = node;	// set target to the specific node with the farthest distance from each ninja
						// 		}
						// 	}
						// }
					}
					else if(greenDist < 5f && greenNinja != null && hitGreen.collider.gameObject == greenNinja.gameObject)
					{
						StartCoroutine(flee());

						shieldEffect.GetComponent<Animator>().enabled = false;
						shieldEffect.SetActive(false);
						
						// foreach(Transform node in moveSpots){
						// 	if(node != null){
						// 		float nodeDistGreen = Vector2.Distance(node.position, greenNinja.transform.position);
						// 		if(nodeDistGreen > max){
						// 			max = nodeDistGreen;	
						// 			target = node;	// set target to the specific node with the farthest distance from each ninja
						// 		}
						// 	}
						// }			
					}
				}					
			}
			else if (state == 1){// if state 1 chase ninjas
				
				// Uzai shield effect enabled when in gold coin mode
				shieldEffect.GetComponent<Animator>().enabled = true;
				shieldEffect.SetActive(true);

				target = getClosestNinja();
				
			}
			else if(state == 2){
				
				// run from ninjas
				Vector3 direction = getClosestNinja().position - transform.position;
				Vector3 nodePos = transform.position - direction;
				
				
				var FleePos = AstarPath.active.GetNearest(nodePos).node.position;
				FleeDestination.position = (Vector3) FleePos;
				target = FleeDestination;

				var uzaiNode = AstarPath.active.GetNearest(transform.position).node.position;
				
				// if uzai is stuck target moveSpots instead
				if(uzaiNode == FleePos){

					state = 3;
					foreach(Transform node in moveSpots){
						if(node != null){
							float nodeDist = Vector2.Distance(node.position, getClosestNinja().position);
							if(nodeDist > max){
								max = nodeDist;	
								target = node;	// set target to the specific node with the farthest distance from each ninja
							}
						}
					}

				// 	Vector3 up = FleeDestination.position + new Vector3 (0, 1, 0);
				// 	Vector3 down = FleeDestination.position + new Vector3 (0, -1, 0);
				// 	Vector3 left = FleeDestination.position + new Vector3 (-1, 0, 0);
				// 	Vector3 right = FleeDestination.position + new Vector3 (1, 0, 0);

				// 	var upNode = AstarPath.active.GetNearest(up).node.position;
				// 	var downNode = AstarPath.active.GetNearest(down).node.position;
				// 	var leftNode = AstarPath.active.GetNearest(left).node.position;
				// 	var rightNode = AstarPath.active.GetNearest(right).node.position;

				// 	float upDist = Vector2.Distance(FleeDestination.position, (Vector3) upNode);
				// 	float downDist = Vector2.Distance(FleeDestination.position, (Vector3) downNode);
				// 	float leftDist = Vector2.Distance(FleeDestination.position, (Vector3) leftNode);
				// 	float rightDist = Vector2.Distance(FleeDestination.position, (Vector3) rightNode);

				// 	bool upAvail = (upDist > 0 && upDist <= 1.1f);
				// 	bool downAvail = (downDist > 0 && downDist <= 1.1f);
				// 	bool leftAvail = (leftDist > 0 && leftDist <= 1.1f);
				// 	bool rightAvail = (rightDist > 0 && rightDist <= 1.1f);

				// 	if(upAvail){
				// 		FleeDestination.position = (Vector3) upNode;
				// 	}
				// 	else if(downAvail){
				// 		FleeDestination.position = (Vector3) downNode;
				// 	}
				// 	else if(leftAvail){
				// 		FleeDestination.position = (Vector3) leftNode;
				// 	}
				// 	else if(rightAvail){
				// 		FleeDestination.position = (Vector3) rightNode;
				// 	}
				 }


				// int i = 0;
				// float angle = Mathf.Deg2Rad * Vector2.Angle(direction, Vector2.zero);
				// while(uzaiNode == FleePos && i < 32){
					
				// 	angle += 0.2f;
				// 	direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized * 100;
				// 	nodePos = transform.position - direction;
				// 	FleePos = AstarPath.active.GetNearest(nodePos).node.position;
				// 	FleeDestination.position = (Vector3) FleePos;
				// 	i++;
				// 	Debug.Log(angle);
				// 	// Debug.Log(transform.forward);
				// }


				// if(FleeDestination.position == transform.position){
				// 	// check for collision
				// 	RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.forward, mask);

				// 	// move to random 
				// 	if(hit.collider == null)
				// 	{
				// 		target = moveSpotsArr[randomSpot];
				// 	}
				// 	// choose new random spot to try
				// 	else
				// 	{       
				// 		randomSpot = Random.Range(0, moveSpotsArr.Length);
				// 	}
				// }
			}
		}

		Transform getClosestNinja(){

			Transform closest = blackNinja.transform;

			// find the distance between self and each ninja
			float blackDist = Vector2.Distance(blackNinja.transform.position, this.transform.position);
			float redDist = Vector2.Distance(redNinja.transform.position, this.transform.position);
			float greenDist = Vector2.Distance(greenNinja.transform.position, this.transform.position);
			
			// choose the smallest distance
			// set target to that ninja
			if(blackDist < redDist && blackDist < greenDist){
				closest = blackNinja.transform;
			}
			else if(redDist < blackDist && redDist < greenDist){
				closest = redNinja.transform;
			}
			else if(greenDist < redDist && greenDist < blackDist){
				closest = greenNinja.transform;
			}

			return closest;
		}



		void Animate()
		{
			if(target != null){
				var rb = GetComponent<AIPath>();
				Vector2 movement = rb.velocity;
			
				if (movement != Vector2.zero)
				{
					animator.SetFloat("Horizontal", movement.x);
					animator.SetFloat("Vertical", movement.y);
				}
				animator.SetFloat("Speed", movement.sqrMagnitude);
			}	
			else
			{
				animator.SetFloat("Horizontal", 0);
				animator.SetFloat("Vertical",0);
				animator.SetFloat("Speed", 0);
			}
		}

		public IEnumerator chase()
		{
			// uzai will chase for 5 seconds
			state = 1;
			yield return new WaitForSeconds(5f);
			state = 0;
		}

		public IEnumerator flee()
		{
			// uzai will flee for 2 seconds and then proceed to collect coins again
			state = 2;
			yield return new WaitForSeconds(2.5f);
			
			// ensures that uzai will not flee when in gold coin mode (state 1)
			if(state >= 2){
				state = 0;
			}		
		}
	}
}

