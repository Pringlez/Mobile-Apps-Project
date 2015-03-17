using UnityEngine;

namespace UserControl.Player 
{
	public class Character2DControl : MonoBehaviour 
	{
		[SerializeField] private float maxSpeed = 11.5f;
		[SerializeField] private float jumpForce = 690f;	
		
		[SerializeField] private bool airControl = false;
		[SerializeField] private LayerMask whatIsGround;
		
		private Transform groundCheck;
		private float groundedRadius = .2f;
		private bool grounded = false;
		private Transform ceilingCheck;
		private Animator anim;
		
		private void Awake() 
		{
			groundCheck = transform.Find("GroundCheck");
			ceilingCheck = transform.Find("CeilingCheck");
			anim = GetComponent<Animator>();
		}
		
		private void FixedUpdate() 
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
			anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		}
		
		public void Move(float move, bool crouch, bool jump) 
		{
			if (grounded || airControl)
			{
				anim.SetFloat("Speed", Mathf.Abs(move));
				rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);
			}

			if (grounded && jump && anim.GetBool("Ground") && !audio.isPlaying && GlobalVariables.stamina > 0.07f) 
			{
				grounded = false;
				anim.SetBool("Ground", true);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
				
				if(jump && !audio.isPlaying){
					StaminaBar.DecreaseStamina(0.09f);
					audio.Play();
				}
			}
		}
	}
}