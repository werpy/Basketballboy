using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[Header("Objects")]
	public GameObject ball;
	public GameObject playerCamera;
	public GameObject respawn;
	public Text forceText;
	public Text getBallText;

	[Space]

	[Header("Ball options")]
	public float ballDistance = 2f;
	public float ballThrowingForce = 550f;
	public float ballThrowingForceMin = 200f;
	public float ballThrowingForceMax = 1000f;
	[Range(5, 50)]
	public float ballThrowingForceRange = 20f;
	public float ballThrowingForceRandMin = -0.10f;
	public float ballThrowingForceRandMax = 0.10f;


	public bool holdingBall = true;

	private Rigidbody rb;
	private Collider col;


	void Start() {
		rb = ball.GetComponent<Rigidbody>();
		col = ball.GetComponent<Collider>();
		forceText.text = "Сила броска: " + ballThrowingForce;
	}

	void Update() {
		if (holdingBall) {
			ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

			if (Input.GetMouseButtonDown(0)) {
				ThrowBall();
			}
		}
		else if (Input.GetMouseButtonDown(1)) {
			ReturnBall();
		}
		if (ball.transform.position.y < -6) {
			ReturnBall();
		}
		if (gameObject.transform.position.y < -6) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		float direction = Input.GetAxis("Mouse ScrollWheel");

		if (direction != 0) {
			BallThrowingForceUpgrade(direction * 10);
		}
	}

	public void BallThrowingForceUpgrade(float direction) {
		ballThrowingForce = Mathf.Clamp(ballThrowingForce + direction * ballThrowingForceRange, ballThrowingForceMin, ballThrowingForceMax);

		forceText.text = "Сила броска: " + ballThrowingForce;
	}

	public void ReturnBall() {
		if (!holdingBall) {
			col.enabled = false;
			holdingBall = true;
			rb.angularVelocity = Vector3.zero;
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			print("Мяч получен");
			getBallText.gameObject.SetActive(false);
		}
	}

	public void ThrowBall() {
		col.enabled = true;
		holdingBall = false;
		rb.useGravity = true;

		
		float randomNumber = Random.Range(ballThrowingForceRandMin, ballThrowingForceRandMax);

		Debug.Log(randomNumber);

		ballThrowingForceRandMin -= (ballThrowingForceRandMin / 100) * 5;
		ballThrowingForceRandMax -= (ballThrowingForceRandMax / 100) * 5;

		Vector3 ptf = playerCamera.transform.forward;
		ptf.x = ptf.x + randomNumber;
		ptf.y = ptf.y + randomNumber;

		float randomForce = Random.Range(-50, 50);
		float ballThrowingForceRand = ballThrowingForce + randomForce;
		forceText.text = "Сила броска: " + ballThrowingForceRand;

		rb.AddForce(ptf * ballThrowingForceRand);
	}
}