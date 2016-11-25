using UnityEngine;
using System.Collections;

public interface ITargetAction {

	void DoAction(GameObject player);
	void UndoAction();
}
