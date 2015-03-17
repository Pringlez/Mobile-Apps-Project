using UnityEngine;
using System.Collections;

public class ScoreboardScript : MonoBehaviour 
{
	public Texture backgroundTexture;
	public GUIStyle labelScores;
	public GUIStyle labelPlayerOne;
	public GUIStyle labelPlayerTwo;
	public GUIStyle labelPlayerThree;
	public GUIStyle buttonBackStyle;
	public GUIStyle customTextStyle;
	public float padding;
	public AudioClip buttonSound;
	private string playerOneText;
	private string playerTwoText;
	private string playerThreeText;

	void OnEnable()
	{
		playerOneText = PlayerPrefs.GetString ("Player1");
		playerTwoText = PlayerPrefs.GetString ("Player2");
		playerThreeText = PlayerPrefs.GetString ("Player3");
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		GUI.Label (new Rect (Screen.width * .33f, Screen.height * (padding - .22f), Screen.width * .35f, Screen.height * .14f), "", labelScores);
		GUI.Label (new Rect (Screen.width * .07f, Screen.height * (padding * 1 - .04f), Screen.width * .42f, Screen.height * .12f), "", labelPlayerOne);
		GUI.Label (new Rect (Screen.width * .18f, Screen.height * (padding * 1 + .085f), Screen.width * .3f, Screen.height * .1f), playerOneText, customTextStyle);
		GUI.Label (new Rect (Screen.width * .07f, Screen.height * (padding * 2 - .04f), Screen.width * .42f, Screen.height * .12f), "", labelPlayerTwo);
		GUI.Label (new Rect (Screen.width * .18f, Screen.height * (padding * 2 + .085f), Screen.width * .3f, Screen.height * .1f), playerTwoText, customTextStyle);
		GUI.Label (new Rect (Screen.width * .07f, Screen.height * (padding * 3 - .04f), Screen.width * .42f, Screen.height * .12f), "", labelPlayerThree);
		GUI.Label (new Rect (Screen.width * .18f, Screen.height * (padding * 3 + .085f), Screen.width * .3f, Screen.height * .1f), playerThreeText, customTextStyle);

		if (GUI.Button (new Rect (Screen.width * .67f, Screen.height * .84f, Screen.width * .3f, Screen.height * .13f), "", buttonBackStyle)) 
		{
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(0));
		}
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{	
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(0));
		}
	}
	
	IEnumerator WaitFor(int level) 
	{
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel (level);
	}
}