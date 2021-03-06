using UnityEngine;
using System.Collections;
using System.Threading;
//By:Matt Braden
public class MovementCS : MonoBehaviour {
	//Used to manipulate the rigidbody (an object that you can apply physics to
	public Rigidbody2D rb;
	//You can change this value in the 'inspector' because it is a 'public' variable
	public float maxSpeed = 5;
	//this happens when the game starts
	void Start () {
		//this assigns the rigidbody to the one this is attached to
		rb = GetComponent<Rigidbody2D> ();
		//makes the cursor invisible
		Cursor.visible = false;
	}
	//update every FRAME (make note of that)
	void Update () {
		//you can use my posx,y code over here to move reliably, though I use the rigidbody
		float posx = gameObject.transform.position.x;
		float posy = gameObject.transform.position.y;
		//the speed to add
		float speed = 40f;
		//This is how if statements work. the others are while, for, do, and switch
		//this tests if the velocity is over the max, if it is, it will change it to it. this prevents crazy velocities.
		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = maxSpeed * rb.velocity.normalized;
		//Input.GetKeyDown will only activate when it is pressed, but getkey will update as long as it is held
		if(Input.GetKeyDown("up")){
			//adds force to the rigidbody in the specified direction.
			rb.AddForce (transform.up*(speed+1500));
		}if(Input.GetKey("left")){
			rb.AddForce ((-1*transform.right)*speed);
		}if(Input.GetKey("right")){
			rb.AddForce (transform.right*speed);
		}
		//changes the pos to the posx,y 
		gameObject.transform.position = new Vector2(posx,posy);
	}
}
