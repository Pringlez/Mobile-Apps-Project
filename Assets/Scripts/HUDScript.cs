using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour 
{
	private float playerScore = 0;
	private bool updatingStamina = false;
	public GUIStyle labelScore;
	public GUIStyle customTextStyle;
	
	void Update () 
	{
		playerScore += Time.deltaTime;

		if(!updatingStamina)
		{
			updatingStamina = true;
			StartCoroutine(WaitFor());
		}
	}

	public void IncreaseScore(int amount) 
	{
		playerScore += amount;
	}

	void OnDisable() 
	{
		PlayerPrefs.SetInt("Score", (int)(playerScore * 100));
	}
	
	void OnGUI() 
	{
		GUI.Label(new Rect (Screen.width * .02f, Screen.height * .03f, Screen.height * .18f, Screen.height * .06f), "", labelScore);
		GUI.Label(new Rect (Screen.width * .15f, Screen.height * .03f, Screen.height * .18f, Screen.height * .06f), "" + (int)(playerScore * 100), customTextStyle);
		GUI.Label(new Rect (Screen.width * .65f, Screen.height * .03f, Screen.height * .18f, Screen.height * .06f), PlayerPrefs.GetString("PlayerName"), customTextStyle);
		#if UNITY_WP_8_1
		GUI.Label(new Rect (Screen.width * .015f, Screen.height * .87f, Screen.height * .18f, Screen.height * .06f), "Health", customTextStyle);
		GUI.Label(new Rect (Screen.width * .68f, Screen.height * .87f, Screen.height * .18f, Screen.height * .06f), "Stamina", customTextStyle);
		#else
		GUI.Label(new Rect (Screen.width * .05f, Screen.height * .87f, Screen.height * .18f, Screen.height * .06f), "Health", customTextStyle);
		GUI.Label(new Rect (Screen.width * .67f, Screen.height * .87f, Screen.height * .18f, Screen.height * .06f), "Stamina", customTextStyle);
		#endif
	}

	IEnumerator WaitFor() 
	{
		yield return new WaitForSeconds(1f);
		updatingStamina = false;
		StaminaBar.IncreaseStamina (0.025f);
	}
}