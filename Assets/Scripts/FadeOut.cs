using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
	[SerializeField] private Image whiteScreen;
	
	[SerializeField] private bool _show = true;
	
	public bool show {
		get { return _show; }
		set { _show = value; }
	}
	
	private void Update() {
		if (_show) {
			DecreaseAlpha();
		} else {
			IncreaseAlpha();
		}
	}
	
	private void DecreaseAlpha() {
		if (whiteScreen.color.a > 0) {
			Color color = whiteScreen.color;
			color.a -= .01f;
			whiteScreen.color = color;
		}
	}
	
	private void IncreaseAlpha() {
		if (whiteScreen.color.a < 1) {
			Color color = whiteScreen.color;
			color.a += .01f;
			whiteScreen.color = color;
		}
	}
}
