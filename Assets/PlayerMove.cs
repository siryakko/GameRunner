using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public int speed = 20; // Vitesse déplacement
	public int moveSpeed = 4;
	public int jumpPower = 350; // Puissance saut
	private bool canJump = true; // Peut on sauter ?
	public static int nbBlocks = 1; // Nombre de blocks générés

 	void Update ()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		float translation = Input.GetAxis("Horizontal") *moveSpeed;
		translation *= Time.deltaTime;
		transform.Translate(translation,0,0);


//		Mouvements Step by Step

//		if(Input.GetKeyDown(KeyCode.RightArrow))
//		{
//			transform.Translate(Vector3.right*moveSpeed*Time.deltaTime); // On va a droite
//		}
//
//		if(Input.GetKeyDown(KeyCode.LeftArrow))
//		{
//			transform.Translate(Vector3.left*moveSpeed*Time.deltaTime); // Gauche
//		}
//
		if(Input.GetButtonDown("Jump"))
		{
			if(canJump)
			{
				canJump = false;
				StartCoroutine(jump()); // On saute
			}
		}

	}

	IEnumerator jump()
		{
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
			yield return new WaitForSeconds(1);
			canJump = true;
		}

}