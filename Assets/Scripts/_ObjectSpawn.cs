using UnityEngine;

public class _ObjectSpawn : MonoBehaviour {
	public bool spawning = false;
	private GameObject newEnemy;
	private int canSpawn = 1;
	public int player = 1;
	public float minSpawnPerSecond = 0.3f;
	public float maxSpawnPerSecond = 0.6f;
	public GameObject[] Enemy;
	public _PlayerStats playerStats;

	public GameObject bgA;
	public GameObject bgB;
	public _bgControl bgScriptA;
	public _bgControl bgScriptB;

	void Start() {
		playerStats = gameObject.GetComponent<_PlayerStats>();
		bool logic;
		
		if (player == 1) {
			logic = false;
		} else {
			logic = true;
		}
		
		bgScriptA = bgA.GetComponent<_bgControl>();
		bgScriptA.dirRight = logic;
		bgScriptB = bgB.GetComponent<_bgControl>();
		bgScriptB.dirRight = logic;	
	}
	
	void FixedUpdate() {
		canSpawn -= 1;
		
		if (spawning && canSpawn <= 0) {
			int randObstacle = Random.Range(0, Enemy.Length);
			int randPos = Random.Range(1, 4);
			float newPos = 0;
			
			switch (randPos) {
				case 1:
					newPos = -3.5f;
					break;
				case 2:
					newPos = -0.5f;
					break;
				case 3:
					newPos = 1.5f;
					break;
			}
			
			newEnemy = Instantiate(Enemy[randObstacle], new Vector3(0, newPos, 0), Quaternion.identity) as GameObject;
			_ObjectControl oc = null;
			float speedMulti = 0;
			
			if (player == 1) {
				speedMulti = playerStats.P1Speed / 10;
				oc = newEnemy.GetComponent<_ObjectControl>();
				oc.dirRight = false;
			} else {
				speedMulti = playerStats.P2Speed / 10;
				oc = newEnemy.GetComponent<_ObjectControl>();
				oc.dirRight = true;
			}
			
			oc = newEnemy.GetComponent<_ObjectControl>();
			oc.speed *= speedMulti;
			canSpawn = (int) Random.Range((25 / (maxSpawnPerSecond * speedMulti)), (25 / (minSpawnPerSecond * speedMulti)));
		}
		
		float newSpeed = 0;
		
		if (player == 1) {
			newSpeed = playerStats.P1Speed;
		} else{
			newSpeed = playerStats.P2Speed;
		}
		
		bgScriptA.speed = newSpeed;
		bgScriptB.speed = newSpeed;
	}
}
