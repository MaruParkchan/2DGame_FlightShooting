using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int scorePoint; // �� óġ�� ȹ�� ���� 
    [SerializeField]
    private GameObject explosionEffectObject;
    private Player player;  // Player Score ������ �����ϱ� ���� ����

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� ������Ʈ�� �±װ� Player�ΰ�?
        if(collision.transform.CompareTag("Player"))
        {
            // Player ������Ʈ�� �ε������� �÷��̾� ü�� ���� 
            collision.GetComponent<PlayerHp>().TakeDamage();
           
            OnDie();
        }
    }

    public void OnDie() // �� ����� �߻��� �Լ�
    {
        // �� ����� �÷��̾� ���� ����
        player.Score += scorePoint;
        // �� ������Ʈ �ı��� ����Ʈ ����
        Instantiate(explosionEffectObject, transform.position, Quaternion.identity);
        // �� ������Ʈ ����
        Destroy(gameObject);
    }
}
