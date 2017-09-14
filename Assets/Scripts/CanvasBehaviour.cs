/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBehaviour : MonoBehaviour {

	public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}

	public static void Show(int id){
		Canvas can = Canvas.FindObjectOfType<Canvas> (); /*("Canvas");*/
		can.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
