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
    public bool IsDie => isDie; // 외부에 공유하기 위한 프로퍼티 선언
    private bool isInvincibility; // 무적 
    private float isInvincibilityTime = 2.0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    public void TakeDamage()
    {
        if(isInvincibility) // 무적 활성화면 데미지 안받기
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
        // 체력이 감소되면 PlayerHpImage 사라지기
        playerHpImages[hp].enabled = false;           
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator Invincibility() // 무적
    {
        StartCoroutine("TwinkleLoop");
        isInvincibility = true; // 무적 활성화
        yield return new WaitForSeconds(isInvincibilityTime); // 무적 시간 대기
        StopCoroutine("TwinkleLoop");
        isInvincibility = false; // 무적 비활성화
        spriteRenderer.color = Color.white; // 알파값 원상 복귀
    }

    private IEnumerator TwinkleLoop()
    {
        while(true)
        {
            // Fade Out 알파값 1 -> 0
            yield return StartCoroutine(FadeEffect(1, 0));
            // Fade In  알파값 0 -> 1
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }

    // 플레이어가 무적시 깜빡이게 하는 효과 
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
