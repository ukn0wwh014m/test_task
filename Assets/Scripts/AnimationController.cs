using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public GameObject objectsPlaceholder;
	Animator goAnim;

	public void OnOffAnimation()
	{
		
	for (int i = 0; i < objectsPlaceholder.transform.childCount; i++) {
		if (objectsPlaceholder.transform.GetChild (i).gameObject.active) 
		{
		goAnim = objectsPlaceholder.transform.GetChild (i).gameObject.GetComponent<Animator> ();
		}
	}
	
		if (goAnim.isActiveAndEnabled) {
			goAnim.enabled = false;
		}else
			goAnim.enabled = true;
	}
}
