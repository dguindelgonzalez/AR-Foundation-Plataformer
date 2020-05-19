using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleanerController : MonoBehaviour
{
	#region Public Methods

	public void RestartGame()
	{
		SceneManager.LoadScene("Main");
	}

	public void StopGame()
	{
		print("Quitting!");
		Application.Quit();
	}

	#endregion

	#region Private Methods

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerHealth>().MakeDead();
		}
	}

	#endregion
}
