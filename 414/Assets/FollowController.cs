using UnityEngine;
using System.Collections;

public class FollowController : MonoBehaviour {

	public GameObject StartObj;
	public GameObject TargetObj;
	public float FollowSpeed; // 2.0 default

	public GameObject detectDirectionObject;
	private DetectDirection detectDirectionScript;
	private Animator anim;

	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<Renderer>().enabled = false;
		detectDirectionScript = detectDirectionObject.GetComponent<DetectDirection>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		//Play left/right animation
		if (detectDirectionScript.Dir == "Left")
		{
			anim.SetInteger("turn", 1);
			StartCoroutine(PlayIdleAnimation());
		}
		else if (detectDirectionScript.Dir == "Right")
		{
			anim.SetInteger("turn", 2);
			StartCoroutine(PlayIdleAnimation());
		}

		//Draw line to target object
		Debug.DrawLine(TargetObj.transform.position, StartObj.transform.position, Color.red);

		//Look at target
		StartObj.transform.rotation = Quaternion.Slerp(StartObj.transform.rotation, Quaternion.LookRotation(TargetObj.transform.position - StartObj.transform.position), FollowSpeed * Time.deltaTime);

		//Count direction angle
		Vector3 startDir = StartObj.transform.position;
		startDir.y = 0;
		Vector3 targetDir = TargetObj.transform.position;
		targetDir.y = 0;
		float angle = Vector3.Angle(targetDir, startDir);
		//Debug.Log(angle);
	}

	IEnumerator PlayIdleAnimation()
	{
		yield return new WaitForSeconds(1.1f);
		detectDirectionScript.Dir = "";
		anim.SetInteger("turn", 0);
	}
}
