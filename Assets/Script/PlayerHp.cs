using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private Image[] playerHpImages;
    private SpriteRenderer spriteRenderer;
    private Player player;

    private int hp = 3;
    private bool isDie;
    public bool IsDie => isDie; // �ܺο� �����ϱ� ���� ������Ƽ ����
    private bool isInvincibility; // ���� 
    private float isInvincibilityTime = 2.0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    public void TakeDamage()
    {
        if(isInvincibility) // ���� Ȱ��ȭ�� ������ �ȹޱ�
        {
            return;
        }    

        hp--;

        if(hp < 0)
        {
            player.OnDie();
            return;
        }

        StartCoroutine("Invincibility");
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        // ü���� ���ҵǸ� PlayerHpImage �������
        playerHpImages[hp].enabled = false;           
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator Invincibility() // ����
    {
        StartCoroutine("TwinkleLoop");
        isInvincibility = true; // ���� Ȱ��ȭ
        yield return new WaitForSeconds(isInvincibilityTime); // ���� �ð� ���
        StopCoroutine("TwinkleLoop");
        isInvincibility = false; // ���� ��Ȱ��ȭ
        spriteRenderer.color = Color.white; // ���İ� ���� ����
    }

    private IEnumerator TwinkleLoop()
    {
        while(true)
        {
            // Fade Out ���İ� 1 -> 0
            yield return StartCoroutine(FadeEffect(1, 0));
            // Fade In  ���İ� 0 -> 1
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }

    // �÷��̾ ������ �����̰� �ϴ� ȿ�� 
    private IEnumerator FadeEffect(float start, float end) 
    {
        float currentTime = 0;
        float percent = 0;
        float fadeTime = 0.2f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            spriteRenderer.color = color;

            yield return null;
        }
    }
}
