using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    private void Start()
    {
        // 오브젝트 destroyTime 초뒤에 삭제
        Destroy(this.gameObject, destroyTime);
    }
}
