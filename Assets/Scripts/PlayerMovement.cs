using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public enum Player { P1, P2 };
	public Player player;
	public float movement;

	private KeyCode upKey;
	private KeyCode downKey;

	private int tier;

	// Use this for initialization
	void Start() {
		tier = 0;

		switch (player) {
		case Player.P1:
			upKey = KeyCode.W;
			downKey = KeyCode.S;
			break;
		case Player.P2:
			upKey = KeyCode.UpArrow;
			downKey = KeyCode.DownArrow;
			break;
		}
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(upKey)) {
			switch(tier) {
			case 0:
				transform.position = new Vector3(transform.position.x, movement, transform.position.z);
				tier = 1;
				break;
			case 1:
				tier = 1;
				break;
			case 2:
				transform.position = new Vector3(transform.position.x, 0, transform.position.z);
				tier = 0;
				break;
			}
		}
		
		if (Input.GetKeyDown(downKey)) {
			switch(tier) {
			case 0:
				transform.position = new Vector3(transform.position.x, -movement, transform.position.z);
				tier = 2;
				break;
			case 1:
				transform.position = new Vector3(transform.position.x, 0, transform.position.z);
				tier = 0;
				break;
			case 2:
				tier = 2;
				break;
			}
		}
	}
}
