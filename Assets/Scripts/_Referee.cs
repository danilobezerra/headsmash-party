using UnityEngine;
using System.Collections;

public class _Referee : MonoBehaviour {
	public bool p1 = false;
	public bool changed = false;
	
	public GameObject p1Background;
	public GameObject p2Background;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void FixedUpdate() {
		if (Application.loadedLevelName == "Decision" && !changed) {
			StartCoroutine(Change());
			changed = true;
		}
		
		if (Application.loadedLevelName == "Celebration" && !changed) {
			GameObject finish = GameObject.FindGameObjectWithTag("Finish");
			var chooser = finish.GetComponent<WinnerChooser>();
			
			if (p1) {
				chooser.SetWinnerP1();
			} else {
				chooser.SetWinnerP2();
			}
			
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
		Application.LoadLevel("Celebration");
		
		changed = false;
	}
}
