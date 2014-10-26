using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	
	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	void FixedUpdate ()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
		    			
			Vector3 movement = new Vector3 ( moveHorizontal, 0.0F, moveVertical);
			
			rigidbody.AddForce(movement * speed * Time.deltaTime);
		}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count++;
			audio.Play();
			SetCountText();
		}
		
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();		
		if ( count >= 12)
		{
			winText.text = "You Win !!!";
			//this.gameObject.SetActive(false);
			//this.rigidbody.AddExplosionForce (10.0F, transform.position, 5.0F,3.0F);
			winText.audio.Play();
			
		}
	}
}
