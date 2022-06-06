using cooking.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
	public class Layer : MonoBehaviour
	{
		[FormerlySerializedAs("_layerType")] [SerializeField] public Layers Type;
		
		public void Add(MonoBehaviour behaviour)
		{
			Add(behaviour.gameObject);
		}

		public void Add(GameObject gameObject)
		{
			gameObject.transform.SetParent(transform, false);
		}

		public GameObject Spawn(GameObject asset)
		{
			GameObject instance = GameObject.Instantiate(asset, transform, false);
			return instance; 
		}
        
		public void Add(GameObject gameObject, bool saveWorldPosition = false)
		{
			gameObject.transform.SetParent(transform, saveWorldPosition);
		}
	}
}