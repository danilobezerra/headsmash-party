using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
	[SerializeField] private string sceneName = "MainMenu";
	[SerializeField] private int waitSeconds = 17;
	
	private Animator animator;
	
	private void Awake() {
		animator = this.GetComponent<Animator>();
	}
	
	IEnumerator Start() {
		animator.SetBool("ShowCredits", true);
		yield return new WaitForSeconds(waitSeconds);
		animator.SetBool("ShowCredits", false);
	}
	
	public void LoadLevel() {
		Debug.Log("Load next scene...");
		SceneManager.LoadScene(sceneName);
	}
}
