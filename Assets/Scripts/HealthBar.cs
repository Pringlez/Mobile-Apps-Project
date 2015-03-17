using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	private bool healthChecked = false;

	public static void DecreaseHealth(float amount)
	{
		GlobalVariables.health = GlobalVariables.health - amount;
	}

	public static void IncreaseHealth(float amount)
	{
		GlobalVariables.health = GlobalVariables.health + amount;
	}

	void Update()
	{
		if(!healthChecked)
		{
			StartCoroutine(WaitFor());
			healthChecked = true;
		}
	}
	
	IEnumerator WaitFor() 
	{
		yield return new WaitForSeconds(0.1f);
		healthChecked = false;
		Image healthBar = GetComponent<Image>();
		healthBar.fillAmount = GlobalVariables.health;
	}
}