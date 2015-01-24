using UnityEngine;

public class RotateAround : MonoBehaviour
{
	public GameObject Target;
	public float RotationSpeed;
	public Vector3 axis = -Vector3.forward;

	public float MaxSpeed;
	public float SpeedStep;

	private Transform targetTransform;
	private Vector3 desiredPosition;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Planet")
		{
			other.gameObject.GetComponent<MoodMeter>().IncreaseMood();
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Planet")
		{
			other.gameObject.GetComponent<MoodMeter>().IncreaseMood();
		}
	}


	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Planet")
		{
			other.gameObject.GetComponent<MoodMeter>().ResetMoodMultiplier();
		}
	}

	void Start ()
	{
		targetTransform = Target.transform;
	}

	void Update ()
	{
		float tempRotateSpeed = RotationSpeed;

//		if (Input.GetKey(KeyCode.UpArrow))
//		{
//			tempRotateSpeed *= SpeedMultiplier;
//		}
//		else if (Input.GetKey(KeyCode.DownArrow))
//		{
//			tempRotateSpeed *= SpeedDivisioner;
//		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			RotationSpeed -= SpeedStep;
			RotationSpeed = (RotationSpeed < -MaxSpeed) ? -MaxSpeed : RotationSpeed;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			RotationSpeed += SpeedStep;
			RotationSpeed = (RotationSpeed > MaxSpeed) ? MaxSpeed : RotationSpeed;
		}
		else if ( ! Input.anyKeyDown)
		{
			if (RotationSpeed > 0)
			{
				RotationSpeed -= 2;
				if (RotationSpeed < 0)
					RotationSpeed = 0;
			}

			else if (RotationSpeed < 0)
			{
				RotationSpeed += 2;
				if (RotationSpeed > 0)
					RotationSpeed = 0;
			}

//			RotationSpeed 
		}

		transform.RotateAround (targetTransform.position, axis, tempRotateSpeed * Time.deltaTime);
	}
}