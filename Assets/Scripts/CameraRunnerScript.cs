using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour 
{
	public Transform player;

	void OnEnable()
	{
		try
		{
			DestroyObject(GameObject.Find("Background Music"));
		}
		catch{};
	}

	void Update () 
	{
		transform.position = new Vector3 (player.position.x + 3, 0, -10);
	}
}