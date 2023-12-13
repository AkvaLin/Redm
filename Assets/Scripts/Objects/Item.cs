using UnityEngine;

namespace Objects
{
    public class Item
    {
        [SerializeField] private GameObject prefab;

        public GameObject GetPrefab()
        {
            return prefab;
        }
    }
}