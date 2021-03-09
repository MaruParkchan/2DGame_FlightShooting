using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0; // �̵� �ӵ�
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero; // �̵� ����

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
}
