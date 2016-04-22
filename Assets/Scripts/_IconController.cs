using UnityEngine;

public class _IconController : MonoBehaviour {
	[SerializeField] private float speed;
	private Transform _target;
	
	public Transform target {
		get { return _target; }
		set {
			_target = value;
		}
	}
    
	private void Update() { 
		if (target) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
		}
    }
}
