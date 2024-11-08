using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Creature
{

	
	// Start is called before the first frame update
	public float speedRate=1.0f;
	public float accelerateRate = 2.0f;
	public Rigidbody2D rb;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{  
		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveX, moveY).normalized * speedRate;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			rb.velocity *= accelerateRate;
		}
	}

	
	

}
