/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe que define o funcionamento das gavetas.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerBehaviour : WallBehaviour{

	private bool isOpen;
	private bool ObjInside; // Determina se o jogador esta dentro do raio de colizao do objeto
	public Image image;
	public Text text;

	// Use this for initialization
	void Start () {
		isOpen = false;
		ObjInside = false;
		image.enabled = false;
		text.enabled = false;
		TriggerStart ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ObjInside && Input.GetKeyDown ("e") && !isOpen) {
		//if (ObjInside && PlayerController.hit && !isOpen) {
			image.enabled = false;
			text.enabled = false;
			isOpen = true;
			wallDirection = 6;
		}

		// Chama o trigger de update
		if (isOpen)
			TriggerUpdate ();
	}

	// Quando entrar no trigger do objeto
	void OnTriggerEnter(Collider col){
		if (!isOpen) {
			ObjInside = true; // O objeto esta dentro
			image.enabled = true;
			text.enabled = true;
		}
	}

	// Quando sai do trigger do objeto
	void OnTriggerExit(Collider col){
		if (!isOpen) {
			ObjInside = false; // O objeto esta fora	
			image.enabled = false;
			text.enabled = false;
		}
	}

	public bool getState(){
		return isOpen;
	}
}
