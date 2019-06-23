using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	[Header("Objects")]
	public Player player;
	public Text getBallText;

	private void OnTriggerStay(Collider obj) {
		if (obj.name == "Player") {
			getBallText.gameObject.SetActive(true);

			if (Input.GetKey(KeyCode.X)) {
				player.ReturnBall();
				getBallText.gameObject.SetActive(false);
			}
		}
	}

	private void OnTriggerExit(Collider obj) {
		if (obj.name == "Player") {
			getBallText.gameObject.SetActive(false);
		}
	}
}
