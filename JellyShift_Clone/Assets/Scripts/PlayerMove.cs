using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    private Camera cam;
    public Rigidbody rb;
    public GameObject mirror,player;
    public float lerpValue;
    public float minX, maxX;
    public float minY, maxY;
    private bool isGameEnded;
    public float speed;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        cam = Camera.main;
      
    }


    void Update()
    {
        if (!isGameEnded)
        {
            Move();
        }
        if (Input.GetButton("Fire1"))
        {
            ChangeScale();
        }
    }


    public void ChangeScale()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = 10;

       Vector3 moveVec = cam.ScreenToWorldPoint(mousPos);

        float x = transform.localScale.x;
        moveVec.z = transform.localScale.z;

        moveVec.y *= 2f;
        moveVec.y = Mathf.Clamp(moveVec.y, minY, maxY);

        x = 3 / moveVec.y;

        moveVec.x = Mathf.Clamp(x, minX, maxX);

        transform.localScale = moveVec;
        MirrorScript.instance.ChangeScaleOfTheMirror(moveVec);


    }

    private void Move()
    {
        rb.velocity = Vector3.forward * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(player.transform.position, mirror.transform.position);
        
     

        
    }

}
