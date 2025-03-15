using System.Collections;
using System.Collections.Generic;
using CodeBase.Interfaces;
using UnityEngine;

public class Apple : MonoBehaviour,IItem
{
    private string _objectPath = "Items/Apple";

    public GameObject GetItem()
    {
        return Resources.Load<GameObject>(_objectPath);
    }

    public void TakeItem(Transform spawnPoint)
    {
        GameObject newItem = Instantiate(GetItem(), spawnPoint.position, spawnPoint.rotation);
        newItem.transform.SetParent(spawnPoint);
        Destroy(this.gameObject);
    }
}
