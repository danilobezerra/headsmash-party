using UnityEngine;
using System.Collections;

public class IconSpawn : MonoBehaviour {
	[System.Serializable] public class IconPosition {
		public Transform start;
		public Transform final;
	}
	
	[SerializeField] private IconPosition icon1Position;
	[SerializeField] private IconPosition icon2Position;
	
	private IList instantiatedIcons;
	
	private void Start() {
		instantiatedIcons = new ArrayList();
	}
	
	private GameObject InstantiateIcon(GameObject prefab, Transform start, Transform final) {
		GameObject clone = Instantiate(prefab, start.position, Quaternion.identity) as GameObject;
		clone.transform.parent = start;
		
		var controller = clone.GetComponent<_IconController>();
		controller.target = final;
		
		return clone;
	}
	
	public void NewIcon(GameObject prefab) {
		if (instantiatedIcons.Count == 0) {
			AddNewIcon(prefab, icon1Position);
		} else {
			AddNewIcon(prefab, icon2Position);
		}
	}
	
	private void AddNewIcon(GameObject prefab, IconPosition newPosition) {
		GameObject icon = InstantiateIcon(prefab, newPosition.start, newPosition.final);
		instantiatedIcons.Add(icon);
	}
}
