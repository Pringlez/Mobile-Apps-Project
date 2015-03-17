using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour 
{
	public Texture backgroundTexture;
	public GUIStyle labelGameOver;
	public GUIStyle buttonRetryStyle;
	public GUIStyle buttonQuitStyle;
	public GUIStyle customTextStyle;
	public float buttonPadding;
	public AudioClip buttonSound;
	private int score = 0;
	private string playerName;

	void OnEnable()
	{
		score = PlayerPrefs.GetInt ("Score");
		playerName = PlayerPrefs.GetString ("PlayerName");
		CheckScores (score, playerName);
		GlobalVariables.health = 1f;
		GlobalVariables.stamina = 1f;
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		GUI.Label (new Rect (Screen.width * .22f, Screen.height * (buttonPadding - .225f), Screen.width * .6f, Screen.height * .20f), "", labelGameOver);
		GUI.Label (new Rect (0, (Screen.height * (buttonPadding * 2) - 3f), Screen.width, Screen.height * .2f), playerName + " - " + score, customTextStyle);
	
		if (GUI.Button (new Rect (Screen.width * .32f, Screen.height * buttonPadding + 5f, Screen.width * .375f, Screen.height * .190f), "", buttonRetryStyle)) 
		{
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(2));
		}

		if (GUI.Button (new Rect (Screen.width * .32f, Screen.height * ((buttonPadding * 3) - .02f), Screen.width * .375f, Screen.height * .190f), "", buttonQuitStyle)) 
		{	
			audio.PlayOneShot(buttonSound, 0.7f);
			StartCoroutine(WaitFor(0));
		}
	}

	private void CheckScores(int score, string playerName)
	{
		if(!GlobalVariables.scoresChecked)
		{
			int first = 0;
			int second = 0;
			int third = 0;
			string player1 = "";
			string player2 = "";

			first = PlayerPrefs.GetInt ("FirstPlace");
			second = PlayerPrefs.GetInt ("SecondPlace");
			third = PlayerPrefs.GetInt ("ThirdPlace");

			player1 = PlayerPrefs.GetString("Player1");
			player2 = PlayerPrefs.GetString("Player2");

			if (score > first) 
			{
				PlayerPrefs.SetInt("ThirdPlace", second);
				PlayerPrefs.SetString("Player3", player2);
				PlayerPrefs.SetInt("SecondPlace", first);
				PlayerPrefs.SetString("Player2", player1);
				PlayerPrefs.SetInt ("FirstPlace", score);
				PlayerPrefs.SetString("Player1", playerName + " - " + score);
			}
			else if(score > second)
			{
				PlayerPrefs.SetInt("ThirdPlace", second);
				PlayerPrefs.SetString("Player3", player2);
				PlayerPrefs.SetInt ("SecondPlace", score);
				PlayerPrefs.SetString("Player2", playerName + " - " + score);
			}
			else if(score > third)
			{
				PlayerPrefs.SetInt ("ThirdPlace", score);
				PlayerPrefs.SetString("Player3", playerName + " - " + score);
			}
			GlobalVariables.scoresChecked = true;
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
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel (level);
	}
}