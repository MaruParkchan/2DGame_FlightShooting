using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBulletPrefab; // 발사체 프리팹
    [SerializeField]
    private float attackRate; // 발사 주기
    private AudioSource audioSource; // 사운드 재생할 컴포넌트

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
            // 공격 사운드 재생
            audioSource.Play();
            yield return new WaitForSeconds(attackRate);
        }
    }
}
