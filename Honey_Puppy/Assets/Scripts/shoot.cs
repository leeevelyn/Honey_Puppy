using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
//using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class shoot : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;


    // The pose from the last update. This is used to determine if the pose has changed
    // so that actions are only performed upon making them rather than every frame during
    // which they are active.
    private Pose _lastPose = Pose.Unknown;

	public Rigidbody playerball;
	public float speed = 10f;
	void FireBall () {
		Rigidbody rocketClone = (Rigidbody)Instantiate (playerball, transform.position, transform.rotation);
		rocketClone.velocity = transform.forward * speed;
	}

    // Update is called once per frame.
    void Update ()
    {
        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose) {
			if(_lastPose != Pose.FingersSpread && thalmicMyo.pose == Pose.FingersSpread){
				FireBall();
			}
            _lastPose = thalmicMyo.pose;

            // Vibrate the Myo armband when a fist is made.
            //if (thalmicMyo.pose == Pose.Fist) {
                //thalmicMyo.Vibrate (VibrationType.Medium);
        }
    }
}
