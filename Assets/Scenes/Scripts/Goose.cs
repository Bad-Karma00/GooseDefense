using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Generali")]
    public float fireRate = 1f;
    [Header("Bullet Goose")]
    private float fireCountdown = 0f;
    public float range = 15f;
    public GameObject bulletPrefab;

    [Header("Laser Goose")]
    public bool useLaser= false;
    public int damageOverTime = 30;
    public float slow = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;


    [Header("Setup")]
    public string enemyTag = "Enemy";
    public Transform rotate;
    public float turnSpeed= 10f;

    public Transform firePoint;
   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortest = Mathf.Infinity;
        GameObject near = null;
        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortest) {
                shortest= distance;
                near = enemy;
            }

        }
        if (near != null && shortest <= range) {
            target = near.transform;
            targetEnemy = near.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser) {
                if (lineRenderer.enabled) {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }


    void Shoot() {
        GameObject bulletGO= (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null) {
            bullet.Search(target);
        }

    
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slow);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void LockOnTarget() {
        Vector3 diretions = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(diretions);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

  
}
