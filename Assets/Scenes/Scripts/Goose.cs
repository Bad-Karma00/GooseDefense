using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform rotate;
    public float turnSpeed= 10f;

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
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 diretions = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(diretions);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation,lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
