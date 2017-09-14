using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInside : ObjectParent {

	public GameObject Drawer;
	private bool isVisible = false;

	// Update is called once per frame
	void Update () {

		if (!isVisible)
			isVisible = Drawer.GetComponent<DrawerBehaviour> ().getState ();	// Verifica se a gaveta está aberta, tornando-o visível.
		else {	// Se o objeto está visível
			if (ObjInside) {	// Se o player está no raio de colisão
				image.enabled = true;
				text.enabled = true;
				if (Input.GetKeyDown ("e")) {	// Se pressiona e
					PlayerController.SaveObject(id); // O objeto e' salvo no inventario
					image.enabled = false;
					text.enabled = false;
					Destroy(gameObject); // Destroi o objeto
				}
			}
		}
	}

	// Quando entrar no trigger do objeto
	void OnTriggerEnter(Collider col){
		ObjInside = true; // O objeto esta dentro
		if (isVisible && ObjInside) {	// Se a gaveta estiver aberta
			image.enabled = true;
			text.enabled = true;
		}
	}
}
