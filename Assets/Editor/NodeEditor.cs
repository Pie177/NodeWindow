using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {

    Rect myRect = new Rect(10, 10, 100, 100);
    List<Rect> myWindows = new List<Rect>();

    [MenuItem("Window/Node editor")]
	static void ShowWindow()
    {
        NodeEditor editor = EditorWindow.GetWindow<NodeEditor>();
    }

    private void OnGUI()
    {
        if(myWindows.Count > 1)
        {
            DrawNodeCurve(myWindows[0], myWindows[1]);
        }

        if(GUILayout.Button("Add Node"))
        {
            myWindows.Add(new Rect(10, 10, 100, 100));
        }
        BeginWindows();
        for(int i = 0; i < myWindows.Count; i++)
        {
            myWindows[i] = GUI.Window(i, myWindows[i], DrawWindow, "My Window");
        }
        EndWindows();
    }

    void DrawWindow(int id)
    {
        GUI.DragWindow();
    }

    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y+(start.height/2), 0);
        Vector3 endPos = new Vector3(end.x, end.y + (end.height / 2), 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.red, null, 2f);
    }
}
