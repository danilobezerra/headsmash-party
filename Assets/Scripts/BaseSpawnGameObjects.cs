using UnityEngine;

namespace Framework.Template {
    public abstract class BaseSpawnGameObjects : MonoBehaviour {
        private float nextSpawnTime;
        
        protected virtual void Start() {
            nextSpawnTime = HandleNextSpawn();
        }
        
        protected virtual void Update() {
            if (Time.time >= nextSpawnTime) {
                MakeThingToSpawn();
                nextSpawnTime = HandleNextSpawn();
            }
        }

        protected virtual GameObject SpawnClone(GameObject spawnPrefab, Vector3 position, Quaternion rotation) {
            Object clone = Instantiate(spawnPrefab, position, rotation);
            return clone as GameObject;
        }
        
        protected abstract void MakeThingToSpawn();
        protected abstract float HandleNextSpawn();
    }
}