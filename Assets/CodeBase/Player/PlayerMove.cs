using System;
using CodeBase.Infrastructure;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform cameraTransform; // Камера прикреплена к игроку
    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isRotating = false;
    private Vector2 touchStartPos;
    public float rotationSpeed = 150f;
    public RectTransform touchZone;

    private void Update()
    {
        HandleCameraRotation();
        MovePlayer();
    }

    private void Start()
    {
        touchZone = GameObject.FindGameObjectWithTag("TouchArea").GetComponent<RectTransform>();
    }

    private void MovePlayer()
    {
        // Получаем входные данные для движения (по осям X и Z)
        Vector3 moveVector = new Vector3(Game._inputService._inputAxis.x, 0, Game._inputService._inputAxis.y);

        // Если есть входные данные для движения
        if (moveVector != Vector3.zero)
        {
            // Преобразуем вектор в направлении камеры
            moveVector = cameraTransform.TransformDirection(moveVector); // Двигаемся в направлении камеры
            moveVector.y = 0; // Убираем вертикальную компоненту

            moveVector.Normalize(); // Нормализуем вектор, чтобы движение было постоянным

            // Поворот игрока в направлении движения (не должно происходить самоповорота)
            transform.forward = moveVector;  

            // Перемещаем персонажа
            transform.position += moveVector * _speed * Time.deltaTime;  
        }
    }

    void HandleCameraRotation()
    {
        // Проверяем, есть ли хотя бы один касание
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Проверяем, находится ли касание внутри зоны touchZone
            if (RectTransformUtility.RectangleContainsScreenPoint(touchZone, touch.position))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isRotating = true;
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved && isRotating)
                {
                    float deltaX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                    float deltaY = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;

                    rotationX += deltaX;
                    rotationY = Mathf.Clamp(rotationY - deltaY, -30f, 60f);

                    // Поворот камеры, не изменяя поворот персонажа
                    cameraTransform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isRotating = false;
                }
            }
        }
    }
}
