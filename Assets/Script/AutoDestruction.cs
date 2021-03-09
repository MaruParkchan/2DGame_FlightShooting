using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private float destroyDistance = 2.0f; // 추가 거리

    private void LateUpdate()
    {
        if(transform.position.x < stageData.LimitMin.x - destroyDistance || 
           transform.position.x > stageData.LimitMax.x + destroyDistance || 
           transform.position.y < stageData.LimitMin.y - destroyDistance ||
           transform.position.y > stageData.LimitMax.y + destroyDistance)
        {
            Destroy(this.gameObject); // 범위 밖으로 나가면 오브젝트 삭제
        }
    }
}
