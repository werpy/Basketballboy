using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollison : MonoBehaviour
{
	
	private Rigidbody rb;
	public Player player;
	public float MoveSpeed = 5;
	public Transform ball;
	public float MaxDist = 1;
	public float MinDist = 0;

	private void Update() {
		if (!player.holdingBall) {
			transform.LookAt(ball);

			if (Vector3.Distance(transform.position, ball.position) >= MinDist) {

				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

				if (Vector3.Distance(transform.position, ball.position) <= MaxDist) {
					player.ReturnBall();
				}

			}
		}
	}
}
