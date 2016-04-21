using UnityEngine;
using System.Collections;

public class _intro : MonoBehaviour {
	IEnumerator Start() {
		yield return new WaitForSeconds(17);
		Application.LoadLevel("MainMenu");
	}
}
