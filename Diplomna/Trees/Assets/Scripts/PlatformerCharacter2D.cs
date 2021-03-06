using UnityEngine;
//using Inventory;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;
	int n = 0;
	bool touchEnemy = false;
	public GameObject enemy;

	void Start() {

	}

    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
	}

	void Update() {


	}

	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		// Set the vertical animation
		anim.SetFloat("vSpeed", rigidbody.velocity.y);
		anim.SetFloat("vSpeed", rigidbody.velocity.x);

		if (Input.GetKeyUp (KeyCode.Space))  {
			print ("Boiboi");

			onAttack();

		}
	}


	public void Move(float move, float moveTop, bool crouch, bool jump)
	{


		// If crouching, check to see if the character can stand up
		if(!crouch && anim.GetBool("Crouch"))
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
				crouch = true;
		}

		// Set whether or not the character is crouching in the animator
		anim.SetBool("Crouch", crouch);

		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(move));
			anim.SetFloat("Speed", Mathf.Abs(moveTop));

			// Move the character
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, move * maxSpeed);
			rigidbody.velocity = new Vector2(moveTop * maxSpeed, rigidbody.velocity.y);

			// If the input is moving the player right and the player is facing left...
			if(moveTop > 0  && !facingRight) 
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(moveTop < 0 && facingRight)
				// ... flip the player.
				Flip();
		}

        // If the player should jump...
        if (grounded && jump) {
            // Add a vertical force to the player.
            anim.SetBool("Ground", false);
            rigidbody.AddForce(new Vector2(0f, jumpForce));
        }
	}

	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter(Collision coll) {
		touchEnemy = false;

		if (coll.gameObject.tag == "Enemy") {
			touchEnemy = true;
			print ("Pipash Zaeka");
		//	touchEnemy = false;
			if (EnemyHealth.curHealthEn == 0) {
				Destroy (coll.gameObject);
			}
						//		this.GetComponent<PlayerHealth>().curHealth -= 1;

		} else if (coll.gameObject.tag == "Loot") {
			print ("Pipash purjola");
//			TreesInventory.Inventory[TreesInventory.Inventory.Length-1] = coll.gameObject;
		}
	
	}  

	void onAttack() {
		//if(touchEnemy == true) {
		//	print ("Ready to attack");
			while ((touchEnemy == true) && (EnemyHealth.curHealthEn >= 0)) {
				EnemyHealth.curHealthEn -= 3;
				print(EnemyHealth.curHealthEn);
				touchEnemy = false;
				/*if (EnemyHealth.curHealthEn <=0) {
					Destroy (enemy);
				} */
			}

	}
}



