using UnityEngine;

public class WinnerChooser : MonoBehaviour {
	[SerializeField] private GameObject p1Background;
	[SerializeField] private GameObject p2Background;
	
	public void SetWinnerP1() {
		p1Background.SetActive(true);
		p2Background.SetActive(false);
	}
	
	public void SetWinnerP2() {
		p1Background.SetActive(false);
		p2Background.SetActive(true);
	}
}
