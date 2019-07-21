using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// レイキャストによって遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition by Ray cast.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Physics/RaycastTransition")]
	[BuiltInBehaviour]
	public sealed class RaycastTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// レイの始点
		/// </summary>
#else
		/// <summary>
		/// The starting point of the Ray
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _Origin = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// レイの方向
		/// </summary>
#else
		/// <summary>
		/// Direction of Ray
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _Direction = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// レイの距離
		/// </summary>
#else
		/// <summary>
		/// Distance of Ray
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Distance = new FlexibleFloat(Mathf.Infinity);

#if ARBOR_DOC_JA
		/// <summary>
		/// 判定対象のレイヤー
		/// </summary>
#else
		/// <summary>
		/// Determination target layer
		/// </summary>
#endif
		[SerializeField] private LayerMask _LayerMask = Physics.DefaultRaycastLayers;

#if ARBOR_DOC_JA
		/// <summary>
		/// Update時に判定するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether or not to make an update decision.
		/// </summary>
#endif
		[SerializeField] private bool _CheckUpdate = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// タグをチェックするかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to check the tag.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBool _IsCheckTag = new FlexibleBool();

#if ARBOR_DOC_JA
		/// <summary>
		/// チェックするタグ。
		/// </summary>
#else
		/// <summary>
		/// Tag to be checked.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleString _Tag = new FlexibleString("Untagged");

#if ARBOR_DOC_JA
		/// <summary>
		/// レイキャストによるヒット情報を出力。
		/// </summary>
#else
		/// <summary>
		/// Output hit information by raycast.
		/// </summary>
#endif
		[SerializeField] private OutputSlotRaycastHit _RaycastHit = new OutputSlotRaycastHit();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnStateBegin, OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnStateBegin, OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void CheckRaycast()
		{
			RaycastHit hit;
			if (Physics.Raycast(_Origin.value, _Direction.value, out hit, _Distance.value, _LayerMask.value))
			{
				if (!_IsCheckTag.value || hit.collider.tag == _Tag.value)
				{
					_RaycastHit.SetValue(hit);
					Transition(_NextState);
				}
			}
		}

		public override void OnStateBegin()
		{
			CheckRaycast();
		}

		// Update is called once per frame
		public override void OnStateUpdate()
		{
			if (_CheckUpdate)
			{
				CheckRaycast();
			}
		}
	}
}
