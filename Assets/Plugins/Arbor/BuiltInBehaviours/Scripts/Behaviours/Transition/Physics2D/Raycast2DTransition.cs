using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 2Dのレイキャストによって遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition by 2D of Ray cast.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Physics2D/Raycast2DTransition")]
	[BuiltInBehaviour]
	public sealed class Raycast2DTransition : StateBehaviour
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
		[SerializeField] private FlexibleVector2 _Origin = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// レイの方向
		/// </summary>
#else
		/// <summary>
		/// Direction of Ray
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _Direction = new FlexibleVector2();

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
		/// 最小の深度値
		/// </summary>
#else
		/// <summary>
		/// Minimum depth value
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _MinDepth = new FlexibleFloat(-Mathf.Infinity);

#if ARBOR_DOC_JA
		/// <summary>
		/// 最大の深度値
		/// </summary>
#else
		/// <summary>
		/// Maximum depth value
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _MaxDepth = new FlexibleFloat(Mathf.Infinity);

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
		/// レイキャストによるヒット情報を出力。
		/// </summary>
#else
		/// <summary>
		/// Output hit information by raycast.
		/// </summary>
#endif
		[SerializeField] private OutputSlotRaycastHit2D _RaycastHit2D = new OutputSlotRaycastHit2D();

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
			RaycastHit2D hit = Physics2D.Raycast(_Origin.value, _Direction.value, _Distance.value, _LayerMask.value, _MinDepth.value, _MaxDepth.value);
			if (hit.collider != null)
			{
				_RaycastHit2D.SetValue(hit);
				Transition(_NextState);
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
