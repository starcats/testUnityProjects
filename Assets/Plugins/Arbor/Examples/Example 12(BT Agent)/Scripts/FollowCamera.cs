using UnityEngine;
using System.Collections;

namespace Arbor.Example
{
	[AddComponentMenu("Arbor/Example/FollowCamera")]
	public class FollowCamera : MonoBehaviour
	{
		public float distance = 10f;
		public Vector3 lookOffset = Vector3.up * 1.0f;

		private Transform _Transform;
		private Transform _PlayerTransform;

		private Vector3 _Direction;

		private void Start()
		{
			_Transform = GetComponent<Transform>();

			Player player = FindObjectOfType<Player>();
			_PlayerTransform = player.GetComponent<Transform>();

			_Transform.LookAt(_PlayerTransform.position + lookOffset, Vector3.up);

			_Direction = (_PlayerTransform.position - _Transform.position).normalized;
		}

		// Update is called once per frame
		void LateUpdate()
		{
			Vector3 playerPosition = _PlayerTransform.position;

			_Transform.position = playerPosition - _Direction * distance;

			_Transform.LookAt(_PlayerTransform.position + lookOffset, Vector3.up);
		}
	}
}