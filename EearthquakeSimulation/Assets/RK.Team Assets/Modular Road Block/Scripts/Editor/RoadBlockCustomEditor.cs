using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(RK.Team.RoadBlockGenerator))]
public class RoadBlockCustomEditor : Editor
{
    public Sprite _head;
    public Sprite _destructionFront;
    public Sprite _destructionBack;
    public Sprite _divideLine;

    public override void OnInspectorGUI()
    {
        var currTarget = (RK.Team.RoadBlockGenerator)target;
        EditorGUILayout.Space();

        Rect headRect = _head.rect;
        float headWidth = headRect.width;
        float headHeight = headRect.height;
        Rect headDrawRect = GUILayoutUtility.GetRect(headWidth, headHeight);

        if (Event.current.type == EventType.Repaint)
        {
            var tex = _head.texture;
            headRect.xMin /= tex.width;
            headRect.xMax /= tex.width;
            headRect.yMin /= tex.height;
            headRect.yMax /= tex.height;

            headDrawRect.width = _head.rect.width;
            GUI.DrawTextureWithTexCoords(headDrawRect, tex, headRect);
        }

        DrawDivideLine();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Repair"))
            currTarget.Repair();

            if (GUILayout.Button("Fracture"))
                currTarget.Fracture();

        if (GUILayout.Button("Random"))
            currTarget.RandomModules();

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);

        EditorGUILayout.LabelField("Destruction toogles:", EditorStyles.boldLabel);

        GUILayout.Space(5);

        foreach (var part in currTarget._blockParts)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(part._partName.ToString());
            GUILayout.FlexibleSpace();
            part._brokenToggle = EditorGUILayout.Toggle(part._brokenToggle);

            EditorGUILayout.EndHorizontal();
            DrawDivideLine();
            GUILayout.Space(5);
        }

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Debug mode:", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        currTarget._showDebugInspector = EditorGUILayout.Toggle(currTarget._showDebugInspector);

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (currTarget._showDebugInspector)
            DrawDefaultInspector();
    }

    private void DrawDivideLine()
    {
        Rect divideRect = _divideLine.rect;
        float divideWidth = divideRect.width;
        float divideHeight = divideRect.height;
        Rect divideDrawRect = GUILayoutUtility.GetRect(divideWidth, divideHeight);

        if (Event.current.type == EventType.Repaint)
        {
            var tex = _divideLine.texture;
            divideRect.xMin /= tex.width;
            divideRect.xMax /= tex.width;
            divideRect.yMin /= tex.height;
            divideRect.yMax /= tex.height;
            GUI.DrawTextureWithTexCoords(divideDrawRect, tex, divideRect);
        }
    }
}
