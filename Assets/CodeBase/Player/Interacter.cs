using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Interfaces;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Transform _handPosition;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            InteractCheck(ray);
        }
    }

    private void  InteractCheck(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact(); 
            }
            if (hit.collider.TryGetComponent(out IItem item))
            {
                item.TakeItem(_handPosition); 
            }
        }

    }
}
