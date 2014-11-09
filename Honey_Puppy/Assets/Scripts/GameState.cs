using UnityEngine;
using System.Collections;

/// <summary>
/// This script manages the general game state.
/// </summary>
public class GameState : MonoBehaviour {

	public static int highScore;	// High score
	public static int score;		// Current score

	// Cylinder count on field
	public static int cylindersOnField;

	// Representation of cylinder
	[SerializeField] private GameObject cylinder;

	/// <summary>
	/// On object activation, initializes all values.
	/// </summary>
	private void Start() {
		GameState.highScore = PlayerPrefs.GetInt("highScore", 0);
		GameState.score = 0;
		GameState.cylindersOnField = 3;
	}
	
	// Update is called once per frame
	private void Update() {
		if(GameState.cylindersOnField < 5 + (int)GameState.score / 5) {
			GameObject new_cylinder = this.Instantiate(this.cylinder) as GameObject;

			float new_xpos = Random.Range(-7f, 10f);
			new_cylinder.transform.position = new Vector3(new_xpos, 10f, Random.Range(-3f, 4f));
			EvilCylinder other_script = (EvilCylinder)new_cylinder.GetComponent(typeof(EvilCylinder));
			other_script.xpos = new_xpos;
			GameState.cylindersOnField++;
		}
	}
}
