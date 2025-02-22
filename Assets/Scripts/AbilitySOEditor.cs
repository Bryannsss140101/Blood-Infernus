using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbilitySO))]
public class AbilitySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AbilitySO ability = (AbilitySO)target;

        EditorGUI.BeginChangeCheck();

        ability.abilityName = EditorGUILayout.TextField("Name", ability.abilityName);

        ability.description = EditorGUILayout.TextArea(ability.description, GUILayout.Height(60));

        ability.cooldown = EditorGUILayout.FloatField("Cooldown", ability.cooldown);

        ability.behaviour = (AbilityBehaviour)EditorGUILayout.EnumFlagsField("Behaviour", ability.behaviour);

        ability.icon = (Sprite)EditorGUILayout.ObjectField("Icon", ability.icon, typeof(Sprite), false,
            GUILayout.Width(200), GUILayout.Height(80));

        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(ability);

        serializedObject.ApplyModifiedProperties();
    }
}
