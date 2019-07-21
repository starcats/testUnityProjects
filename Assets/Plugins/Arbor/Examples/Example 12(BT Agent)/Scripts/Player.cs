using UnityEngine;
using System.Collections;

namespace Arbor.Example
{
	[AddComponentMenu("Arbor/Example/Player")]
	[RequireComponent(typeof(CharacterController))]
	public class Player : MonoBehaviour
	{
		public float speed = 10.0f;
		public float rotateSpeed = 180.0f;

		private Transform _Transform;
		private CharacterController _Controller;
		
		// Use this for initialization
		void Start()
		{
			_Transform = GetComponent<Transform>();
			_Controller = GetComponent<CharacterController>();
		}

		// Update is called once per frame
		void Update()
		{
			Vector3 moveDirection = Vector3.zero;
			if (_Controller.isGrounded)
			{
				Vector3 cameraForward = Camera.main.transform.forward;
				cameraForward.y = 0f;
				Vector3 cameraRight = Camera.main.transform.right;
				cameraRight.y = 0f;

				moveDirection = cameraRight * Input.GetAxis("Horizontal") + cameraForward * Input.GetAxis("Vertical");
				moveDirection.Normalize();
			}

			Vector3 velocity = moveDirection * speed;

			velocity += Physics.gravity * Time.deltaTime;

			_Controller.Move(velocity * Time.deltaTime);

			if (!Mathf.Approximately(moveDirection.sqrMagnitude, 0))
			{
				_Transform.rotation = Quaternion.RotateTowards(_Transform.rotation, Quaternion.LookRotation(moveDirection, Vector3.up), rotateSpeed * Time.deltaTime);
			}
		}
	}
}