using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    bool isJump = false;
    bool isSlide = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    Vector2 startPosition;
    Animator animator;

    public Button jumpButton; // UI 점프 버튼
    public Button slideButton;

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();

        // UI 버튼 클릭 이벤트 연결
        jumpButton.onClick.AddListener(PerformJump);
        slideButton.onClick.AddListener(PerformSlide);

        // 애니메이션 이벤트 연결
        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0];
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "OnSlideAnimationEnd";
        animationEvent.time = animationClip.length;
        animationClip.AddEvent(animationEvent);
    }

    void Update()
    {
        if (isSlide)
        {
            animator.SetBool("playerSlide", true);
            animator.SetBool("playerRun", false);
        }
        else
        {
            animator.SetBool("playerRun", true);
            animator.SetBool("playerSlide", false);
        }

        if (isJump)
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position,
                    new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }

            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }

            // 플레이어가 땅에 착지하면 점프 가능 상태로 변경
            if (transform.position.y <= startPosition.y)
            {
                isJump = false;
                isTop = false;
            }
        }
    }

    void PerformJump()
    {
        if (!isJump) // 점프 중이 아닐 때만 점프
        {
            isJump = true;
        }
    }

    void PerformSlide()
    {
        if (!isJump) // 점프 중이 아닐 때만 슬라이드 시작
        {
            isSlide = true;
        }
    }

    void OnSlideAnimationEnd()
    {
        isSlide = false;
        // 슬라이드 애니메이션 종료 후에 실행할 코드를 여기에 작성하세요
        animator.SetBool("playerSlide", false); // playerSlide 애니메이션 상태를 false로 설정
        animator.SetBool("playerRun", true); // playerRun 애니메이션 상태를 다시 true로 설정
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("충돌");
            animator.SetBool("playerRun", false);
        }
    }
}
