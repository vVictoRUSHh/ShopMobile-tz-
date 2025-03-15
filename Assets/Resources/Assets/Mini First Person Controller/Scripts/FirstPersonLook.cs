using System;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    [SerializeField] private float rotationSpeed;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    public RectTransform touchZone;
    private Vector2 touchStartPos;
    Vector2 velocity;
    Vector2 frameVelocity;
    private bool isRotating;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    private void Start()
    {
        touchZone = GameObject.FindGameObjectWithTag("TouchArea").GetComponent<RectTransform>();
    }

    void Update()
    {
        // // Get smooth velocity.
        // Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        // frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        // velocity += frameVelocity;
        // velocity.y = Mathf.Clamp(velocity.y, -90, 90);
        //
        // // Rotate camera up-down and controller left-right from velocity.
        // transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        // character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        HandleCameraRotation();
    }
    void HandleCameraRotation()
    {
        // Проверяем, есть ли хотя бы одно касание
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
                    // Получаем разницу в позициях (аналогично mouseDelta)
                    Vector2 touchDelta = touch.deltaPosition;

                    // Применяем чувствительность и сглаживание
                    Vector2 rawFrameVelocity = touchDelta * rotationSpeed * Time.deltaTime;
                    frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
                    velocity += frameVelocity;
                    velocity.y = Mathf.Clamp(velocity.y, -90f, 90f);

                    // Поворот камеры вверх-вниз и персонажа влево-вправо
                    transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
                    character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isRotating = false;
                }
            }
        }
    }

}
