using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizonalmentmove;    // 范围： [-1， 1]    类型：float    用途：速度
    float facedirection;        // 范围： -1， 0， 1  类型：int      用途：方向
    
    public Animator player2Animator;
    AnimatorStateInfo animatorInfo;
    public Rigidbody2D rb;
    public Collider2D coll;
    public LayerMask ground;
    public float speed;        // 移动速度
    public float jumpforce;    // 跳跃力

    private string Message;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        // 可用状态
        if(Input.GetKeyDown(KeyCode.J))
        {
            /*
             * 1.站立未攻击
             * 2.攻击中...
             * 3.攻击结束...
             */
            print("J...攻击...");
            print("Idle --> Attack...");
            // 1.播放动画
            player2Animator.SetBool("isPunch", true);
            player2Animator.SetBool("idle", false);
            // 2.重置碰撞器
            //Attack_Punch.gameObject.transform.position = new Vector2(this.transform.position.x - 2.76f, transform.position.y - 1.36f);
            // 3.动画结束，攻击碰撞器设为默认位置（无限远）  -- 日期：2020年9月7日
        }
    }
    private void Movement()
    {
        // 可用状态
        horizonalmentmove = Input.GetAxis("Horizontal");    // 范围： [-1， 1]    类型：float    用途：速度
        facedirection = Input.GetAxisRaw("Horizontal");     // 范围： -1， 0， 1  类型：int      用途：方向
        if(horizonalmentmove != 0)
        {
            // 有位移
            rb.velocity = new Vector2(horizonalmentmove * speed, rb.velocity.y);

        }

        if(facedirection  != 0)
        {
            transform.localScale = new Vector2(-facedirection, 1);
        }
    }
    
    //一个控制台输出方法
    public void Log(string msg)
    {
        Debug.Log(msg);
    }

    void OnTriggerEnter(Collider e)
    {
        print("Trigger。。。");
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("碰撞发生OnTriggerEnter2D-Player");
    }
    
    //碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        Log("碰撞开始...");
        Message="进入碰撞,碰撞名称："+collision.gameObject.name;
        print(Message); 
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name.Equals("Tilemap"))
        {
            return;
        }
        Debug.Log("碰撞发生OnCollisionEnter2D-Player");
        print(coll.collider.name);
        
    }
	
    //碰撞中
    void OnCollisionStay(Collision collision)
    { 
        if(collision.gameObject.name=="Sphere")
        {
            Message="碰撞中,碰撞名称："+collision.gameObject.name;
            print(Message);
        }
    }
    
    //碰撞中
    void OnCollisionStay2D(Collision2D coll)
    { 
        if (coll.collider.name.Equals("Tilemap"))
        {
            return;
        }
        Message="碰撞中,碰撞名称："+coll.gameObject.name;
        print(Message);
    }

    public void punchToIdle()
    {
        player2Animator.SetBool("isPunch", false);
        player2Animator.SetBool("idle", true);
    }
    
    //碰撞结束
    void OnCollisionExit(Collision collision)
    { 
        if(collision.gameObject.name=="Sphere")
        {
            Message="碰撞结束,碰撞名称："+collision.gameObject.name;
            print(Message);
            //collision.gameObject.rigidbody.Sleep();
        }
    }
    
    void OnCollisionExit2D(Collision2D coll)
    { 
        if (coll.collider.name.Equals("Tilemap"))
        {
            return;
        }
        Message="碰撞结束,碰撞名称："+coll.gameObject.name;
        print(Message);
    }
}
