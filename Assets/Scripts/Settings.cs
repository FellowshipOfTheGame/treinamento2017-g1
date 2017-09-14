using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	private static float sensibility;
	private static float defaultSensibility;
	private static float senseSlider;

	private static float rbgValue = 0.5f;

	private static float volume;
	private static float volumeSlider;

	private static bool defaultConfig = true;

	// Use this for initialization
	void Awake () {
		if (defaultConfig) {
			defaultSensibility = 10.0f;
			sensibility = 5.0f;
			senseSlider = 50f;

			volume = 1.0f;
			volumeSlider = 100f;
			RenderSettings.ambientLight = new Color (rbgValue, rbgValue, rbgValue, 1.0f);
			print ("Sense awake = " + sensibility);
		}
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.ambientLight = new Color (rbgValue, rbgValue, rbgValue, 1.0f);
	}

	public static float GetSensibility(){
		return sensibility;
	}

	public void SetSensibility(float sliderValue){
		sensibility = defaultSensibility * 0.01f * sliderValue;
		senseSlider = sliderValue;
		defaultConfig = false;
		print ("Sense = " + sensibility);
	}

	public static float GetSenseSliderValue(){
		return senseSlider;
	}

	public static float GetVolume(){
		return volume;
	}

	public void SetVolume(float sliderValue){
		volumeSlider = sliderValue;
		volume = sliderValue * 0.01f;
		defaultConfig = false;
	}

	public static float GetVolumeSliderValue(){
		return volumeSlider;
	}
}
