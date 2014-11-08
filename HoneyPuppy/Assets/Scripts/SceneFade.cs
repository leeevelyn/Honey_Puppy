using UnityEngine;
using System.Collections;

/// <summary>
/// This script fades and unfades the scene.
/// </summary>
public class SceneFade : MonoBehaviour {

	// Flags to check if scene is starting or ending
	private bool _scene_starting = true;
	private bool _scene_ending = false;

	// Speed of scene fade
	public float fadeSpeed = 1.5f;

	/// <summary>
	/// At instantiation, initializes GUI texture.
	/// </summary>
	private void Awake() {
		Time.timeScale = 1f;
		this.guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	/// <summary>
	/// Each frame, run any active scene transitions.
	/// </summary>
	private void Update() {
		if(this._scene_starting)
			this.StartScene();
		if(this._scene_ending) {
			this.EndScene();
			if(Time.timeScale > 0.5f)
				Time.timeScale *= 0.9f;
		}
	}

	/// <summary>
	/// Fades the scene to clear.
	/// </summary>
	private void FadeToClear() {this.guiTexture.color = Color.Lerp(this.guiTexture.color, Color.clear, this.fadeSpeed * Time.deltaTime);}

	/// <summary>
	/// Fades the scene to black.
	/// </summary>
	private void FadeToBlack() {this.guiTexture.color = Color.Lerp(this.guiTexture.color, Color.black, this.fadeSpeed * Time.deltaTime);}

	/// <summary>
	/// Starts the scene.
	/// </summary>
	private void StartScene() {
		this.FadeToClear();
		if(this.guiTexture.color.a <= 0.05f) {
			this.guiTexture.color = Color.clear;
			this.guiTexture.enabled = false;
			this._scene_starting = false;
		}
	}

	/// <summary>
	/// Ends the scene.
	/// </summary>
	public void EndScene() {
		this.guiTexture.enabled = true;
		this._scene_ending = true;
		this.FadeToBlack();
		if(this.guiTexture.color.a >= 0.95f)
			Application.LoadLevel(0);
	}
}
