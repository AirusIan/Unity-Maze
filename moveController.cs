using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float moveSpeed = 5f;//移動速度
    public float jumpSpeed = 12.0F; //起跳距離
    public float gravity = 20.0F;  //重力
    private Vector3 moveDirection = Vector3.zero;
    CharacterController charController;
    Animator  anim;

    void Start()
    {
        charController = GetComponent<CharacterController>(); //把CharacterController綁到controller
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (charController.isGrounded) //如果在地板，才可控制
        {
            //獲得Horizontal軸 在-1到1中間浮動 A D 左右，W S 前 後
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            anim.SetBool("grounded",true);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetTrigger("Jump");
            }
            if (Input.GetKey(KeyCode.E))
            {moveSpeed = 10f;}
            /*else if(Input.GetKey(KeyCode.E))
            {moveSpeed = 0f;}*/
            else{moveSpeed = 5f;}
        }
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);
        anim.SetFloat("speed",moveSpeed);
        

    }
    private void move()
    {
        //一、向右走，
        //Time.deltaTime是指從最後一幀到當前幀的間隔
        if (Input.GetKey(KeyCode.D))
        {
            player.gameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        //二、向左走
        if (Input.GetKey(KeyCode.A))
        {
            player.gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        //向前走
        if (Input.GetKey(KeyCode.W))
        {
            player.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        //向後走
        if (Input.GetKey(KeyCode.S))
        {
            player.gameObject.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
    }
}
