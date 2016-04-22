using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip sfx;
	[SerializeField] private Animator textAnimator;
	[SerializeField] private string textParameterName;
	[SerializeField] private string nextSceneName;

	private void Update() {
		if (Input.GetKey(KeyCode.Return) && !textAnimator.GetBool(textParameterName)) {
			textAnimator.SetBool(textParameterName, true);
			audioSource.PlayOneShot(sfx);
			StartCoroutine(StartGame());
		}
	}
	
	private IEnumerator StartGame() {
		yield return new WaitForSeconds(sfx.length);
		SceneManager.LoadScene(nextSceneName);
	}
}
