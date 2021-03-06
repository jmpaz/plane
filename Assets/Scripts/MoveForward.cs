using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveForward : MonoBehaviour {
	public float actualSpeed = 580f;
	public int heading = 0;
	public float speedScale = 5.8f;
	public float altitude = 35000f;
	public float temperature = -30;
	public Text speedText;
	public Text headingText;
	public Text altitudeText;
	public Text temperatureText;
	private float lastUpdateTime;
	public float textRefreshRate;

	// Use this for initialization
	void Start () {
		lastUpdateTime = Time.time;
		UpdateStats ();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (Vector3.forward * -(actualSpeed / speedScale) * Time.deltaTime);
        GameObject.Find("plane").transform.Translate(Vector3.right * -(actualSpeed / speedScale) * Time.deltaTime / 120000f);
		UpdateStats ();
	}

	// Update fields. Add more as needed
	void UpdateStats () {
		if (Time.time - lastUpdateTime > textRefreshRate) {
			actualSpeed += (Random.Range(-10, 10));
			altitude += (Random.Range(-10, 10));
			temperature += (Random.Range(-2, 2));
			lastUpdateTime = Time.time;
			
			speedText.text = "Speed: " + actualSpeed.ToString () + "mph";
			headingText.text = "Heading: " + heading.ToString () + "°";
			altitudeText.text = "Altitude: " + altitude.ToString () + "ft";
			temperatureText.text = "Temperature: " + temperature.ToString () + "°F";
		} 
	}
}
