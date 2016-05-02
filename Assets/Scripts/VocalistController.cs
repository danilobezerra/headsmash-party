using UnityEngine;

public class VocalistController : MonoBehaviour {
	[SerializeField] private GameObject vocalist;
	
	[SerializeField] private Transform startPosition;
	[SerializeField] private Transform finalPosition;
	
	[SerializeField] private float speed;
	private bool _showing;
	
	public bool showing {
		get { return _showing; }
		set { _showing = value; }
	}
	
	private void Update() {
		MovePosition(_showing ? finalPosition : startPosition);
	}
	
	private void MovePosition(Transform target) {
		float step = speed * Time.deltaTime;
		vocalist.transform.position = Vector3.MoveTowards(vocalist.transform.position, target.position, step);
	}
}
