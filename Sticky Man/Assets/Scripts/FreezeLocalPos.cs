using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLocalPos : MonoBehaviour
{
    [SerializeField] Transform tr;
    float restrictionX;
    float restrictionY;
    Vector2 restriction;
    
    
    private void Start() 
    {
        restrictionX = tr.localPosition.x;
        restrictionY = tr.localPosition.y;

        restriction = new Vector2(restrictionX, restrictionY);
    }

    private void LateUpdate() 
    {
        //tr.localPosition = restriction;
    }


}
