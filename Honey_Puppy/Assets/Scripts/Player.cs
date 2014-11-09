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
			/*SceneFade other_script = (SceneFade) screenFader.GetComponent(typeof(SceneFade));
			other_script.EndScene();*/
			Application.LoadLevel("endscreen");
		}
	}
	public int speed;

	void Update(){
		if (Input.GetAxisRaw ("Horizontal")==-1){
			transform.Translate (-1*Time.deltaTime*speed, 0, 0);
		} else if (Input.GetAxisRaw ("Horizontal")==1){
			transform.Translate (1*Time.deltaTime*speed,0,0);
		}
	}
}
