using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour 
{
	private bool staminaChecked = false;

	public static void DecreaseStamina(float amount)
	{
		if(GlobalVariables.stamina > 0f)
		{
			GlobalVariables.stamina = GlobalVariables.stamina - amount;
		}
	}
	
	public static void IncreaseStamina(float amount)
	{
		if(GlobalVariables.stamina < 1f)
		{
			GlobalVariables.stamina = GlobalVariables.stamina + amount;
		}
	}

	void Update()
	{
		if(!staminaChecked)
		{
			StartCoroutine(WaitFor());
			staminaChecked = true;
		}
	}

	IEnumerator WaitFor() 
	{
		yield return new WaitForSeconds(0.1f);
		staminaChecked = false;
		Image staminaBar = GetComponent<Image>();
		staminaBar.fillAmount = GlobalVariables.stamina;
	}
}