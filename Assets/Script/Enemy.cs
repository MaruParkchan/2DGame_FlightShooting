using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int scorePoint; // 적 처치시 획득 점수 
    [SerializeField]
    private GameObject explosionEffectObject;
    private Player player;  // Player Score 정보를 접근하기 위한 선언

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 오브젝트의 태그가 Player인가?
        if(collision.transform.CompareTag("Player"))
        {
            // Player 오브젝트를 부딪혔을때 플레이어 체력 감소 
            collision.GetComponent<PlayerHp>().TakeDamage();
           
            OnDie();
        }
    }

    public void OnDie() // 적 사망시 발생할 함수
    {
        // 적 사망시 플레이어 점수 증가
        player.Score += scorePoint;
        // 적 오브젝트 파괴시 이펙트 생성
        Instantiate(explosionEffectObject, transform.position, Quaternion.identity);
        // 적 오브젝트 삭제
        Destroy(gameObject);
    }
}
