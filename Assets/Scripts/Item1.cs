using UnityEngine;

public class Item1 : MonoBehaviour
{
    [SerializeField] private Transform target; // ֳ������ ���������, �� ����� ������� ����������
    [SerializeField] private float rotationSpeed = 5f; // �������� ���������

    void LateUpdate()
    {
        RotateTowards();
    }

    private void RotateTowards()
    {
        // �������� �������� �� ��'���� �� ���
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // �������� ������, ��� �������� ����� �� �� Y

        // ������������ �������� �� ��� ��������
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // ������ �������� ��'��� � �������� ���
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}