using UnityEngine;
using System.Collections;

/// <summary>
/// This script manages the dodgeballs.
/// </summary>
public class Dodgeball : MonoBehaviour {

	private float counter = 1000f;

	/// <summary>
	/// Each scene, destroy the dodgeball if it goes out of bounds or if
	/// its counter hits zero.
	/// </summary>
	private void Update() {
		this.counter -= Time.deltaTime;
		if(counter <= 0 || Mathf.Abs(this.transform.position.x) > 100 ||
		   Mathf.Abs(this.transform.position.y) > 100 || Mathf.Abs(this.transform.position.z) > 100)
			this.Destroy(this.gameObject);
	}
}
