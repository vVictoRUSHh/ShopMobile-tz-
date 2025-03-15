using UnityEngine;

namespace CodeBase.Interfaces
{
    public interface IItem
    {
        public GameObject GetItem();
        public void TakeItem(Transform spawnPoint);
    }
}