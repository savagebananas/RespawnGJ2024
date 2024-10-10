using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;

public class ChainShot : MonoBehaviour
{

    [SerializeField]
    private GameObject player2;

    public bool isShotOut = false;
    public bool isShooting = false;
    public bool hasReturned = false;
    public float speed;
    private Transform aimLocation;
    private Transform startLocation;
    private float distance;

    // Start is called before the first frame update
    void OnEnable()
    {
        isShotOut = true;
        isShooting = true;
    }
    void Start()
    {
        aimLocation = player2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, aimLocation.position);

        if(distance > 0.1f)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, aimLocation.position, speed * Time.deltaTime);
        }

        if(distance <= 0.1f && !isShooting)
        {
            if(player2.transform.parent == this.gameObject)
            {
                player2.transform.parent = null;
            }
            isShotOut = false;
            hasReturned = true;
            this.enabled = false;
        }
        
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if hit plaayer disable movement and child the player to the hook
        if(col.GetComponent<Player2Movement>() != null)
        {
            Rigidbody2D p2rb = col.GetComponent<Rigidbody2D>();
            p2rb.constraints = RigidbodyConstraints2D.FreezeAll;

            col.transform.SetParent(this.gameObject.transform);
        }

        //once hit anything pull back
        aimLocation = startLocation;
        isShooting = false;
    }
}
