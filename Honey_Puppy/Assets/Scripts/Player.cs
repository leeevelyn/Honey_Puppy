using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;
/// <summary>
/// This script manages the player.
/// </summary>
public class Player : MonoBehaviour {

	// Flag to determine if the player is holding a ball

	// Reference to screen fader
	[SerializeField] private GameObject screenFader;

	/// <summary>
	/// If the player is hit with a dodgeball, kill him and restart the scene.
	/// </summary>
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.name == "Dodgeball(Clone)") {
<<<<<<< HEAD
			/*SceneFade other_script = (SceneFade) screenFader.GetComponent(typeof(SceneFade));
			other_script.EndScene();*/
			Application.LoadLevel("endscreen");
=======
			SceneFade other_script = (SceneFade)screenFader.GetComponent(typeof(SceneFade));
			this.Destroy(orient.myo);
			other_script.EndScene();
>>>>>>> 666cf7d274564c4f9996b4e7d3bb30bea9eb8bb6
		}
	}
	public int speed;

	/// <summary>
	/// Each frame, updates player position based on input.
	/// </summary>
	private void Update() {
		if(Input.GetAxisRaw("Horizontal") == -1)
			this.transform.Translate(-Time.deltaTime * speed, 0f, 0f);
		else if(Input.GetAxisRaw("Horizontal") == 1)
			this.transform.Translate(Time.deltaTime * speed, 0f, 0f);
	}
}
