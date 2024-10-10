using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableWhen : MonoBehaviour
{
    private BoxCollider2D box;
    private List<Collision2D> collisions = new();
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (collisions.Count > 0 && box.forceReceiveLayers == -1)
        {
            box.forceReceiveLayers = 1015;
        } else if (collisions.Count == 0 && box.forceReceiveLayers == 1015)
        {
            box.forceReceiveLayers = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision);
    }
}
