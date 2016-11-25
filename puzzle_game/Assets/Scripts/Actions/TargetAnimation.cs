using UnityEngine;
using System.Collections;

public class TargetAnimation : MonoBehaviour, ITargetAction {
//public class TargetAnimation : MonoBehaviour, ITargetAction {
	[SerializeField] private Animation anim;
	[SerializeField] private AnimationClip showClip;
	[SerializeField] private AnimationClip hideClip;

	public void DoAction(GameObject player) {
		anim.clip = showClip;
		anim.Play();
	}

	public void UndoAction() {
		anim.clip = hideClip;
		anim.Play();
	}
}
