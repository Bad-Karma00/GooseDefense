using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";

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
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
