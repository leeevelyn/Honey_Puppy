using UnityEngine;
using System.Collections;

/// <summary>
/// This script manages the player.
/// </summary>
public class Player : MonoBehaviour {

	// Flag to determine if the player is holding a ball
	private bool _holding_ball;

	// Reference to screen fader
	[SerializeField] private GameObject screenFader;

	/// <summary>
	/// If the player is hit with a dodgeball, kill him and restart the scene.
	/// </summary>
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.name == "Dodgeball(Clone)") {
			SceneFade other_script = (SceneFade) screenFader.GetComponent(typeof(SceneFade));
			if(GameState.score > GameState.highScore)
				PlayerPrefs.SetInt("highScore", GameState.score);
			other_script.EndScene();
		}
	}
}
