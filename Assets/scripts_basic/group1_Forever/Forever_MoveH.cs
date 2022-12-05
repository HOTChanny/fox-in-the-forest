using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 계속, 이동한다(수평)
public class Forever_MoveH : MonoBehaviour
{

    public float speed = 1; // 속도 : Inspector에 지정

    Rigidbody2D rbody;

    void FixedUpdate()  // 계속 시행한다(일정 시간마다)
    { 
        this.transform.Translate(speed/50, 0, 0); // 수평 이동한다
    }

    void OnCollisionEnter2D(Collision2D collision)// 충돌했을 때
    { 
        speed = -speed; // 나아가는 방향을 반전한다
                        // 나아가는 방향에서 왼쪽 오른쪽의 방향을 바꾼다
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0);
    }

}
