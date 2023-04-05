using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 IaunchDirection;
    public GameObject Projectile;
   public void FireProjectile()
   {
      
        GameObject temp = (GameObject)Instantiate(Projectile);

        temp.transform.position = this.gameObject.transform.position;
        temp.transform.localScale = Vector3.one * 0.3f;
        temp.GetComponent<ProjectileMove>().IaunchDirection = transform.forward;

        Destroy(temp, 10.0f);
   }
}
