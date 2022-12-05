using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌하면 카운터를 증가하고 자신을 지운다 
// n번 맞을 시 n초 후 죽는 사운드 
public class mushroomkill : MonoBehaviour
{
    public int lastCount = 2;
    public string targetObjectName; // 목표 오브젝트 이름 : Inspector에 지정
    public int addValue = 1;    // 증가량：Inspector에 지정
    int count;

    //public AudioClip audioKill;

    /***void Awake
    {
        this.audioSource = GetComponent<AudioSource>();
    }*///


    void Start()
	{
        count = 0;
        // 처음에는 아무 것도 하지 않는다 
	}

    /***void PlaySound(String action)
    {
        switch (action) {
            case "KILL":
            audioSource.clip = audiokill;
            break;
        }
        audioSource.Play();
    }***/

    void OnCollisionEnter2D(Collision2D collision) // 충돌했을 때
    { 
        // 만약 충돌한 것의 이름이 목표 오브젝트면 
        if (collision.gameObject.name == targetObjectName)
        {
            // 카운터 값을 증가한다 
            count += 1;

            if (count >= lastCount)
		{
            //PlaySound("KILL");
			// 지우는 오브젝트를 찾아서 
			//GameObject hideObject = GameObject.Find(hideObjectName);
			//hideObject.SetActive(false); // 지운다
            Destroy(this.gameObject);
		}
        }
        
    }
}
