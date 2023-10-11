using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Editor : EditorWindow
{
    [MenuItem("Window/Editor")]
    public static void ShowEditor()
    {
        GetWindow<Editor>();
    }

    private List<GameObject> prefabList = new List<GameObject>();
    private int selectedPrefabIndex = -1;

    private void OnGUI()
    {
        GUILayout.Label("오브젝트 배치 에디터");

        // 프리팹 저장 버튼
        if (GUILayout.Button("Save Prefab"))
        {
            GameObject selectedObject = Selection.activeGameObject;

            if (selectedObject != null)
            {
                // 선택한 오브젝트를 프리팹으로 저장
                string prefabPath = "Assets/Prefabs/" + selectedObject.name + ".prefab";
                PrefabUtility.SaveAsPrefabAsset(selectedObject, prefabPath);

                // 저장된 프리팹을 목록에 추가
                prefabList.Add(selectedObject);
            }
            else
            {
                Debug.LogWarning("Select a GameObject to save as a prefab.");
            }
        }

        // 저장된 프리팹 목록 표시
        EditorGUILayout.LabelField("Saved Prefabs:");
        for (int i = 0; i < prefabList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(i + ": " + prefabList[i].name);
            if (GUILayout.Button("Select"))
            {
                selectedPrefabIndex = i;
            }

            if (GUILayout.Button("Remove"))
            {
                prefabList.RemoveAt(i);
                i--;
            }

            EditorGUILayout.EndHorizontal();
        }

        // 선택한 프리팹을 씬에 배치
        if (selectedPrefabIndex >= 0 && selectedPrefabIndex < prefabList.Count)
        {
            if (GUILayout.Button("Place Selected Prefab"))
            {
                GameObject selectedPrefab = prefabList[selectedPrefabIndex];
                GameObject newPrefabInstance = Instantiate(selectedPrefab) as GameObject;
                if (newPrefabInstance != null)
                {
                    SceneView sceneView = SceneView.lastActiveSceneView;
                    if (sceneView != null)
                    {
                        Vector3 spawnPosition = sceneView.camera.transform.position + sceneView.camera.transform.forward * 5f;
                        newPrefabInstance.transform.position = spawnPosition;
                        newPrefabInstance.transform.parent = GameObject.Find("Structure").transform;

                        Selection.activeGameObject = newPrefabInstance;
                    }
                }
                else if(newPrefabInstance == null)
                {
                    Debug.Log("널");
                }
            }
        }
    }
}
