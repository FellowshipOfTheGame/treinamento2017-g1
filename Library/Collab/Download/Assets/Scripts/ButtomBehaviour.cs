using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomBehaviour : MonoBehaviour {

	public List<GameObject> wallsDown;
	public List<GameObject> wallsUp;
	public List<GameObject> wallsLeft;
	public List<GameObject> wallsRight;
	public List<GameObject> wallsBack;
	public List<GameObject> wallsForward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Se o jogador esta dentro do trigger do objeto
	void OnTriggerEnter(Collider col){
		//ObjInside = true; // O jogador esta dentro do campo de colisao do objeto interativo do puzzle 1
		foreach (GameObject wall in wallsDown) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (1);
		}

		foreach (GameObject wall in wallsUp) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (2);
		}

		foreach (GameObject wall in wallsLeft) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (3);
		}

		foreach (GameObject wall in wallsRight) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (4);
		}

		foreach (GameObject wall in wallsBack) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (5);
		}

		foreach (GameObject wall in wallsForward) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (6);
		}

	}

	// Se o jogador sai de dentro do trigger do objeto
	void OnTriggerExit(Collider col){
		//ObjInside = false;	// O jogador esta fora do campo de colisao de objeto interativo do puzzle 1
		foreach (GameObject wall in wallsDown) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-1);
		}

		foreach (GameObject wall in wallsUp) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-2);
		}

		foreach (GameObject wall in wallsLeft) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-3);
		}

		foreach (GameObject wall in wallsRight) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-4);
		}

		foreach (GameObject wall in wallsBack) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-5);
		}

		foreach (GameObject wall in wallsForward) {
			wall.GetComponent<WallBehaviour> ().SetWallDirection (-6);
		}
	}
}
