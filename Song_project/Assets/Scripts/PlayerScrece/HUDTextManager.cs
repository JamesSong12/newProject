using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTextManager : MonoBehaviour
{
    public Text hudText;
    public GameObject character;
    public Vector3 offset;

    public GameObject HudTextUp;
    public GameObject canvasObject;
  

    // Update is called once per frame
    void Update()
    {
        if(character != null)
        {
            Vector3 characterHeadPosition = character.transform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterHeadPosition);
            hudText.transform.position = screenPosition + offset;
        }
    }

    public void UpdateHUDTextSet(string newText, GameObject target, Vector3 TargetOffset)
    {
        Vector3 TargetPosition = target.transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(TargetPosition);
        GameObject temp = (GameObject)Instantiate(HudTextUp);
        temp.transform.SetParent(canvasObject.transform, false);
        temp.transform.position = screenPosition + TargetOffset;
        temp.GetComponent<HUDMove>().textUI.text = newText;
    }
}
