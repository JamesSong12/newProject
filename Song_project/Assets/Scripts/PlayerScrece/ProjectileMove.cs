using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{     public enum PROJECTILETYPE
    {
        PLAYER,
        MONSTER
    }
    public Vector3 launchDirection;

    public PROJECTILETYPE projectileType;


    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;
        transform.Translate(launchDirection * moveAmount);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") && projectileType == PROJECTILETYPE.PLAYER)
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Monster>().Damaged(1);
            GameObject Temp = GameObject.FindGameObjectWithTag("GameManager");
            Temp.GetComponent<HUDTextManager>().UpdateHUDTextSet("1", other.gameObject, new Vector3(0.0f, 10.0f, 0.0f));
          
        }
        if (other.CompareTag("Player") && projectileType == PROJECTILETYPE.MONSTER)
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerHp>().Damaged(1);
            GameObject Temp = GameObject.FindGameObjectWithTag("GameManager");
            Temp.GetComponent<HUDTextManager>().UpdateHUDTextSet("1", other.gameObject, new Vector3(0.0f, 10.0f, 0.0f));

        }
    }
}
