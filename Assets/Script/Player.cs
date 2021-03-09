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

        animator.SetInteger("Move", (int)x); // x�� ������ �¿� �Ǵ�
    }

    private void FireInput() // �����ϴ� �޼ҵ�
    {
        if(Input.GetKeyDown(keyCodeAttack)) // Ű�� ������ �߻�
        {
            playerWeapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack)) //Ű�� ���� �߻� ����
        {
            playerWeapon.StopFiring();
        }
    }

    private void LimitPosition() // ȭ�� ���� ������ ������ ���ϰ� ����
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                        (Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y)));
    }

    public void OnDie()
    {
        //  ����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        // �÷��̾� ��� �� nextSceneName �� �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}
