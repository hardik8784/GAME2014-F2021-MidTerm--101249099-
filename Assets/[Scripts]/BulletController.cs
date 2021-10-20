/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : BulletController.cs
 * Description : This is the Bullet Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added Bullet controller Horizontally
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float horizontalSpeed;                           //Indicate Horizontal Speed
    public float verticalBoundary;
    public float horizontalBoundary;                        //Indicate the Horizontal bound
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        //transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
        transform.position += new Vector3(horizontalSpeed, 0.0f,0.0f) * Time.deltaTime;     //This will use to move Bullet Horizontally
    }

    private void _CheckBounds()
    {
        //if (transform.position.y > verticalBoundary)
        //{
        //    bulletManager.ReturnBullet(gameObject);
        //}
        if (transform.position.x > horizontalBoundary)                                      //If the Bullet goes off screen return the bullet
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
