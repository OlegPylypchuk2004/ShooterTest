using UnityEngine;

public class Item1 : MonoBehaviour
{
    [SerializeField] private Transform target; // Цільовий трансформ, до якого потрібно обертатися
    [SerializeField] private float rotationSpeed = 5f; // Швидкість обертання

    void LateUpdate()
    {
        RotateTowards();
    }

    private void RotateTowards()
    {
        // Отримуємо напрямок від об'єкта до цілі
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Ігноруємо висоту, щоб обертати тільки по осі Y

        // Перетворюємо напрямок на кут повороту
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Плавно обертаємо об'єкт в напрямку цілі
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}