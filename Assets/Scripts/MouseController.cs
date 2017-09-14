/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel pela movimentacao da camera do jogador (no caso do computador feita pelo mouse)*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	//mouse
	private Vector2 look, smooth;		// o quanto de movimento fez e suavidade do movimento
	public float sense = 5.0f;			// Valor de sensibilidade do movimento
	private float smoothSpeed = 2.0f;	// Valor de suavidade do movimento

	GameObject player;

	// Use this for initialization
	void Start () {
		player = this.transform.parent.gameObject;		// player é o pai dessa classe. Como ela está presa à câmera, player é a Capsule. 
		sense = Settings.GetSensibility();
		//sense = 5.0f;
	}

	// Movimentação do mouse
	private void mouse(){
		Vector2 preSmooth = new Vector2 (sense * smoothSpeed, sense * smoothSpeed);

		Vector2 move = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		move = Vector2.Scale (move, preSmooth);		// Multiplica os dois vetores
		smooth = new Vector2(Mathf.Lerp(smooth.x, move.x, 1f / smoothSpeed), Mathf.Lerp(smooth.y, move.y, 1f / smoothSpeed));		// Facilita na suavidade. Não move instantaneamente.
		look += smooth;
		look.y = Mathf.Clamp (look.y, -65, 65);		// Impede que dê o mortal

		transform.localRotation = Quaternion.AngleAxis (-look.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis (look.x, player.transform.up);
	}
	
	// Update is called once per frame
	void Update () {
		mouse ();
	}

	public void SetSense(float sense){
		this.sense = sense;
	}
}
