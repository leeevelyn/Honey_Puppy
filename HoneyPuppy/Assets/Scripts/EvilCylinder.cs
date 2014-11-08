using UnityEngine;
using System.Collections;

/// <summary>
/// This script manages the evil cylinders.
/// </summary>
public class EvilCylinder : MonoBehaviour {

	private float _xpos;		// Initial x-position
	private float _rand_start;	// Random offset at start

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
	/// Each frame, moves the evil cylinder and possibly throws a dodgeball.
	/// </summary>
	private void Update() {
		this.rigidbody.freezeRotation = !this._killed;

		this.transform.position = new Vector3(this._xpos + Mathf.Sin(Time.time + this._rand_start), this.transform.position.y, this.transform.position.z);

		// Throw a dodgeball
		if(!this._killed && Random.Range(0f, 10f) > 9.95f) {
			GameObject new_dodgeball = this.Instantiate(this.dodgeball) as GameObject;
			new_dodgeball.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
			new_dodgeball.rigidbody.AddForce(new Vector3(Random.Range(-30f, 30f), Random.Range(300f, 400f), Random.Range(-180f, -150f)));
		}
	}

	/// <summary>
	/// If the evil cylinder is hit with a dodgeball, kill it and send it flying.
	/// </summary>
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.name == "Dodgeball(Clone)")
			this._killed = true;
	}
}
