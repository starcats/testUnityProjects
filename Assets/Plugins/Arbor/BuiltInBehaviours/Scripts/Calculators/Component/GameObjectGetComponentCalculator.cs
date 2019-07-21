using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectからComponentを出力する。
	/// </summary>
#else
	/// <summary>
	/// Output Component from GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Component/GameObject.GetComponent")]
	[BehaviourTitle("GameObject.GetComponent")]
	[BuiltInBehaviour]
	public sealed class GameObjectGetComponentCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// GameObject
		/// </summary>
		[SerializeField] private FlexibleGameObject _GameObject = new FlexibleGameObject();

		/// <summary>
		/// Component
		/// </summary>
		[SerializeField]
		private OutputSlotComponent _Component = new OutputSlotComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 常にGetComponentするかどうか。<br/>
		/// falseの場合、GameObjectが更新されるまで一度GetComponentした内容がキャッシュされます。
		/// </summary>
#else
		/// <summary>
		/// Whether to always GetComponent.<br/>
		/// If false, GetComponent contents once cached until the GameObject is updated.
		/// </summary>
#endif
		[SerializeField]
		private bool _AlwaysGetComponent = true;

#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			GameObject gameObject = _GameObject.value;
			if (gameObject != null)
			{
				_Component.SetValue(gameObject.GetComponent(_Component.dataType));
			}
		}

		public override bool OnCheckDirty()
		{
			return _AlwaysGetComponent;
		}
	}
}