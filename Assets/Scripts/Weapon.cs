using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Tilt Settings")]
    [SerializeField] private float weaponMaxTiltAngle; // Максимальний кут нахилу для зброї
    [SerializeField] private float weaponTiltSpeed; // Швидкість зміни кута для зброї

    [Header("Secondary Transform Tilt Settings")]
    [SerializeField] private Transform secondaryTransform; // Інший трансформ для обертання
    [SerializeField] private float secondaryMaxTiltAngle; // Максимальний кут нахилу для другого трансформу
    [SerializeField] private float secondaryTiltSpeed; // Швидкість зміни кута для другого трансформу

    private float mouseInputX;
    private float horizontalInput;

    void Update()
    {
        // Отримуємо вхідні дані миші по осі X
        mouseInputX = Input.GetAxisRaw("Mouse X");
        // Отримуємо горизонтальний вхід (наприклад, для WASD чи стрілок)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Обчислюємо цільовий кут нахилу по осі Y для зброї
        float targetTiltY = mouseInputX * weaponMaxTiltAngle;

        // Обчислюємо цільовий кут нахилу по осі Y для другого трансформу
        float targetSecondaryTiltY = horizontalInput * -1 * secondaryMaxTiltAngle;

        // Отримуємо поточний локальний кут обертання для зброї
        Vector3 currentRotation = transform.localEulerAngles;
        if (currentRotation.y > 180f) currentRotation.y -= 360f;

        // Інтерполюємо між поточним і цільовим кутом по осі Y для зброї
        float smoothTiltY = Mathf.Lerp(currentRotation.y, targetTiltY, Time.deltaTime * weaponTiltSpeed);
        smoothTiltY = Mathf.Clamp(smoothTiltY, -weaponMaxTiltAngle, weaponMaxTiltAngle);

        // Оновлюємо локальний кут обертання зброї тільки по осі Y
        transform.localEulerAngles = new Vector3(currentRotation.x, smoothTiltY, currentRotation.z);

        // Те ж саме для іншого трансформу
        Vector3 secondaryRotation = secondaryTransform.localEulerAngles;
        if (secondaryRotation.y > 180f) secondaryRotation.y -= 360f;

        float smoothSecondaryTiltY = Mathf.Lerp(secondaryRotation.y, targetSecondaryTiltY, Time.deltaTime * secondaryTiltSpeed);
        smoothSecondaryTiltY = Mathf.Clamp(smoothSecondaryTiltY, -secondaryMaxTiltAngle, secondaryMaxTiltAngle);

        secondaryTransform.localEulerAngles = new Vector3(secondaryRotation.x, smoothSecondaryTiltY, secondaryRotation.z);
    }
}