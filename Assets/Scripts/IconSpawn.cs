using UnityEngine;

public class IconSpawn : MonoBehaviour {
	[System.Serializable] public class IconPosition {
		public Transform start;
		public Transform final;
	}
	
	[SerializeField] private IconPosition icon1Position;
	[SerializeField] private IconPosition icon2Position;
	
	private int iconCount = 0;
	
	private GameObject InstantiateIcon(GameObject prefab, Transform start, Transform final) {
		GameObject clone = Instantiate(prefab, start.position, Quaternion.identity) as GameObject;
		clone.transform.SetParent(start);
		
		var controller = clone.GetComponent<IconController>();
		controller.target = final;
		
		return clone;
	}
	
	public void AddNewIcon(GameObject prefab) {
		switch (iconCount) {
			case 0:
				InstantiateIcon(prefab, icon1Position.start, icon1Position.final);
				iconCount++;
				break;
			case 1:
				InstantiateIcon(prefab, icon2Position.start, icon2Position.final);
				iconCount++;
				break;
		}
	}
}
