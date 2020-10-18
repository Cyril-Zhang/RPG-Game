using UnityEngine;
using System.Collections;
//将任何物体变成可用wasd控制的可动物体
//为了让此脚本正常运行需要：
//                1. 设置wasd上下左右4方向的animation clip，设置trigger为upMove，downMove，leftMove和rightMove
//                2. 在每个clip结束位置插入event，引用此脚本的afterMovingFinish方法
//                3. 物体object需要add Rigit2D 组件
//ctl + k   ctl+c   | ctl+k ctl+u
public class movable : MonoBehaviour
{
    private Animator animator;
    public int walkspeed;
    string dir = "left";      //0 up  1 down 2 left 3 right
    void Start()
    {

        animator = GetComponent<Animator>();

    }
    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        transform.position = transform.position + movement*walkspeed * Time.deltaTime;
        WalkControl();
        if (movement.magnitude <0.1) {
            animator.SetTrigger(dir);
        }
        
    }
    
    //public float walkSpeed=10;                   
    //private bool isDead = false;           

    //private Animator anim;                  
    //private Rigidbody2D rb2d;               
    //private bool animFinish;
    ////private float timeSinceLastSpawned;
    //Animation animation;
    //void Start()
    //{

    //    //Get reference to the Animator component attached to this GameObject.
    //    anim = GetComponent<Animator>();
    //    animation = GetComponent<Animation>();
    //    //Get and store a reference to the Rigidbody2D attached to this GameObject.
    //    rb2d = GetComponent<Rigidbody2D>();
    //    animFinish = true;

    //}

    //void Update()
    //{

    //    if (animFinish)
    //    {
    //        WalkControl();
    //    }
    //    //WalkControl();

    //    //Don't allow control if the bird has died.
    //}

    private void WalkControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dir = "up";

        }
        else if (Input.GetKey(KeyCode.A))
        {

            dir = "left";
        }
        else if (Input.GetKey(KeyCode.S))
        {

            dir = "down";
        }
        else if (Input.GetKey(KeyCode.D))
        {

            dir = "right";
        }
    }

    private void AfterMovingFinish()
    {
        //animFinish = true;
        //rb2d.velocity = new Vector2(0, 0);

    }

    //private void stopMoving()
    //{
    //    //animation.Stop();
    //    AfterMovingFinish();
    //}

    //void OnCollisionEnter2D(Collision2D other)
    //{

    //}
}

