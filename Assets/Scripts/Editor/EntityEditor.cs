using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Entity))]
public class EntityEditor : Editor
{

    public override void OnInspectorGUI () {
		base.OnInspectorGUI();

		var script = (Entity) target;

		if (!Application.isPlaying) return;

		if (GUILayout.Button("Kill")) {
			script.Die();
		}
	}

}
