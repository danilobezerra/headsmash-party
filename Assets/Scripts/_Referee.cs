using UnityEngine;
using System.Collections;

public class _Referee : MonoBehaviour {
	public bool p1 = false;
	public bool changed = false;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void FixedUpdate() {
		if (Application.loadedLevelName == "Decision" && !changed) {
			Change();
			changed = true;
		}
	}
	
	public void Player1() {
		p1 = true;
	}
	
	public void Player2() {
		p1 = false;
	}
	
	IEnumerator Change() {
		yield return new WaitForSeconds(4);
		
		if (p1) {
			Application.LoadLevel("Celebration_P1");
		} else {
			Application.LoadLevel("Celebration_P2");
		}
		
		changed = false;
	}
}
