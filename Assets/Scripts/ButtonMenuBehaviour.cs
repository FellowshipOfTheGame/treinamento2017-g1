using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMenuBehaviour : MonoBehaviour{

	public Sprite img1;
	public Sprite img2;

	private Image image;

	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
		image.sprite = img1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(BaseEventData eventData){
		image.sprite = img2;
	}

	public void OnPointerExit(BaseEventData eventData){
		image.sprite = img1;
	}
}
