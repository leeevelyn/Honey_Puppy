using UnityEngine;
using System.Collections;

/// <summary>
/// This script defines the behavior of the evil cylinders.
/// </summary>
public class CylinderManager : MonoBehaviour {

	private float _xpos;
	private float _rand_start;

	public GameObject dodgeball;

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

		this.transform.position = new Vector3(this._xpos + Mathf.Sin(Time.time + this._rand_start), this.transform.position.y, this.transform.position.z);

		// Throw a dodgeball
		if(Random.Range(0f, 10f) > 9.9f) {
			GameObject new_dodgeball = this.Instantiate(this.dodgeball) as GameObject;
			new_dodgeball.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
			new_dodgeball.rigidbody.AddForce(new Vector3(Random.Range(-30f, 30f), Random.Range(200f, 300f), Random.Range(-120f, -80f)));
		}
	}
}
