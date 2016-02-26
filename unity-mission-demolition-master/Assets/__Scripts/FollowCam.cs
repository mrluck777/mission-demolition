using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	static public FollowCam S; 


	public float easing = 0.05f;
	public Vector2 minXY;
	public bool _______;

	public GameObject poi; // The point of interest
	public float camZ; // The desired Z pos of the camera
	
	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	

	void Start () {
	
	}
	

	void FixedUpdate () {
		Vector3 destination;
		if (poi == null) {
			destination = Vector3.zero;
		} else {

			destination = poi.transform.position;

			if (poi.tag == "Projectile") {

				if (poi.rigidbody.IsSleeping()) {

					poi = null;
					Destroy(poi);
					MissionDemolition.SwitchView("Both");

					return;
				}
			}
		}

		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max(minXY.y, destination.y);

		destination = Vector3.Lerp(transform.position, destination, easing);

		destination.z = camZ;

		this.transform.position = destination;

		this.camera.orthographicSize = destination.y + 10;
	}
}
