using UnityEngine;
using System.Collections;

public class VocalistController : MonoBehaviour {
	public GameObject vocalist;
	public bool vocalDown;
	public int vDir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (vocalDown) {
			vocalist.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			
			//if (iconMove) {
			//	newIcon1.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			//	newIcon2.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			//}
			
			if (vocalist.transform.position.y <= 600) {
				vDir = 1;
				vocalDown = false;
			}
		}
	}
}
