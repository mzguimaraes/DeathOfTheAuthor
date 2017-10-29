using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(TextMesh))]
public class ButtonPrompt : MonoBehaviour {

	private TextMesh text;
	private CueCircle cueCircle;
	private EndCircle endCircle;

	public float duration = 3f;
	public KeyCode key;

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
		text.text = key.ToString();

		cueCircle = GetComponentInChildren<CueCircle>();
		endCircle = GetComponentInChildren<EndCircle>();
		cueCircle.SetEndScale(endCircle.transform.localScale.magnitude);
		cueCircle.SetDuration(duration);
	}

	public void Destroy() {
		Destroy(gameObject);
	}

	public void CuePress() {
		Debug.Log("Cue press");
	}

}
