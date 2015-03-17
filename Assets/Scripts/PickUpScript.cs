using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour 
{
	HUDScript hud;
	private bool powerUpUsed = false;
	public Transform coinEffect;
	public Transform heartEffect;
	public Transform explosionEffect;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !powerUpUsed && gameObject.transform.name.ToString() == "Coin(Clone)") 
		{
			powerUpUsed = true;
			audio.Play();
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			Instantiate(coinEffect, transform.position, transform.rotation);
			hud.IncreaseScore(10);
			this.renderer.enabled = false;
			StartCoroutine(WaitFor());
		}
		else if (other.tag == "Player" && !powerUpUsed && gameObject.transform.name.ToString() == "Heart(Clone)")
		{
			powerUpUsed = true;
			audio.Play();
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			Instantiate(heartEffect, transform.position, transform.rotation);

			if(GlobalVariables.health < 1f)
			{
				HealthBar.IncreaseHealth(0.2f);

				if(GlobalVariables.health > 1f)
				{
					GlobalVariables.health = 1f;
				}
			}
			if(GlobalVariables.stamina < 1f)
			{
				StaminaBar.IncreaseStamina(0.3f);

				if(GlobalVariables.stamina > 1f)
				{
					GlobalVariables.stamina = 1f;
				}
			}

			this.renderer.enabled = false;
			StartCoroutine(WaitFor());
		}
		else if (other.tag == "Player" && !powerUpUsed && gameObject.transform.name.ToString() == "Bomb(Clone)")
		{
			powerUpUsed = true;
			audio.Play();
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			Instantiate(explosionEffect, transform.position, transform.rotation);
			HealthBar.DecreaseHealth(0.3f);
			StaminaBar.DecreaseStamina(0.1f);

			if(GlobalVariables.health < 0f)
			{
				StartCoroutine(Died(0.25f));
			}

			this.renderer.enabled = false;
			StartCoroutine(WaitFor());
		}
	}

	IEnumerator WaitFor() 
	{
		yield return new WaitForSeconds(0.3f);
		powerUpUsed = false;
		Destroy (this.gameObject);
	}

	IEnumerator Died(float amount) 
	{
		yield return new WaitForSeconds(amount);
		Application.LoadLevel(3);
	}
}