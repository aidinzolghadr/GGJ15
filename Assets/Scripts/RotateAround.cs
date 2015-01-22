using UnityEngine;

public class RotateAround : MonoBehaviour
{
	public GameObject Target;
	public float RotationSpeed;
	public Vector3 axis = -Vector3.forward;

	public float SpeedMultiplier;
	public float SpeedDivisioner;

	private Transform targetTransform;
	private Vector3 desiredPosition;

	void OnTriggerEnter2D (Collider2D other)
	{
//		Debug.Log("increasing");

		if (other.tag == "Planet")
		{
			other.gameObject.GetComponent<MoodMeter>().IncreaseMood();
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Planet")
		{
			other.gameObject.GetComponent<MoodMeter>().DecreaseMood();
			
		}
	}

	void Start ()
	{
		targetTransform = Target.transform;
	}

	void Update ()
	{
		float tempRotateSpeed = RotationSpeed;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			tempRotateSpeed *= SpeedMultiplier;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			tempRotateSpeed *= SpeedDivisioner;
		}

		transform.RotateAround (targetTransform.position, axis, tempRotateSpeed * Time.deltaTime);
	}
}