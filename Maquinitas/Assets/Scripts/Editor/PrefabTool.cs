using UnityEngine;
using UnityEditor;

public class PrefabTool : EditorWindow
{
    private GameObject activePrefab;
    private Transform parentObject;

    private GameObject lastInstantiatedObject;
    private bool isDragging;
    private Vector2 dragStartPosition;

    [MenuItem("Window/Object Instantiator")]
    public static void ShowWindow()
    {
        GetWindow<PrefabTool>("Object Instantiator");
    }

    private void OnGUI()
    {
        activePrefab = EditorGUILayout.ObjectField("Active Prefab", activePrefab, typeof(GameObject), false) as GameObject;
        parentObject = EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(Transform), true) as Transform;

        if (GUILayout.Button("Set Active Prefab"))
        {
            SceneView.duringSceneGui += DuringSceneGUI;
        }

        if (GUILayout.Button("Clear Active Prefab"))
        {
            SceneView.duringSceneGui -= DuringSceneGUI;
            activePrefab = null;
        }
    }

    private void DuringSceneGUI(SceneView sceneView)
    {
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        Event guiEvent = Event.current;
        EventType eventType = guiEvent.type;

        if (eventType == EventType.MouseDown && guiEvent.button == 0)
        {
            Ray mouseRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                lastInstantiatedObject = PrefabUtility.InstantiatePrefab(activePrefab) as GameObject;
                lastInstantiatedObject.transform.position = hitInfo.point;
                lastInstantiatedObject.transform.rotation = Quaternion.identity;
                if (parentObject != null)
                    lastInstantiatedObject.transform.parent = parentObject;

                Undo.RegisterCreatedObjectUndo(lastInstantiatedObject, "Instantiate Object");
            }
        }
        else if (eventType == EventType.MouseDrag && guiEvent.button == 0 && lastInstantiatedObject != null)
        {
            isDragging = true;
            dragStartPosition = Event.current.mousePosition;
        }
        else if (eventType == EventType.MouseUp && guiEvent.button == 0)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 dragDelta = Event.current.mousePosition - dragStartPosition;
            Undo.RecordObject(lastInstantiatedObject.transform, "Rotate Object");
            lastInstantiatedObject.transform.Rotate(Vector3.up, dragDelta.x);
            dragStartPosition = Event.current.mousePosition;
            Event.current.Use();
        }
    }
}
