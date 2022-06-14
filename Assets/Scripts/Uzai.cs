using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Uzai : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public AIBase aiBase;
	public float baseSpeed;
	public SpriteRenderer sprite;
	public Animator animator;
	public Rigidbody2D rb;
	public AILerp ailerp;

    // Start is called before the first frame update
    void Start()
    {
		aiBase = GetComponent<AIBase>();
		ailerp = GetComponent<AILerp>();
		baseSpeed = ailerp.speed;
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= 0)
		{
			animator.SetBool("Dead", true);
			ailerp.speed = 0;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
    }
	
	// reduce uzai health
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		FindObjectOfType<AudioManager>().Play("Damage Uzai");
		healthBar.SetHealth(currentHealth);

	}	

	// change uzai speed
	 public IEnumerator SpeedChange(float newSpeed, float timeInSecs)
    {
        ailerp.speed = newSpeed;
        yield return new WaitForSeconds(timeInSecs);
        ailerp.speed = baseSpeed;
    }

	// flash when takes damage
	public IEnumerator Flash()
	{
			sprite.color = Color.clear;
			yield return new WaitForSeconds(.1f);
			sprite.color = Color.white;
			yield return new WaitForSeconds(.1f);
		    sprite.color = Color.clear;
			yield return new WaitForSeconds(.1f);
			sprite.color = Color.white;
			yield return new WaitForSeconds(.1f);
		    sprite.color = Color.clear;
			yield return new WaitForSeconds(.1f);
			sprite.color = Color.white;
			yield return new WaitForSeconds(.1f);
		    sprite.color = Color.clear;
			yield return new WaitForSeconds(.1f);
			sprite.color = Color.white;
		
	}
}
