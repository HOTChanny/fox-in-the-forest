using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환에 필요

// 충돌하면 몇초 후 씬을 전환한다
public class sceneswichbgm : MonoBehaviour
{
    public int maxCount = 50; // 빈도：Inspector에 지정
    int count = 0; // 카운터 용

    public string targetObjectName; // 목표 오브젝트 이름 : Inspector에 지정
    public string sceneName;  // 씬 이름 : Inspector에 지정

    bool setCount = false;

    void Start ()
	{ // 처음에 시행한다
        count = 0;  // 카운터를 리셋
    }


    void OnCollisionEnter2D(Collision2D collision)// 충돌했을 때
    { 
      // 만약 충돌한 것의 이름이 목표 오브젝트였다면
        if (collision.gameObject.name == targetObjectName)
        {
            soundManager.instance.PlaySoundArchieve();
            setCount = true;
            
        }
    }
    void Update()// 계속 시행한다(일정 시간마다) 
	{
        if(setCount) {
            count = count + 1;
        }
    }
    void FixedUpdate()// 계속 시행한다(일정 시간마다) 
	{
        if (count >= maxCount)
            { // 만약, maxCount가 되면
            count = 0; // 카운터를 리셋
            // 씬을 전환한다
            SceneManager.LoadScene(sceneName);
            }
    }

    /***void FixedUpdate()// 계속 시행한다(일정 시간마다) 
	{ 
        count = count + 1; // 카운터에 1을 더해서
        if (count >= maxCount) 
		{ // 만약, maxCount가 되면
            this.transform.Rotate(0, 0, 180); // 180도 회전해서 돈다
            count = 0; // 카운터를 리셋
                       // 그 때 그림이 180도 회전하므로 위 아래를 반전시킨다
            flipFlag = !flipFlag;
            this.GetComponent<SpriteRenderer>().flipY = flipFlag; 
        }
    }***/
}
