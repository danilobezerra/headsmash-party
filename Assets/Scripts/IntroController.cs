using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
	[SerializeField] private string nextSceneName;
	[SerializeField] private string creditsParameterName;
	[SerializeField] private float waitSeconds;
	
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
		if (animator.GetBool(creditsParameterName)) {
			if (Input.anyKeyDown) {
				StopCoroutine(nowLoading);
				animator.SetBool(creditsParameterName, false);
			}
		}
	}
	
	private IEnumerator ShowCredits() {
		yield return new WaitForSeconds(waitSeconds);
		animator.SetBool(creditsParameterName, false);
	}
	
	public void LoadLevel() {
		Debug.Log("Load next scene...");
		SceneManager.LoadScene(nextSceneName);
	}
}
