using UnityEngine;
using System.Collections;

public class ScareTrap : Trap {
	public GameObject spook_prefab;
	public AudioClip spook_sound;
	public float spook_volume = 0.7f;
	private AudioSource audio_source;

	void Start() {
		audio_source = GetComponent<AudioSource>();
	}

	protected override void Explode(GameObject player) {
		GameObject inst;

		if (spook_prefab) {
			inst = Instantiate(spook_prefab);
			inst.transform.position = GetComponent<Transform>().position;
			// TODO animate
		}
		if (spook_sound && audio_source) {
			audio_source.PlayOneShot(spook_sound, spook_volume);
		}

		// TODO notify robots and the write the silent trap
	}
}
