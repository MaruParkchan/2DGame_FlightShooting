using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    private void Start()
    {
        // ������Ʈ destroyTime �ʵڿ� ����
        Destroy(this.gameObject, destroyTime);
    }
}
