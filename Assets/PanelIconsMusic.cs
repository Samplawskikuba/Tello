using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PanelIconsMusic : MonoBehaviour {

	public GameObject mainAudio;
	public AudioClip[] clips;
	public Button[] musicIcons; 
	void Start()
	{
		musicIcons = gameObject.GetComponentsInChildren<Button>();

		for (int i = 1; i < musicIcons.Length - 1; i += 2) {
			musicIcons [i].gameObject.SetActive (false);
		}
		gameObject.SetActive (false);
	}
	public void ButtonClicked (int nr)
	{
		for (int i = 0; i < musicIcons.Length - 1; i+= 2) {
			musicIcons [i].gameObject.SetActive (true);
		}
		for (int i = 1; i < musicIcons.Length-1; i+= 2) {
			musicIcons [i].gameObject.SetActive (false);
		}
		musicIcons [nr*2].gameObject.SetActive (false);

		musicIcons [nr * 2+1].gameObject.SetActive (true);

		mainAudio.GetComponent<AudioSource>().clip = clips[nr];
		mainAudio.GetComponent<AudioSource> ().Play ();
	}
}