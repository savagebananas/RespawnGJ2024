using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public float RemainTime=0.5f;
    private float remain;
    public bool parent = true;
    public bool infinite=false;
    public GameObject ParSys;
    void Start()
    {
        remain = RemainTime;
    }

    public void MakeParticle(float offsetx, float offsety, float remainTime)
    {
        Vector2 pos=transform.position+new Vector3(offsetx, offsety);
        GameObject clone=Instantiate(ParSys,pos,Quaternion.identity);
        if (clone != null)
        {
            clone.GetComponent<ParticleManager>().parent = false;
            clone.GetComponent<ParticleManager>().RemainTime = remainTime;
            if (remainTime > 10000)
                clone.GetComponent<ParticleManager>().infinite = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!parent)
        {
            remain -= Time.deltaTime;
            if ((remain < 0) && (!infinite)) Destroy(gameObject);
        }
    }
}
