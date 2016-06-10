using UnityEngine;
using System.Collections;

public class StunTrap : Trap {
	public GameObject gas_prefab;

	protected override void Explode(GameObject player) {
		GameObject inst;

		if (gas_prefab) {
			inst = Instantiate(gas_prefab);
			inst.transform.position = GetComponent<Transform>().position;
			inst.GetComponent<ParticleSystem>().Play();
		}

		// TODO call into burglar
	}
}
