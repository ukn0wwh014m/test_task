using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    ContentController _contentController;

	// Use this for initialization
	void Start () {
		_contentController = Camera.main.GetComponent<ContentController> ();
	}
	
	public void ModelActivator()
	{
		//Activating item corresponding to which button was pressed
		_contentController.items [this.name].SetActive (true);

		//Loop for keeping all other 3d object non-active
		for (int i = 0; i < _contentController.items.Count; i++) {

			if (_contentController.icons [i].name == this.name)
				continue;
			
			_contentController.items [_contentController.icons [i].name].SetActive (false);
		}
	}
}
