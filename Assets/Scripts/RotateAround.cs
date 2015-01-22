using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
		public GameObject Target;
	public float rotationSpeed = 80.0f;

//		public float radius = 2.0f;
//		public float radiusSpeed = 0.5f;
		
	public Vector3 axis = -Vector3.forward;

	private Transform targetTransform;
	private Vector3 desiredPosition;

		void Start ()
		{
				targetTransform = Target.transform;
//				transform.position = (transform.position - center.position).normalized * radius + center.position;
//				radius = 2.0f;

//				axis = 
		}

		void Update ()
		{
				transform.RotateAround (targetTransform.position, axis, rotationSpeed * Time.deltaTime);
//				desiredPosition = (transform.position - center.position).normalized * radius + center.position;
//				desiredPosition = (transform.position - center.position).normalized + center.position;
//				transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

//				RotateLeft ();
		}

		void RotateLeft ()
		{
				Quaternion theRotation = transform.localRotation;
				theRotation.z *= 270;
				transform.localRotation = theRotation;
		}
}