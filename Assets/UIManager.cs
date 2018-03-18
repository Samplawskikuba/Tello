using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	bool MoveImage;

	[Tooltip("Put title here, needs to be 500x200")]
	public GameObject MovableTitle;


	[Range(1,10)]
	public float MoveSpeed;

	float timer;
	
	// Update is called once per frame
	void Update () {
		if (MoveImage) {
			MovableTitle.transform.Translate (Vector3.left * Time.deltaTime * MoveSpeed * 100f);
		}
		timer += Time.deltaTime;

		if (MovableTitle.transform.localPosition.x <= 0) {
			MoveImage = false;
		}
	}

	public void NewImage(){
		timer = 0;
		MoveImage = true;

	}
}
