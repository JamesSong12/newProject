using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    public int hp = 180;
    public Text textHpUI;              // HP UI 표시 선언
    public Text textStateUI;           // State 표시 선언



    // Update is called once per frame
    void Update()
    {
        // =======================================================
        // UI 변하게하는 원동력
        // =======================================================

        if (Input.GetMouseButtonDown(0)) // 왼쪽 버튼 마우스
        {
            hp += 10;
        }
        if (Input.GetMouseButtonDown(1)) // 오른쪽 버튼 마우스
        {
            hp -= 10;
        }

        // =======================================================
        // UI 움직임
        // =======================================================

        textHpUI.text = hp.ToString();

        if (hp <= 50)
        {
            textStateUI.text = "Run!!";
        }
        else if (hp >= 200)
        {
            textStateUI.text = "Attack";
        }
        else
        {
            textStateUI.text = "Defance!!";
        }
       

    }
}
