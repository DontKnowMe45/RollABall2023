using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript3 : MonoBehaviour
{
	public Text countText;
	public Text winText;
	public Text loseText;
	public Text timerText;
	public float speed;
	private Rigidbody myBody;
	[HideInInspector]
	public int collectiblesCount;
	private float totalTime;
	private float timeLeft;
	private bool gameWon;
	public bool gameLost;
	public GameObject reset;
	public GameObject next;


	void Start()
	{
		winText.text = "";  //initialize the winText value
		loseText.text = ""; //initialize the loseText value
		totalTime = 40;
		timeLeft = totalTime;
		gameWon = false;
		gameLost = false;
		myBody = GetComponent<Rigidbody>();
		timerText.text = "TIMER: " + timeLeft.ToString("F2");
		collectiblesCount = 0;
		reset.gameObject.SetActive(false);
		next.gameObject.SetActive(false);
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");     //Access the right and left arrow keys
		float moveVertical = Input.GetAxis("Vertical");         //Access the up and down arrow keys
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3s deal with movement in 3D space.  X, Y, and Z aspects.  In this case the Y is zero.  Vector3s take floats.
		myBody.AddForce(movement * speed * Time.deltaTime); //This accesses the rigidbody component and adds force ot get it moving
		YouWin();

		timerText.text = "TIMER: " + timeLeft.ToString("F2");
		if (gameWon == false && gameLost == false)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				gameLost = true;
				loseText.text = "Simulation Failed!\nTry Again?";
				reset.gameObject.SetActive(true);
			}
		}
	}

	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Collectible")
		{
			collectiblesCount += 1;
			countText.text = "SCORE: " + collectiblesCount.ToString() + "/8";
		}
	}

	void YouWin()
	{

		if (collectiblesCount == 8)
		{
			winText.text = "You Win!";
			gameWon = true;
			next.gameObject.SetActive(true);
		}
	}
}