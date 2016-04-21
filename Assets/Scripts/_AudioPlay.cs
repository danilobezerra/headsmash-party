using UnityEngine;
using System.Collections;

public class _AudioPlay : MonoBehaviour {
	public float seconds = 0;
	public string loadLevelName;

	IEnumerator AudioPlay() {
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(loadLevelName);
	}
}
