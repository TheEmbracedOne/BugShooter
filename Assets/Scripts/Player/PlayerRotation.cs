using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    void Update () {
        if(Time.timeScale > 0.0f)
        {
            Vector3 object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 mouse_pos = Input.mousePosition;

            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;

            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
