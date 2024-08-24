using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Tilt Settings")]
    [SerializeField] private float weaponMaxTiltAngle; // ������������ ��� ������ ��� ����
    [SerializeField] private float weaponTiltSpeed; // �������� ���� ���� ��� ����

    [Header("Secondary Transform Tilt Settings")]
    [SerializeField] private Transform secondaryTransform; // ����� ��������� ��� ���������
    [SerializeField] private float secondaryMaxTiltAngle; // ������������ ��� ������ ��� ������� ����������
    [SerializeField] private float secondaryTiltSpeed; // �������� ���� ���� ��� ������� ����������

    private float mouseInputX;
    private float horizontalInput;

    void Update()
    {
        // �������� ����� ��� ���� �� �� X
        mouseInputX = Input.GetAxisRaw("Mouse X");
        // �������� �������������� ���� (���������, ��� WASD �� ������)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // ���������� �������� ��� ������ �� �� Y ��� ����
        float targetTiltY = mouseInputX * weaponMaxTiltAngle;

        // ���������� �������� ��� ������ �� �� Y ��� ������� ����������
        float targetSecondaryTiltY = horizontalInput * -1 * secondaryMaxTiltAngle;

        // �������� �������� ��������� ��� ��������� ��� ����
        Vector3 currentRotation = transform.localEulerAngles;
        if (currentRotation.y > 180f) currentRotation.y -= 360f;

        // ������������ �� �������� � �������� ����� �� �� Y ��� ����
        float smoothTiltY = Mathf.Lerp(currentRotation.y, targetTiltY, Time.deltaTime * weaponTiltSpeed);
        smoothTiltY = Mathf.Clamp(smoothTiltY, -weaponMaxTiltAngle, weaponMaxTiltAngle);

        // ��������� ��������� ��� ��������� ���� ����� �� �� Y
        transform.localEulerAngles = new Vector3(currentRotation.x, smoothTiltY, currentRotation.z);

        // �� � ���� ��� ������ ����������
        Vector3 secondaryRotation = secondaryTransform.localEulerAngles;
        if (secondaryRotation.y > 180f) secondaryRotation.y -= 360f;

        float smoothSecondaryTiltY = Mathf.Lerp(secondaryRotation.y, targetSecondaryTiltY, Time.deltaTime * secondaryTiltSpeed);
        smoothSecondaryTiltY = Mathf.Clamp(smoothSecondaryTiltY, -secondaryMaxTiltAngle, secondaryMaxTiltAngle);

        secondaryTransform.localEulerAngles = new Vector3(secondaryRotation.x, smoothSecondaryTiltY, secondaryRotation.z);
    }
}