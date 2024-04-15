using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower TowerPrefab;
    [SerializeField] bool IsPlaceable;

public bool isPlaceable { get { return IsPlaceable; } }
   void OnMouseDown()
   {
        if(IsPlaceable)
        {
            bool isPlaced = TowerPrefab.CreateTower(TowerPrefab, transform.position);
            IsPlaceable=!isPlaced;
        }
   }
}
