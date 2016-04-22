using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
	[SerializeField] private Image whiteScreen;
	
	private void Update() {
		if (whiteScreen.color.a > 0) {
			Color color = whiteScreen.color;
			color.a -= .01f;
			whiteScreen.color = color;
		}
	}
}
