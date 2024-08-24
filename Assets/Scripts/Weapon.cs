using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float maxTiltAngle = 10f; // ������������ ��� ������
    [SerializeField] private float tiltSpeed = 5f; // �������� ���� ����

    private float mouseInputX;

    void Update()
    {
        // �������� ����� ��� ���� �� �� X
        mouseInputX = Input.GetAxis("Mouse X");

        // ���������� �������� ��� ������ �� �� Y
        float targetTiltY = mouseInputX * maxTiltAngle;

        // �������� �������� ��������� ��� ���������
        Vector3 currentRotation = transform.localEulerAngles;

        // ������������ �������� ��� Y � ������� �� -180 �� 180 �������
        if (currentRotation.y > 180f) currentRotation.y -= 360f;

        // ������������ �� �������� � �������� ����� �� �� Y
        float smoothTiltY = Mathf.Lerp(currentRotation.y, targetTiltY, Time.deltaTime * tiltSpeed);

        // �������� ��� ������ � ����� [-maxTiltAngle, maxTiltAngle]
        smoothTiltY = Mathf.Clamp(smoothTiltY, -maxTiltAngle, maxTiltAngle);

        // ��������� ��������� ��� ��������� ���� ����� �� �� Y
        transform.localEulerAngles = new Vector3(currentRotation.x, smoothTiltY, currentRotation.z);
    }
}
