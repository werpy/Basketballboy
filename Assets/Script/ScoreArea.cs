using UnityEngine;

public class ScoreArea : MonoBehaviour {
	[Header("Objects")]
	public ParticleSystem particleBurst;

	[Space]

	public float hitHeight = 8;

	void OnTriggerEnter(Collider coll) {
		if (coll.name == "Ball" && coll.transform.position.y > hitHeight) {
			particleBurst.Play();
		}
	}
}
