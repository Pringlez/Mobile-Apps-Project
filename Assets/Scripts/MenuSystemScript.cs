using UnityEngine;
using System.Collections;

public class MenuSystemScript : MonoBehaviour 
{
	public Texture backgroundTexture;
	public GUIStyle labelGameTitle;
	public GUIStyle buttonNewGameStyle;
	public GUIStyle buttonScoreboardStyle;
	public GUIStyle buttonExitStyle;
	public float buttonPadding;
	public AudioClip buttonSound;

	void OnEnable()
	{
		GlobalVariables.scoresChecked = false;
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		GUI.Label (new Rect (Screen.width * .1f, Screen.height * (buttonPadding - .225f), Screen.width * .8f, Screen.height * .21f), "", labelGameTitle);

		if (GUI.Button (new Rect (Screen.width * .245f, Screen.height * (buttonPadding + .01f), Screen.width * .525f, Screen.height * .185f), "", buttonNewGameStyle)) 
		{
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(1));
		}
		
		if (GUI.Button (new Rect (Screen.width * .31f, Screen.height * ((buttonPadding * 2) + .01f), Screen.width * .4f, Screen.height * .185f), "", buttonScoreboardStyle)) 
		{	
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(4));
		}
		
		if (GUI.Button (new Rect (Screen.width * .33f, Screen.height * ((buttonPadding * 3) + .02f), Screen.width * .375f, Screen.height * .185f), "", buttonExitStyle)) 
		{
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(5));
		}
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(5));
		}
	}

	IEnumerator WaitFor(int level) 
	{
		yield return new WaitForSeconds(1.0f);

		if (level == 5) 
		{
			Application.Quit ();	
		} 
		else 
		{
			Application.LoadLevel (level);
		}
	}
}