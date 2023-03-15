using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float gravity = 0.5F;  //重力
    CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>(); //把CharacterController綁到controller
    }
    

    // Update is called once per frame
    void Update()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);

    }
}
