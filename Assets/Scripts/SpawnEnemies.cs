using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
	[System.Serializable] public class SpawnPosition {
		public Transform top;
		public Transform middle;
		public Transform bottom;
	}
	
	[SerializeField] GameObject[] enemies;
	[SerializeField] private GameObject player;
	[SerializeField] private SpawnPosition spawnPosition;
	
	[SerializeField] private float minSpawnPerSecond = .3f;
	[SerializeField] private float maxSpawnPerSecond = .6f;
	
	private PlayerController playerController;
	
	public bool spawning = false;
	private int canSpawn = 1;


	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	private void FixedUpdate() {
		canSpawn -= 1;
		
		if (spawning && canSpawn <= 0) {
			int randomPosition = Random.Range(0, 3);
			Vector2 newPosition = Vector2.zero;
			
			switch (randomPosition) {
				case 0:
					newPosition.y = spawnPosition.top.position.y;
					break;
				case 1:
					newPosition.y = spawnPosition.middle.position.y;
					break;
				case 2:
					newPosition.y = spawnPosition.bottom.position.y;
					break;
			}
			
			int randomIndex = Random.Range(0, enemies.Length);
			GameObject clone = Instantiate(enemies[randomIndex], newPosition, Quaternion.identity) as GameObject;
			
			float speedMulti = playerController.speed / 10;
			
			var oc = clone.GetComponent<_ObjectControl>();
			oc.velocity *= speedMulti;
			oc.flip = true; //
			
			canSpawn = (int) Random.Range(25 / (maxSpawnPerSecond * speedMulti), 25 / (minSpawnPerSecond * speedMulti));
		}
		
		
	}

}
