using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingController : MonoBehaviour {
	[SerializeField] private Text counterText;
	[RangeAttribute(0, 1)] [SerializeField] private float delayToStart;

	[SerializeField] private string nextSceneName;
	[SerializeField] private float counter;

	private void Update() {
		counter -= Time.deltaTime;
		
		if (counter < 1) {
			StartCoroutine(StartGame(delayToStart));
			counterText.text = "SMASH!";
		} else {
			counterText.text = counter.ToString("F0");
		}
	}
	
	private IEnumerator StartGame(float seconds) {
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(nextSceneName);
	}
}
