using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private float scrollRange = 0;
    [SerializeField]
    private float moveSpeed = 0;

    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        if(transform.position.y <= -scrollRange) // 설정된 범위 벗어나면 위치 재설정
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
