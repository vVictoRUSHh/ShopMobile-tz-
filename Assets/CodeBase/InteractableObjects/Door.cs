using System.Collections;
using CodeBase.Interfaces;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField] private float openAngle = 90f;  // Угол открытия двери
    [SerializeField] private float speed = 2f;  // Скорость анимации двери
    private Quaternion closedRotation;  // Исходное положение двери
    private Quaternion openRotation;  // Открытое положение двери

    private void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    public void Interact()
    {
        StartCoroutine(AnimateDoor(openRotation));
    }

    private IEnumerator AnimateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            yield return null;
        }
        transform.rotation = targetRotation; // Гарантируем точное попадание
    }
}