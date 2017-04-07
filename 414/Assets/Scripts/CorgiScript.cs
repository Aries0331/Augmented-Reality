using UnityEngine;
using System.Collections;

public class CorgiScript : MonoBehaviour {

	Animator anim;
	int barkHash = Animator.StringToHash("IsBarking");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//StartCoroutine ("Move");
	}

	// Update is called once per frame
	void Update () {
		float walk = Input.GetAxis ("Vertical");
		anim.SetFloat ("IsWalking", walk);
		//transform.Translate(Vector3.forward * 3f * Time.deltaTime); 

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger (barkHash);
		}
	}
	/*
	IEnumerator Move() {


		while (true) {
			yield return new WaitForSeconds (3.5f);
			//transform.eulerAngles += new Vector3 (0, 180f, 0);
		}
	}*/
}