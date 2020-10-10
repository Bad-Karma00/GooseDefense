using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Search(Transform _target) {

        target = _target;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
                }
        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceFrame) {

            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceFrame, Space.World);
    }

    void HitTarget() {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
