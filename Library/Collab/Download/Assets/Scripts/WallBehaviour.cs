/* Primeiro jogo FoG - Scape Room
   Junho de 2017
   Autores: Klinsmann Hengles, Gabriel Carvalho e Felipe Torres
   Classe responsavel por fazer as paredes subirem quando o jogador entra em colisao com um objeto
   OBSERVACAO: Usado no puzzle do chao para subir as paredes*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour {

	public int wallDirection;
	public float speed;

	private float initialPositionX;
	private float initialPositionY;
	private float initialPositionZ;

	public float distanceDown;
	public float distanceUp;
	public float distanceLeft;
	public float distanceRight;
	public float distanceBack;
	public float distanceForward;

	private float maxDistanceDown;	
	private float maxDistanceUp;
	private float maxDistanceLeft;
	private float maxDistanceRight;	
	private float maxDistanceBack;
	private float maxDistanceForward;

	// Use this for initialization
	void Start () {

		wallDirection = 0;

		initialPositionX = transform.position.x;
		print (initialPositionX);
		initialPositionY = transform.position.y;
		print (initialPositionY);
		initialPositionZ = transform.position.z;
		print (initialPositionZ);

		maxDistanceDown = initialPositionY + distanceDown;
		//print (initialPositionY);
		//print (distanceDown);
		//print (maxDistanceDown); // teste
		maxDistanceUp = initialPositionY + distanceUp; 
		//print (maxDistanceUp); // teste
		maxDistanceLeft = initialPositionX + distanceLeft; 
		//print (initialPositionX); // teste
		//print (distanceLeft); // teste
		//print (maxDistanceLeft); // teste
		maxDistanceRight = initialPositionX + distanceRight; 
		//print (maxDistanceRight); // teste
		maxDistanceBack = initialPositionZ + distanceBack; 
		//print (maxDistanceBack); // teste
		maxDistanceForward = initialPositionZ + distanceForward; 
		//print (maxDistanceForward); // teste
	}
	
	// Update is called once per frame
	void Update () {

		if (wallDirection == 1 && transform.position.y > maxDistanceDown) {
			Down ();
		} else if (wallDirection == 2 && transform.position.y < maxDistanceUp) {
			Up ();
		} else if (wallDirection == 3 && transform.position.x > maxDistanceLeft) {
			Left ();
		} else if (wallDirection == 4 && transform.position.x < maxDistanceRight) {
			Right ();
		} else if (wallDirection == 5 && transform.position.z > maxDistanceBack) {
			Back ();
		} else if (wallDirection == 6 && transform.position.z < maxDistanceForward) {
			Forward ();
		} 

		if (wallDirection == -1 && transform.position.y < maxDistanceUp) {
			ReturnToDown ();
		} else if (wallDirection == -2 && transform.position.y > maxDistanceDown) {
			ReturnToUp ();
		} else if (wallDirection == -3 && transform.position.x < maxDistanceRight) {
			ReturnToLeft ();
		} else if (wallDirection == -4 && transform.position.x > maxDistanceLeft) {
			ReturnToRight ();
		} else if (wallDirection == -5 && transform.position.z < maxDistanceForward) {
			ReturnToBack ();
		} else if (wallDirection == -6 && transform.position.z > maxDistanceBack) {
			ReturnToForward ();
		}

	}

	public void SetWallDirection (int direction) {
		wallDirection = direction;
	}

	void Up () {
		transform.Translate (Vector3.up * speed);
	}

	void Down () {
		transform.Translate (Vector3.down * speed);
	}

	void Left () {
		transform.Translate (Vector3.left * speed);
	}

	void Right () {
		transform.Translate (Vector3.right * speed);
	}

	void Back () {
		transform.Translate (Vector3.back * speed);
	}

	void Forward () {
		transform.Translate (Vector3.forward * speed);
	}

	void ReturnToUp () {
		transform.Translate (Vector3.down * speed);
	}

	void ReturnToDown () {
		transform.Translate (Vector3.up * speed);
	}

	void ReturnToLeft () {
		transform.Translate (Vector3.right * speed);
	}

	void ReturnToRight () {
		transform.Translate (Vector3.left * speed);
	}

	void ReturnToBack () {
		transform.Translate (Vector3.forward * speed);
	}

	void ReturnToForward () {
		transform.Translate (Vector3.back * speed);
	}

}
