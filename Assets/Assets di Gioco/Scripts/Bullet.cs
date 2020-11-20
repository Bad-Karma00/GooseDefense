using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public float explosionRadius = 0f;
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
        transform.LookAt(target);
    }

    void HitTarget() {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
            FindObjectOfType<MusicScript>().Play("Explosion");

        }
        else {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Explode() {

       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
