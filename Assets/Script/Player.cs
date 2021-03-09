using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    private Movement movement;
    private Animator animator;
    private PlayerWeapon playerWeapon;

    private int score = 0;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    private void Start()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        playerWeapon = GetComponent<PlayerWeapon>();
    }

    private void Update()
    {
        MoveInput();
        FireInput();
    }

    private void LateUpdate()
    {
        LimitPosition();
    }

    private void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.MoveTo(new Vector3(x, y, 0));

        animator.SetInteger("Move", (int)x); // x의 값으로 좌우 판단
    }

    private void FireInput() // 공격하는 메소드
    {
        if(Input.GetKeyDown(keyCodeAttack)) // 키를 누르면 발사
        {
            playerWeapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack)) //키를 떼면 발사 중지
        {
            playerWeapon.StopFiring();
        }
    }

    private void LimitPosition() // 화면 범위 밖으로 나가지 못하게 설정
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                        (Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y)));
    }

    public void OnDie()
    {
        //  디바이스에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        // 플레이어 사망 시 nextSceneName 씬 이동
        SceneManager.LoadScene(nextSceneName);
    }
}
