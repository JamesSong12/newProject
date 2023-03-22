using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSystem : MonoBehaviour
{
    private Vector2 iuitialPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) iuitialPos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) Calculate(Input.mousePosition);
    }

    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(iuitialPos.x - finalPos.x);
        float disY = Mathf.Abs(iuitialPos.x - finalPos.y);

        if(disX > 0 || disY > 0)
        {
            if(disX > disY)
            {
                if (iuitialPos.x > finalPos.x) Debug.Log("Left");
                else Debug.Log("Right");
            }
            else
            {
                if (iuitialPos.y > finalPos.y) Debug.Log("Down");
                else Debug.Log("Up");
            }
        }
    }
}
