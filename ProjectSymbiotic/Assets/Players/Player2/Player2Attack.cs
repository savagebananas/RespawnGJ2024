using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Attack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public bool isReadyToAttack = true;

    private float timeBetweenSpecial;
    public float startTimeBetweenSpecial;
    public bool isReadyToSpecial = true;
    public float buildTime;
    public GameObject rockShield;

    public Transform attackPos;
    public float attackRange;
    public LayerMask damageableLayer;
    public int damage;

    public GameObject projectile;
    public int projectileSpeed;

    public SeesawHingeScript seesaw;
    private Player2Movement player2Movement;

    public static int numWalls;

    void Start()
    {
        player2Movement = GetComponent<Player2Movement>();
        numWalls = 0;
    }

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            timeBetweenAttack = startTimeBetweenAttack;
            isReadyToAttack = true;
        }

        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }

        if (timeBetweenSpecial <= 0)
        {
            timeBetweenSpecial = startTimeBetweenSpecial;
            isReadyToSpecial = true;
        }

        else
        {
            timeBetweenSpecial -= Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && isReadyToAttack)
        {
            Debug.Log("Shoot");
            isReadyToAttack = false;
            GameObject bullet = Instantiate(projectile, attackPos.position, Quaternion.identity) as GameObject;
            Rigidbody2D projectileRB = bullet.GetComponent<Rigidbody2D>();
            
            if(gameObject.transform.localScale.x == 1)
            {
                projectileRB.AddForce(new Vector2(projectileSpeed, 0));
            }
            else
            {
                projectileRB.AddForce(new Vector2(projectileSpeed * -1, 0));
            }            
        }
    }

    public void SpecialAttack(InputAction.CallbackContext context)
    {
        if(isReadyToSpecial && player2Movement.IsGrounded() && numWalls <3)
        {
            Debug.Log("Special Start");
            isReadyToSpecial = false;

            GameObject rockWall = Instantiate(rockShield, attackPos.position, Quaternion.identity) as GameObject;
            //rockWall.transform.rotation = seesaw.GetAngle();
            rockWall.transform.parent = seesaw.gameObject.transform;
            numWalls +=1;
        }
    }

    IEnumerator Build()
    {
        this.GetComponent<Player2Movement>().canBeHurt = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(buildTime);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Player2Movement>().canBeHurt = true;
    }
}
