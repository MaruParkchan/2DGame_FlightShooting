using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 오브젝트의 태그가 Enemy인가?
        if (collision.transform.CompareTag("Enemy"))
        {
            // 적 오브젝트 사망처리
            collision.GetComponent<Enemy>().OnDie();
            // 자기 자신의 오브젝트 삭제
            Destroy(this.gameObject);
        }
    }
}
