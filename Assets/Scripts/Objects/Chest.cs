using UnityEngine;

namespace Objects
{
    public class Chest: MonoBehaviour
    {
        [SerializeField] private Item[] items;

        // Доработать
        public void Open()
        {
            foreach (var item in items)
            {
                GameObject prefab = item.GetPrefab();
                prefab.transform.position = transform.position;
                Instantiate(prefab);
            }
            Destroy(gameObject);
        }
    }
}