using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    public float roataionSpeed = 1.0f;
    public GameObject bulletPrefab;
    public GameObject EnemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;

    private Rigidbody rb;
    private Transform player;

    private float NextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 0.5f)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }

            Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            EnemyPivot.transform.rotation = Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, roataionSpeed * Time.deltaTime);

            if (Time.time > NextFireTime)
            {
                NextFireTime = Time.time + 1f / fireRate;
                GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;
                temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.MONSTER;
                Destroy(temp, 10.0f);
            }
        }
        
    }
}
