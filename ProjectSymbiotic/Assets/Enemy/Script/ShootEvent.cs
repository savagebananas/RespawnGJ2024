using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static UnityEngine.UI.Image;

public class ShootEvent : MonoBehaviour
{
    public int n = 1;
    [SerializeField] GameObject[] Cases=new GameObject[2];
    [SerializeField] float[] Possibility = new float[2];
    private Vector3 position;
    public float Force=5;
    public bool FacingRight = true;
    // Start is called before the first frame update
    public void Shoot()
    {
        float rnb=UnityEngine.Random.Range(0, 100);
        float acc = 0;
        bool shot = false;
        for (int i = 0; i < n; i++)
        {
            if (rnb < acc + Possibility[i])
            {
                ShootProj(i);
                shot = true;
            }
            acc+= Possibility[i];
        }
        if (!shot)
        {
            ShootProj(n - 1);
        }
        //Shoot a projectile selecting from below
    }

    private void ShootProj(int i)
    {
        GameObject ShootOut = Cases[i];
        position=transform.position;
        float velocity = Force / ShootOut.GetComponent<Rigidbody2D>().mass;
        GameObject p1 = GameObject.Find("Player");
        GameObject p2 = GameObject.Find("Player 2");
        GameObject clone = Instantiate(ShootOut, position, Quaternion.identity);
        Rigidbody2D rigidbody2D = clone.GetComponent<Rigidbody2D>();
        float vx, vy;
        vx = velocity;
        vy = 0;
        rigidbody2D.velocity = new Vector2(vx,vy);
    }
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
