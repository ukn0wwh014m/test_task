using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ContentController : MonoBehaviour {

	public GameObject buttonPrefab;
	public Transform objectPlaceholder;
	public GameObject scrollContent;

	int buttonsCount = 0;

	List<GameObject> models = new List<GameObject>();
	public List<Sprite> icons = new List<Sprite>();
	public Dictionary<string,GameObject> items;

	void Awake()
	{
		items = new Dictionary<string,GameObject> ();

		//Loading data from resources folders
		models.AddRange(Resources.LoadAll<GameObject>("Models/"));
		icons.AddRange(Resources.LoadAll<Sprite> ("Icons/"));

		buttonsCount = models.Count;

		//Instantiating 3D models prefabs from Resources/Models folder
		for (int i = 0; i < buttonsCount; i++) {
			GameObject tmp = Instantiate (models[i], objectPlaceholder.position, Quaternion.identity) as GameObject;
			tmp.SetActive (false);
			tmp.transform.SetParent (objectPlaceholder);
			items.Add (icons [i].name, tmp);
		}
	}
		
	void Start () {

		//Adding buttons to scrollable list
		for (int i = 0; i < buttonsCount; i++) {
			GameObject nwButton = CreateNewButton (icons [i]);
			nwButton.transform.localScale = new Vector3 (1, 1, 1);
		}

	}
		
	//itemPreview is icon from Resources/Icons folder.
	GameObject CreateNewButton(Sprite itemPreview)
	{
		GameObject newButton = Instantiate (buttonPrefab) as GameObject;
		newButton.transform.SetParent (scrollContent.transform);
		newButton.transform.FindChild("ObjectPreview").GetComponent<Image>().sprite = itemPreview;
		newButton.GetComponentInChildren<Text> ().text = itemPreview.name;
		newButton.name = itemPreview.name;
		return newButton;
	}
}
