using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject temp;
    public int Hp = 5;
    public void Damaged(int Damage)
    {
        Hp -= Damage;
        GameObject temp = this.gameObject;
        if(Hp <= 0)
        {
            
            Destroy(this.temp);
        }
    }
}
