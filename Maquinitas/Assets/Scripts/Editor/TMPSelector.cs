using UnityEngine;
using UnityEditor;
using TMPro;

public class TMPSelector : EditorWindow
{
    [MenuItem("Tools/Select All TMP in GameObject")]
    static void SelectAllTMP()
    {
        GameObject selectedObject = Selection.activeGameObject;

        if (selectedObject != null)
        {
            TextMeshProUGUI[] tmpComponents = selectedObject.GetComponentsInChildren<TextMeshProUGUI>(true);

            if (tmpComponents.Length > 0)
            {
                Selection.objects = tmpComponents;
                Debug.Log("Selected " + tmpComponents.Length + " TextMeshPro components.");
            }
            else
            {
                Debug.LogWarning("No TextMeshPro components found in the selected GameObject and its children.");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject selected.");
        }
    }
}
