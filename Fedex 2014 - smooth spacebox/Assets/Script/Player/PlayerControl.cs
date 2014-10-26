using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	private GameObject moveJoy;
	private GameObject _GameManager;
	public Vector3 movement;
	public float moveSpeed = 6.0f;
	public float jumpSpeed = 5.0f;
	public float drag = 2;
	private bool canJump = true;
	
	void Start()
	{
		moveJoy = GameObject.Find("LeftJoystick");
		_GameManager = GameObject.Find("_GameManager");
	}
	
	void Update () 
	{	
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 ( moveHorizontal, 0.0F, moveVertical);
		
		rigidbody.AddForce(movement * moveSpeed * Time.deltaTime * 100);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Destroy")
		{
			_GameManager.GetComponent<GameManager>().Death();
			Destroy(gameObject);
		}
		else if (other.tag == "Coin")
		{
			Destroy(other.gameObject);
			_GameManager.GetComponent<GameManager>().FoundCoin();
		}
		else if (other.tag == "SpeedBooster")
		{
			movement = new Vector3(0,0,0);
			_GameManager.GetComponent<GameManager>().SpeedBooster();
		}
		else if (other.tag == "JumpBooster")
		{
			movement = new Vector3(0,0,0);
			_GameManager.GetComponent<GameManager>().JumpBooster();
		}
		else if (other.tag == "Teleporter")
		{
			movement = new Vector3(0,0,0);
			_GameManager.GetComponent<GameManager>().Teleporter();
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if (!canJump)
		{
			canJump = true;
			_GameManager.GetComponent<GameManager>().BallHitGround();
		}
    }
	
	void OnGUI()
	{
		GUI.Label(new Rect(300,10,100,100),"X: " + moveJoy.GetComponent<Joystick>().position.x.ToString());
		GUI.Label(new Rect(300,30,100,100),"Y: " + moveJoy.GetComponent<Joystick>().position.y.ToString());
	}
}
