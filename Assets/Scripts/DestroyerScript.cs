using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour 
{
	void OnEnable()
	{
		GlobalVariables.scoresChecked = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Application.LoadLevel(3);
			return;
		}

		if (other.gameObject.transform.parent) 
		{
			Destroy (other.gameObject.transform.parent.gameObject);
		} 
		else 
		{
			Destroy (other.gameObject);
		}
	}
}