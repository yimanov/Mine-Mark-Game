using UnityEngine;
using System.Collections;

public class GameManager1 : MonoBehaviour
{
	public GameObject brush;//brush

	private Color currentColor;
	private AudioSource audioSource;//audio source
	private Vector3 Postion = Vector3.zero;//mouse or touch postion

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		Postion = Camera.main.ScreenToWorldPoint (Input.mousePosition);//get click position
		Postion.z = -5;

		if (Input.GetMouseButtonDown (0))
		{ 
			RayCast2D ();
		}

		if (brush != null)
		{
			brush.transform.position = Postion;//drag the brush
		}
	}

	//2d screen raycast
	private void RayCast2D ()
	{
		RaycastHit2D rayCastHit2D = Physics2D.Raycast (Postion, Vector2.zero);

		if (rayCastHit2D.collider == null) 
		{
			return;
		}

		if (rayCastHit2D.collider.tag == "BrushColor") 
		{
  			 //set brush color
			currentColor = rayCastHit2D.collider.GetComponent<SpriteRenderer> ().color;
			brush.transform.GetChild(0).GetComponent<SpriteRenderer>().color = currentColor;
		} 
		else if (rayCastHit2D.collider.tag == "ImagePart")
		{
            //full image part
			rayCastHit2D.collider.GetComponent<SpriteRenderer> ().color = currentColor;
			audioSource.Play();
		}
	}
}