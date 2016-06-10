using UnityEngine;
using System.Collections;

public abstract class Trap : MonoBehaviour {
	public float radius;

	GameObject CheckForBurglar() {
		Collider[] hitColliders = Physics.OverlapSphere(GetComponent<Transform>().position, radius);
		for (int i = 0; i < hitColliders.Length; ++i) {
			// TODO check for burglar
			if (hitColliders[i] == GetComponent<Collider>())
				continue;
			return hitColliders[i].gameObject;
		}

		return null;
	}

	protected abstract void Explode(GameObject player);

	void Update() {
		GameObject player;

		player = CheckForBurglar();
		if (player) {
			Explode(player);
			Destroy(this);
		}

	}

	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
		Gizmos.DrawSphere(GetComponent<Transform>().position, radius);
	}
}

