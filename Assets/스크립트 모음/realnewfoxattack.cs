using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 애니메이션을 전환한다 
public class realnewfoxattack : MonoBehaviour
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

    public GameObject newPrefab1; // 만드는 프리팹：Inspector에 지정
    public GameObject newPrefab2; // 만드는 프리팹：Inspector에 지정

	public string inkey = "space";
	public float offsetX1 = 1;
    public float offsetX2 = 1;
	public float offsetY = 1;

	bool pushFlag = false;
    bool isRight = true;
    GameObject newGameObject;

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
        else if (Input.GetKey("down"))// 점프 
        { 
            nowMode = fall;
        }
        else if (Input.GetKey("x")&&Input.GetKey("right"))// 달리기
        { 
            nowMode = run;
            isRight = true;
		}
        
        else if (Input.GetKey("x")&&Input.GetKey("left"))// 달리기
        { 
            nowMode = run;
            isRight = false;
        }
        else if (Input.GetKey("right"))// 오른쪽 키면
        { 
            nowMode = rightAnime;
            isRight = true;
        }
        else if (Input.GetKey("left"))// 왼쪽 키면
        { 
            nowMode = leftAnime;
            isRight = false;
        }
        else if (Input.GetKey("z"))// 어택
        { 
            nowMode = attack;
        }
        else { //아무 키도 누르지 않으면
            nowMode = iddle;
        }
        if(Input.GetKey(inkey))// 만약 키가 눌리면 
		{ 
			if (pushFlag == false)
			{
				pushFlag = true;
				Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
				Vector3 newPos = this.transform.position;

                newPos.x = newPos.x;
                newPos.y += offsetY;
				newPos.z = -5; // 앞 쪽에 표시 

                if (isRight){
                    newPos.x += offsetX1;
                    newGameObject = Instantiate(newPrefab1) as GameObject;
                }else if (!isRight){
                    newPos.x += offsetX2;
                    newGameObject = Instantiate(newPrefab2) as GameObject;
                }

				
				// 프리팹을 만든다 
                
				
				newGameObject.transform.position = newPos;
			}
		} else
		{
			pushFlag = false;
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
