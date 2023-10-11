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
        GUILayout.Label("������Ʈ ��ġ ������");

        // ������ ���� ��ư
        if (GUILayout.Button("Save Prefab"))
        {
            GameObject selectedObject = Selection.activeGameObject;

            if (selectedObject != null)
            {
                // ������ ������Ʈ�� ���������� ����
                string prefabPath = "Assets/Prefabs/" + selectedObject.name + ".prefab";
                PrefabUtility.SaveAsPrefabAsset(selectedObject, prefabPath);

                // ����� �������� ��Ͽ� �߰�
                prefabList.Add(selectedObject);
            }
            else
            {
                Debug.LogWarning("Select a GameObject to save as a prefab.");
            }
        }

        // ����� ������ ��� ǥ��
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

        // ������ �������� ���� ��ġ
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
                    Debug.Log("��");
                }
            }
        }
    }
}
