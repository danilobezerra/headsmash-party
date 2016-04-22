using UnityEngine;
using System.Collections;

public class IconSpawn : MonoBehaviour {
	[SerializeField] private Transform icon1Spawn;
	[SerializeField] private Transform icon2Spawn;
	[SerializeField] private Transform icon1;
	[SerializeField] private Transform icon2;

	private bool first = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void NewIcon(GameObject prefab, Transform iconSpawn) {
		GameObject clone = Instantiate(prefab, iconSpawn.position, Quaternion.identity) as GameObject;
		clone.transform.parent = iconSpawn;
	}
	
	public void NewIcon(GameObject prefab) {
		NewIcon(prefab, first ? icon1Spawn : icon2Spawn);
		first = false;
	}
}
