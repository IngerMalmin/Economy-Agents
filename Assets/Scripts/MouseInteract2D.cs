  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract2D : MonoBehaviour
{

    [SerializeField] private GoldGenerator goldGenerator;

    // Update is called once per frame
    void Update()
    {
        SendRay();
    }
    private void SendRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit == true && hit.transform.tag == "Interactable")
            {
                //Debug.Log("Clicked: " + hit.transform.name);
                goldGenerator.CookieClicked();
            }
        }
    }
}
