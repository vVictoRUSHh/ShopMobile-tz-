using CodeBase.Services;
using UnityEngine;
public class ItemsCounter : MonoBehaviour
{
    public int _itemsCount;
    public int _currentItemsCount;
    private void Update()
    {
        CheckWin();
    }
    private void OnEnable()
    {
        EventBus.Instance.onItemDelivered += IncreaseCurrentCount;
    }

    private void OnDisable()
    {
        EventBus.Instance.onItemDelivered += IncreaseCurrentCount;
    }

    private void IncreaseCurrentCount() => _currentItemsCount++;

    private void CheckWin()
    {
        if(_itemsCount == _currentItemsCount)EventBus.Instance.onPlayerWin?.Invoke();
    }
}