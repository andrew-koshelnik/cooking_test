using UnityEngine;

namespace Views
{
	public class DishView : MonoBehaviour
	{
		[SerializeField] private Transform _checkmark;
		[SerializeField] private Transform _dishHolder;

		public void MarkAsDone(bool isDone)
		{
			_checkmark.gameObject.SetActive(isDone);
			_dishHolder.gameObject.SetActive(!isDone);
		}
	}
}