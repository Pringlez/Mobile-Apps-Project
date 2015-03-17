using UnityEngine;
using UserControl.CrossPlatformInput;

namespace UserControl.Player 
{
	[RequireComponent(typeof (Character2DControl))]
	public class User2DControl : MonoBehaviour 
	{
		private Character2DControl character;
		private bool jump;
		
		private void Awake() 
		{
			character = GetComponent<Character2DControl>();
		}
		
		private void Update() 
		{
			if (!jump) 
			{
				jump = InputManager.GetButtonDown("Jump");
				
				if (Input.touchCount > 0) 
				{
					jump = true;
				}
			}
			
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				Application.LoadLevel (0);
			}
		}
		
		private void FixedUpdate()
		{
			character.Move(1, false, jump);
			jump = false;
		}		
	}
}