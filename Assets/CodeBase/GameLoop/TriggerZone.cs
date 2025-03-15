using CodeBase.Interfaces;
using CodeBase.Services;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IItem item))
        {
            EventBus.Instance.onItemDelivered?.Invoke();
            Destroy(other.gameObject);
        }
    }
    
}