using UnityEngine;
using System.Collections;

public class FireBow : MonoBehaviour {
	
	private Vector3 distance;
	private Vector3 minDistance = new Vector3(5.5f, 0, 5.5f);
	private Vector3 defaultPos;
	private Vector3 heroPos;

	private float speed = 100.0f;
	private float step;
	

	Animator animator;

	Transform heroT;
	Transform arrow;

	GameObject hero;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

		hero = GameObject.Find ("ThirdPersonController");
		heroT = hero.transform;
		arrow = transform.Find ("Arrow");

		defaultPos = arrow.position;

	
		animator.SetBool ("HasFinished", true);

	
	}
	
	// Update is called once per frame
	void Update () {

		if (!arrow)
			return;

		distance = transform.position - heroT.position;

		heroPos = new Vector3 (heroT.position.x, arrow.position.y, heroT.position.z);
		step = speed * Time.deltaTime;
	
		
		if (((Mathf.Abs (distance.x) < minDistance.x) && (Mathf.Abs (distance.z) < minDistance.z)) && animator.GetBool("HasFinished")) {
			animator.SetBool ("IsFiring", true);
			arrow.position = defaultPos;

			//arrow.transform.position = Vector3.MoveTowards(defaultPos, defaultPos,0);	
		}		
	}
	
	public void FireArrow()
	{
		arrow.position = Vector3.MoveTowards(defaultPos, heroPos, step);
	

	}



	public void FiringFalse() {
		animator.SetBool ("HasFinished", true);
		animator.SetBool ("IsFiring", false);


	}
	public void FiringTrue() {
		animator.SetBool ("HasFinished", false);
	}


	
}
