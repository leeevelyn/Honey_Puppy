using UnityEngine;
using System.Collections;

/// <summary>
/// This script manages the evil cylinders.
/// </summary>
public class EvilCylinder : MonoBehaviour {

	private float _xpos;					// Initial x-position
	private float _rand_start;				// Random offset at start
	public float _death_counter = 5f;		// Time to cylinder death
	
	// Flag to determine if cylinder is dead
	private bool _killed = false;

	// Reference to dodgeball
	[SerializeField] private GameObject dodgeball;

	/// <summary>
	/// At instantiation, initializes position variable.
	/// </summary>
	private void Awake() {
		this._xpos = this.transform.position.x;
		this._rand_start = Random.Range(0f, 8f);
	}

	/// <summary>
	/// Each frame, moves the cylinder and possibly throws a dodgeball.
	/// </summary>
	private void Update() {

		// The cylinder should only be able to fall over if it's dead
		this.rigidbody.freezeRotation = !this._killed;

		// If the cylinder is alive, make it move back and forth
		if(!this._killed)
			this.transform.position = new Vector3(this._xpos + Mathf.Sin(Time.time + this._rand_start), this.transform.position.y, this.transform.position.z);

		// Otherwise if it's newly dead, count down
		else if(this._death_counter > 0f)
			this._death_counter -= Time.deltaTime;

		// Otherwise, shrink it to nothing and decrement the cylinders on the field
		else {
			this.transform.localScale = new Vector3(this.transform.localScale.x * 0.9f, this.transform.localScale.y * 0.9f, this.transform.localScale.z * 0.9f);
			if(this.transform.localScale.x < 0.1f) {
				GameState.cylindersOnField--;
				this.Destroy(this.gameObject);
			}
		}

		// Make the cylinder throw a dodgeball
		if(!this._killed && Random.Range(0f, 10f) > 9.95f) {
			GameObject new_dodgeball = this.Instantiate(this.dodgeball) as GameObject;
			new_dodgeball.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
			new_dodgeball.rigidbody.AddForce(new Vector3(Random.Range(-30f, 30f), Random.Range(300f, 400f), Random.Range(-180f, -150f)));
		}
	}

	/// <summary>
	/// If the cylinder is hit with a dodgeball, kill it and send it flying.
	/// </summary>
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.name == "Dodgeball(Clone)") {
			this._killed = true;
			GameState.score++;
		}
	}
}
