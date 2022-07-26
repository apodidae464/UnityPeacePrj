using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(FoodData))]
[CanEditMultipleObjects]
[System.Serializable]
public class FoodDataEditor : Editor
{
    private ReorderableList FoodTypeEditorList;

    private void OnEnable()
    {
        InitializeReordableList(ref FoodTypeEditorList, propertyName: "FoodTypeList",
            listLabel: "FoodTypeList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        FoodTypeEditorList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    private void InitializeReordableList(ref ReorderableList list, string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, elements: serializedObject.FindProperty(propertyName),
            draggable: true, displayHeader: true, displayAddButton: true, displayRemoveButton: true);

        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, listLabel);
        };

        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(
                position: new Rect(rect.x, rect.y, width: 60, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("name"), GUIContent.none);
            EditorGUI.PropertyField(
                position: new Rect(x: rect.x + 70, rect.y, width: rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("image"), GUIContent.none);
        };
    }
}