using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueCircle : MonoBehaviour {

	private float timeToCue = 5f;
	private float lifetime = 0f;

	public float cueScale = .25f;
	public float BtwnCueDestroy = 1f;
	private Vector3 initScale;

	private ButtonPrompt button;

	public float SetDuration(float dur) {
		timeToCue = dur;
		return timeToCue;
	}

	public float SetEndScale(float end) {
		cueScale = end;
		return cueScale;
	}

	void Awake() {
		button = GetComponentInParent<ButtonPrompt>();
		initScale = transform.localScale;
		StartCoroutine(Shrink());
	}

	IEnumerator Shrink() {
		float cueMagnitude = Mathf.Sqrt(Mathf.Pow(cueScale, 3));
		while (transform.localScale.magnitude > cueScale) {
			Debug.Log(lifetime);
			transform.localScale = initScale * Mathf.Sin(Mathf.Lerp(1f, cueMagnitude, lifetime / timeToCue));
			yield return null;
		}
		button.CuePress();
		while (transform.localScale.magnitude > 0f) {
			Debug.Log(lifetime);
			transform.localScale = initScale * Mathf.Sin(Mathf.Lerp(cueMagnitude, 0f, (lifetime - BtwnCueDestroy) / timeToCue));
			yield return null;
		}
		button.Destroy();
	}

	void Update () {
		lifetime += Time.deltaTime;
	}
}
