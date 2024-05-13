using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {


	public int[] values;
	public float speed;
	float realRotation;


	public Game_Manager gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Game_Manager> ();
	}
	
    
	// Update is called once per frame
	void Update () {
	

		if (transform.root.eulerAngles.z != realRotation) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, realRotation), speed);
		}

	}



	void OnMouseDown()
	{
		
		RotatePiece ();

		gm.puzzle.curValue= gm.Sweep ();

		
	}

	public void RotatePiece()
	{
		realRotation += 90;

		if (realRotation == 360)
			realRotation = 0;

		RotateValues ();
	}



	public void RotateValues()
	{

		int aux = values [0];

		for (int i = 0; i < values.Length-1; i++) {
			values [i] = values [i + 1];
		}
		values [3] = aux;
	}
}