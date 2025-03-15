using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  // Игрок, за которым будет следовать камера
    [SerializeField] private Vector3 offset;  // Смещение камеры относительно игрока
    [SerializeField] private float smoothSpeed = 0.125f;  // Скорость сглаживания движения камеры

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Вычисляем желаемое положение камеры
        Vector3 desiredPosition = player.position + offset;
        
        // Сглаживаем движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Устанавливаем камеру в вычисленное положение
        transform.position = smoothedPosition;

        // Камера всегда смотрит на игрока
        transform.LookAt(player);
    }
}