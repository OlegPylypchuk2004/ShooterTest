using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float maxTiltAngle = 10f; // Максимальний кут нахилу
    [SerializeField] private float tiltSpeed = 5f; // Швидкість зміни кута

    private float mouseInputX;

    void Update()
    {
        // Отримуємо вхідні дані миші по осі X
        mouseInputX = Input.GetAxis("Mouse X");

        // Обчислюємо цільовий кут нахилу по осі Y
        float targetTiltY = mouseInputX * maxTiltAngle;

        // Отримуємо поточний локальний кут обертання
        Vector3 currentRotation = transform.localEulerAngles;

        // Перетворюємо поточний кут Y в діапазон від -180 до 180 градусів
        if (currentRotation.y > 180f) currentRotation.y -= 360f;

        // Інтерполюємо між поточним і цільовим кутом по осі Y
        float smoothTiltY = Mathf.Lerp(currentRotation.y, targetTiltY, Time.deltaTime * tiltSpeed);

        // Обмежуємо кут нахилу в межах [-maxTiltAngle, maxTiltAngle]
        smoothTiltY = Mathf.Clamp(smoothTiltY, -maxTiltAngle, maxTiltAngle);

        // Оновлюємо локальний кут обертання зброї тільки по осі Y
        transform.localEulerAngles = new Vector3(currentRotation.x, smoothTiltY, currentRotation.z);
    }
}
