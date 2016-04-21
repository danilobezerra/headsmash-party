using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
	[SerializeField] private string nextSceneName;
	[SerializeField] private string parameterName;
	[SerializeField] private int waitSeconds;
	
	private Animator animator;
	private IEnumerator nowLoading;
	
	private void Awake() {
		animator = this.GetComponent<Animator>();
	}
	
	private void Start() {
		nowLoading = ShowCredits();
		StartCoroutine(nowLoading);
	}
	
	private void Update() {
		if (animator.GetBool(parameterName)) {
			if (Input.anyKeyDown) {
				StopCoroutine(nowLoading);
				animator.SetBool(parameterName, false);
			}
		}
	}
	
	private IEnumerator ShowCredits() {
		yield return new WaitForSeconds(waitSeconds);
		animator.SetBool(parameterName, false);
	}
	
	public void LoadLevel() {
		Debug.Log("Load next scene...");
		SceneManager.LoadScene(nextSceneName);
	}
}
