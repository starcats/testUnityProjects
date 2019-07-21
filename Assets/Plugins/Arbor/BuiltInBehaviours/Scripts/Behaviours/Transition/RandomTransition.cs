using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ランダムに遷移する。
	/// </summary>
#else
	/// <summary>
	/// Transit randomly.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/RandomTransition")]
	[BuiltInBehaviour]
    public sealed class RandomTransition : StateBehaviour
    {
		#region inner class

#if ARBOR_DOC_JA
		/// <param name="Probability">実際の確率</param>
#else
		/// <param name="Probability">Actual probability</param>
#endif
		[System.Serializable]
		[Arbor.Internal.Documentable]
		public class LinkWeight
        {
#if ARBOR_DOC_JA
			/// <summary>
			/// 遷移しやすさ。個別のWeight/全体のWeightによって確率が決まる。
			/// </summary>
#else
			/// <summary>
			/// Ease of transition. Probability depends on individual weight / overall weight.
			/// </summary>
#endif
			[Range(0, 100)]
			public float weight = 0f;

#if ARBOR_DOC_JA
			/// <summary>
			/// 遷移先ステート。<br />
			/// 遷移メソッド : OnStateBegin
			/// </summary>
#else
			/// <summary>
			/// Transition destination state.<br />
			/// Transition Method : OnStateBegin
			/// </summary>
#endif
			public StateLink link = new StateLink();
        }

#endregion // inner class

#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先リスト。
		/// </summary>
#else
		/// <summary>
		/// Transition destination list.
		/// </summary>
#endif
		[SerializeField]
        private List<LinkWeight> _Links = new List<LinkWeight>();

#endregion // Serialize fields

		public float GetTotalWeight()
		{
			if( _Links.Count == 0 )
			{
				return 0;
			}

			float totalWeight = 0.0f;

			int linkCount = _Links.Count;
			for( int linkIndex = 0 ; linkIndex < linkCount ; linkIndex++ )
			{
				LinkWeight link = _Links[linkIndex];
				totalWeight += link.weight;
			}

			return totalWeight;
		}

        StateLink GetRandomLink()
        {
           float totalWeight = GetTotalWeight();

            if (totalWeight == 0.0f)
            {
                return null;
            }

            float r = Random.Range(0, totalWeight);

            totalWeight = 0.0f;

            int index = 0;

			int linkCount = _Links.Count;
			for (int linkIndex = 0; linkIndex < linkCount; linkIndex++)
            {
                LinkWeight link = _Links[linkIndex];

                if (totalWeight <= r && r < totalWeight + link.weight)
                {
                    index = linkIndex;
                    break;
                }

                totalWeight += link.weight;
            }

            return _Links[index].link;
        }

        // Use this for enter state
        public override void OnStateBegin()
        {
            StateLink link = GetRandomLink();
            if (link != null)
            {
                Transition(link);
            }
        }
    }
}
