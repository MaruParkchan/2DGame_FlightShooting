using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� ������Ʈ�� �±װ� Enemy�ΰ�?
        if (collision.transform.CompareTag("Enemy"))
        {
            // �� ������Ʈ ���ó��
            collision.GetComponent<Enemy>().OnDie();
            // �ڱ� �ڽ��� ������Ʈ ����
            Destroy(this.gameObject);
        }
    }
}
