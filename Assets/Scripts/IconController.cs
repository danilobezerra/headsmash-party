using UnityEngine;
using System.Collections;

public class IconController : MonoBehaviour {
	[System.Serializable] public class Icon {
		public GameObject prefab;
		public AudioClip sfx;
	}
	
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private Icon[] icons;
	[SerializeField] private IconSpawn[] iconsSpawn;
	
	
	private int lastIconSelected;
	

	// Use this for initialization
	IEnumerator Start () {
		lastIconSelected = -1;
		
		yield return new WaitForSeconds(6);
		StartCoroutine(PartyRules());
		
		yield return new WaitForSeconds(8);
		StartCoroutine(PartyRules());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator PartyRules() {
		int randomIndex = 0;
		bool match = false;
		
		while (!match) {
			randomIndex = Random.Range(0, icons.Length);
			if (randomIndex != lastIconSelected) {
				match = true;
			}
		}
		
		lastIconSelected = randomIndex;
		audioSource.PlayOneShot(icons[randomIndex].sfx);
		
		foreach (var item in iconsSpawn) {
			item.NewIcon(icons[randomIndex].prefab);
		}
		
		yield return new WaitForSeconds(2.3f);
	}
	
}
