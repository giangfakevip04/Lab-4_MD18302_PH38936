using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isJump = false;
    bool isRun = false;
    bool isIdle = true;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // bat su kien khi click nut space
        this.gameObject.GetComponent<Animator>().SetBool("isRun", true);
    }
}
