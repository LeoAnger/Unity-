using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_kyo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞开始...kyo");
    }
    
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("碰撞发生OnTriggerEnter2D-Enemy");
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("碰撞发生OnCollisionEnter2D");
    }

}
