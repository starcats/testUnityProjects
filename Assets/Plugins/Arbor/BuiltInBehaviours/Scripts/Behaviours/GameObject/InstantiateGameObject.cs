using UnityEngine;
using UnityEngine.Serialization;
using Arbor.ObjectPooling;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectを生成する。
	/// </summary>
#else
	/// <summary>
	/// GameObject the searches in the tag and then stored in the parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/InstantiateGameObject")]
	[BuiltInBehaviour]
	public sealed class InstantiateGameObject : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 生成するGameObject。
		/// </summary>
#else
		/// <summary>
		/// The Instantiated GameObject.
		/// </summary>
#endif
		[SerializeField] private FlexibleGameObject _Prefab = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 親に指定するTransform。
		/// </summary>
#else
		/// <summary>
		/// Transform that specified in the parent.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Parent = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 初期時に指定するTransform。
		/// </summary>
#else
		/// <summary>
		/// Transform that you specify for the initial time.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _InitTransform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// ObjectPoolを使用してインスタンス化するフラグ。
		/// </summary>
#else
		/// <summary>
		/// Flag to instantiate using ObjectPool.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBool _UsePool = new FlexibleBool();

#if ARBOR_DOC_JA
		/// <summary>
		/// 格納先のパラメータ
		/// </summary>
#else
		/// <summary>
		/// Storage destination parameters
		/// </summary>
#endif
		[SerializeField] private GameObjectParameterReference _Parameter = new GameObjectParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算ノードへの出力。
		/// </summary>
#else
		/// <summary>
		/// Output to the calculator node.
		/// </summary>
#endif
		[SerializeField] private OutputSlotGameObject _Output = new OutputSlotGameObject();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("_Prefab")]
		private GameObject _OldPrefab = null;

		#endregion // old

		#endregion // Serialize fields

		private const int kCurrentSerializeVersion = 1;

		GameObject Internal_Instantiate(GameObject prefab)
		{
			if (_UsePool.value)
			{
				return ObjectPool.Instantiate(prefab) as GameObject;
			}
			else
			{
				return Object.Instantiate(prefab) as GameObject;
			}
		}

		GameObject Internal_Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			if (_UsePool.value)
			{
				return ObjectPool.Instantiate(prefab, position, rotation) as GameObject;
			}
			else
			{
				return Object.Instantiate(prefab, position, rotation) as GameObject;
			}
		}

		public override void OnStateBegin()
		{
			if( _Prefab != null )
			{
				GameObject obj = null;
                if (_InitTransform.value == null)
				{
					obj = Internal_Instantiate(_Prefab.value) as GameObject;
                }
				else
				{
					obj = Internal_Instantiate(_Prefab.value, _InitTransform.value.position, _InitTransform.value.rotation) as GameObject;
				}

				if (_Parent.value != null)
				{
					obj.transform.SetParent(_Parent.value, _InitTransform.value != null);
				}

				if (_Parameter.parameter != null)
				{
					_Parameter.parameter.gameObjectValue = obj;
				}

				_Output.SetValue(obj);
            }
		}

		void SerializeVer1()
		{
			_Prefab = (FlexibleGameObject)_OldPrefab;
		}

		void Serialize()
		{
			while (_SerializeVersion != kCurrentSerializeVersion)
			{
				switch (_SerializeVersion)
				{
					case 0:
						SerializeVer1();
						_SerializeVersion++;
						break;
					default:
						_SerializeVersion = kCurrentSerializeVersion;
						break;
				}
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			Serialize();
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			Serialize();
		}
	}
}
