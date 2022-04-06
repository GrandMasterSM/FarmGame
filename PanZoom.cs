using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
private Camera cam;

private bool moveAllowed;
private Vector3 touchPos;

private void Awake()
{
	cam = GetComponent<Camera>();
}

private Void Update()
{
	if (Input.touchCount > 0)
	{
		if (Input.touchCount == 2)
		{
			
		}
		else
		{
			Touch touch = Input.GetTouch(0);
			
			switch (touch.phase)
			{
				case TouchPhase.Began:
				    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
				    {
					    moveAllowed = false;
				    }
				    else
				    {
					    moveAllowed = true;
				    }
				
				    touchPos = cam.ScreenToWorldPoint(touch.position);
				    break;
				case TouchPhase.Moved:
				    if (moveAllowed)
				    {
					    Vector3 direction = touchPos - cam.ScreenToWorldPoint(touch.position);
					    cam.transform.position += direction;
				    }
				    break;
			    }
		    }
	   }
    }
}
		
