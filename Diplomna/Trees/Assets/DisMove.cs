using UnityEngine;
using System.Collections;

enum AxisDirection {
	x, y
}

[RequireComponent (typeof (SliderJoint2D))]
public class DisMove : MonoBehaviour {
	[SerializeField] AxisDirection lockAxis;
	[SerializeField] AxisDirection lockAxisTwo; 
	
	void Awake () {
		SliderJoint2D slider = GetComponent<SliderJoint2D>();
		
		slider.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
		slider.collideConnected = true;
		
		if ((lockAxis == AxisDirection.x) && (lockAxis == AxisDirection.y)) {
			slider.angle = 90;
		} else {
			slider.angle = 0;
		}
	/*	if (lockAxisTwo == AxisDirection.y) {
			slider.angle = 90;		
		} else {
			slider.angle = 0;				
		} */
	}
}
