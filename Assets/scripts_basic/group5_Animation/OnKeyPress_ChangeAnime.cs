using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 애니메이션을 전환한다 
public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    public string iddle = "";
    public string jump = "";
    public string fall = "";
    public string run = "";
    public string attack = "";

    public string rightAnime = "";  // 오른쪽 방향：Inspector에 지정
    public string leftAnime = "";   // 왼쪽 방향：Inspector에 지정

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    string nowMode = "";
    string oldMode = "";

    void Start()// 처음에 시행한다 
    { 
        nowMode = iddle;
        oldMode = "";

        rb = GetComponent<Rigidbody2D>();
        sp=GetComponent<SpriteRenderer>();
    }

    void Update()// 계속 시행한다 
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey("space"))// 점프 
        { 
            nowMode = jump;
        }
        else if (Input.GetKey("x")&&Input.GetKey("right"))// 달리기
        { 
            nowMode = run;
		}
        
        else if (Input.GetKey("x")&&Input.GetKey("left"))// 달리기
        { 
            nowMode = run;
        }
        else if (Input.GetKey("right"))// 오른쪽 키면
        { 
            nowMode = rightAnime;
        }
        else if (Input.GetKey("left"))// 왼쪽 키면
        { 
            nowMode = leftAnime;
        }
        else if (Input.GetKey("z"))// 어택
        { 
            nowMode = attack;
        }
        else { //아무 키도 누르지 않으면
            nowMode = iddle;
        }
    }

    void FixedUpdate() // 계속 시행한다(일정 시간마다)
    { 
        // 만약 다른 키가 눌리면 
        if (nowMode != oldMode)
        {
            oldMode = nowMode;
            // 애니메이션을 전환한다 
            Animator animator = this.GetComponent<Animator>();
            animator.Play(nowMode);
        }
    }
}
