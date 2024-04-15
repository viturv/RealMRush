using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateDisplayer : MonoBehaviour
{
    TextMeshPro label;
    WayPoint waypoint;
    [SerializeField] Color Defaultcolor = Color.blue;
    [SerializeField] Color blockedcolor = Color.red;

    Vector2Int coordinates = new Vector2Int() ;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<WayPoint>();
        label.enabled= false;
        Coordinatedisplay();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            Coordinatedisplay();
            UpdateObjectName();  
                  
        }

        SetCooprdinateColor();
        LabelTogller();
    }


    void LabelTogller()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    void SetCooprdinateColor()
    {
        if(waypoint.isPlaceable)
        {
            label.color=Defaultcolor;
        }else
        {
            label.color = blockedcolor;
        }
    }

    void Coordinatedisplay()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 5);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 5);
        label.text = coordinates.x + "," + coordinates.y;
        
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

