using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public GameObject objectsPlaceholder;
	Animator goAnim;

	public void OnOffAnimation()
	{
	//Searching active gameobject in ObjectsPlaceholder childs. 
	//---There 100% better way to do this. Need to be refactored!!---//
	for (int i = 0; i < objectsPlaceholder.transform.childCount; i++) {
		if (objectsPlaceholder.transform.GetChild (i).gameObject.active) 
		{
		goAnim = objectsPlaceholder.transform.GetChild (i).gameObject.GetComponent<Animator> ();
		}
	}
	//Turning On/Off active gameobject animation
		if (goAnim.isActiveAndEnabled) {
			goAnim.enabled = false;
		}else
			goAnim.enabled = true;
	}
}
