using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stalag : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool gobHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        gobHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gobHit)
        {
            StalagManager.gobHit = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 9)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

        if(col.gameObject.layer == 6)
        {
            Destroy(this);
        }

        if(col.gameObject.layer == 7)
        {
            gobHit = true;
            Destroy(this);
        }
    }
}
