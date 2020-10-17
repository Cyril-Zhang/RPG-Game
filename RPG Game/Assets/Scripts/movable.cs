using UnityEngine;
using System.Collections;
//将任何物体变成可用wasd控制的可动物体
//为了让此脚本正常运行需要：
//                1. 设置wasd上下左右4方向的animation clip，设置trigger为upMove，downMove，leftMove和rightMove
//                2. 在每个clip结束位置插入event，引用此脚本的afterMovingFinish方法
//                3. 物体object需要add Rigit2D 组件
public class movable : MonoBehaviour
{
    public float walkSpeed=3;                   
    private bool isDead = false;

    private float moving_x;
    private float moving_y;
    private bool attemp_move = true;
    private float attemp_x = 9;
    private float attemp_y = 9;

    private Animator anim;                  
    private Rigidbody2D rb2d;               
    private bool animFinish;
    //private float timeSinceLastSpawned;
    Animation animation;
    void Start()
    {

        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        animFinish = true;
        
    }

    void Update()
    {

        if (animFinish)
        {
            WalkControl();
        }
        //WalkControl();
        
        //Don't allow control if the bird has died.
    }

    private void WalkControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //animation.Stop();
            //animation.Play("upMove");
            moving_y = 1;
            moving_x = 0;
            if (attemp_moving(moving_x, moving_y))
            {
                anim.SetTrigger("upMove");
                animFinish = false;
                rb2d.velocity = new Vector2(0, walkSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moving_x = -1;
            moving_y = 0;
            if (attemp_moving(moving_x, moving_y))
            {
                anim.SetTrigger("leftMove");
                //yield return new WaitForSecondsRealtime(1);
                animFinish = false;
                rb2d.velocity = new Vector2(-walkSpeed, 0);

                //rb2d.AddForce(new Vector2(-walkSpeed, 0));
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moving_y = -1;
            moving_x = 0;
            if (attemp_moving(moving_x, moving_y))
            {
                anim.SetTrigger("downMove");
                animFinish = false;
                //yield return new WaitForSecondsRealtime(1);            
                rb2d.velocity = new Vector2(0, -walkSpeed);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving_x = 1;
            moving_y = 0;
            if (attemp_moving(moving_x, moving_y))
            {
                anim.SetTrigger("rightMove");
                animFinish = false;
                //yield return new WaitForSecondsRealtime(1);
                rb2d.velocity = new Vector2(walkSpeed, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
    }

    private bool attemp_moving(float x, float y)
    {
        if (attemp_move)
        {
            return true;
        }
        else
        {
            if(x == attemp_x && y == attemp_y)
            {
                return false;
            }
            else
            {
                attemp_move = true;
                attemp_x = 9;
                attemp_y = 9;
                return true;
            }
            
        }
    }

    private void AfterMovingFinish()
    {
        animFinish = true;
        rb2d.velocity = new Vector2(0, 0);
        
    }

    private void stopMoving()
    {
        //animation.Stop();
        AfterMovingFinish();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obstacle_non" || collision.tag == "obstacle_cy")
        {
            attemp_move = false;
            attemp_x = moving_x;
            attemp_y = moving_y;
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}

