using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 1000f;

    public Transform playerBody;
    float xRotation = 2f;

    private Camera cam;//發射射線的攝像機
    private GameObject go;//射線碰撞的物體
    private Vector3 screenSpace;
    private Vector3 offset;

    private bool isdrage = false;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        //旋轉身體的視角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 讓頭部旋轉在90度

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray , out hit))
            {
                if(hit.collider.CompareTag ("Cube"))//方塊
	            {
                    Debug.Log("Hit Cube" );
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                    hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
	            }
                if(hit.collider.CompareTag ("Terrain"))//地板
                {
                    Debug.Log("Hit Terrain" );
                }
                else
                {
                    
                }

            }
        }
        /*if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray , out hit))
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            }
        }*/

    }
}

