using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBulletPrefab; // �߻�ü ������
    [SerializeField]
    private float attackRate; // �߻� �ֱ�
    private AudioSource audioSource; // ���� ����� ������Ʈ

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartFiring()
    {
        StartCoroutine("Fire");
    }

    public void StopFiring()
    {
        StopCoroutine("Fire");
    }

    private IEnumerator Fire()
    {
        while(true)
        {
            Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);
            // ���� ���� ���
            audioSource.Play();
            yield return new WaitForSeconds(attackRate);
        }
    }
}
