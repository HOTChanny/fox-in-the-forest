using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
