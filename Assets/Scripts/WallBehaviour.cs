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

	public float maxDistanceDown;	
	public float maxDistanceUp;
	public float maxDistanceLeft;
	public float maxDistanceRight;	
	public float maxDistanceBack;
	public float maxDistanceForward;

	// Use this for initialization
	void Start () {
		TriggerStart ();
	}

	public void TriggerStart(){

		wallDirection = 0;

		initialPositionX = gameObject.transform.position.x;
		print (initialPositionX);
		initialPositionY = gameObject.transform.position.y;
		print (initialPositionY);
		initialPositionZ = gameObject.transform.position.z;
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
	}
	
	// Update is called once per frame
	void Update () {
		TriggerUpdate ();
	}

	public void TriggerUpdate(){
		print ("TriggerUpdate");
		print ("WallDirection = " + wallDirection);
		if (wallDirection == 1 && gameObject.transform.position.y > maxDistanceDown) {
			Down ();
		} else if (wallDirection == 2 && gameObject.transform.position.y < maxDistanceUp) {
			Up ();
		} else if (wallDirection == 3 && gameObject.transform.position.x > maxDistanceLeft) {
			Left ();
		} else if (wallDirection == 4 && gameObject.transform.position.x < maxDistanceRight) {
			Right ();
		} else if (wallDirection == 5 && gameObject.transform.position.z > maxDistanceBack) {
			Back ();
			print ("WallDirection = 5");
		} else if (wallDirection == 6 && gameObject.transform.position.z < maxDistanceForward) {
			Forward ();
		} 

		if (wallDirection == -1 && gameObject.transform.position.y < maxDistanceUp) {
			ReturnToDown ();
		} else if (wallDirection == -2 && gameObject.transform.position.y > maxDistanceDown) {
			ReturnToUp ();
		} else if (wallDirection == -3 && gameObject.transform.position.x < maxDistanceRight) {
			ReturnToLeft ();
		} else if (wallDirection == -4 && gameObject.transform.position.x > maxDistanceLeft) {
			ReturnToRight ();
		} else if (wallDirection == -5 && gameObject.transform.position.z < maxDistanceForward) {
			ReturnToBack ();
		} else if (wallDirection == -6 && gameObject.transform.position.z > maxDistanceBack) {
			ReturnToForward ();
		}

	}

	public void SetWallDirection (int direction) {
		wallDirection = direction;
	}

	public void Up () {
		gameObject.transform.Translate (Vector3.up * speed);
	}

	public void Down () {
		gameObject.transform.Translate (Vector3.down * speed);
	}

	public void Left () {
		gameObject.transform.Translate (Vector3.left * speed);
	}

	public void Right () {
		gameObject.transform.Translate (Vector3.right * speed);
	}

	public void Back () {
		gameObject.transform.Translate (Vector3.back * speed, Space.World);
		print ("X = " + transform.position.x);
		print ("Y = " + transform.position.y);
		print ("Z = " + transform.position.z);
	}

	public void Forward () {
		gameObject.transform.Translate (Vector3.forward * speed, Space.World);
	}

	public void ReturnToUp () {
		gameObject.transform.Translate (Vector3.down * speed);
	}

	public void ReturnToDown () {
		gameObject.transform.Translate (Vector3.up * speed);
	}

	public void ReturnToLeft () {
		gameObject.transform.Translate (Vector3.right * speed);
	}

	public void ReturnToRight () {
		gameObject.transform.Translate (Vector3.left * speed);
	}

	public void ReturnToBack () {
		gameObject.transform.Translate (Vector3.forward * speed);
	}

	public void ReturnToForward () {
		gameObject.transform.Translate (Vector3.back * speed);
	}

}
