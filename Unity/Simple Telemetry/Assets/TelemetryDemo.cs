using UnityEngine;
using System.Collections;

public class TelemetryDemo : MonoBehaviour {

	float time;
	float interval = 1f;

	// Use this for initialization
	void Start () {
		Application.runInBackground = true;

		Debug.Log("Starting up...");
		Telemetry.debug("Starting up telemetry loggin");
	}
	
	// Update is called once per frame
	void Update () {
		// sampled data
		var x = Time.time;
		Telemetry.data("sin x", Mathf.Sin(x));
		Telemetry.data("sin 2x", Mathf.Sin(2 * x));
		Telemetry.data("square wave", Mathf.Sin(x) + (1/3f) * Mathf.Sin(3 * x) + (1/5f) * Mathf.Sin(5 * x) + (1/7f) * Mathf.Sin(7 * x));
	
		// remote logging
		if (time < 0) {
			Telemetry.info ("hello telemetry");
			time += interval;
		}
		time -= Time.deltaTime;

		// scalar data
		Telemetry.scalar ("my first scalar", Mathf.Floor (Mathf.Sin (Time.time) * 10));
	}
}
