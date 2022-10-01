using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{

    public override void OnInspectorGUI ()
    {
		base.OnInspectorGUI();

		var script = (EnemySpawner) target;

		if (!Application.isPlaying) return;

		if (GUILayout.Button("Spawn"))
        {
			script.SpawnEnemy();
		}

        if (GUILayout.Button("Spawn 5"))
        {
			for (int i = 0; i < 5; i++)
            {
                script.SpawnEnemy();
            }
		}
	}

}
