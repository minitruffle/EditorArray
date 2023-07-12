using UnityEngine;
using UnityEditor;

public class ExampleEditor : EditorWindow
{
    EditorArray exampleArray = new EditorArray(0, "Example Array");

    void OnGUI()
    {
        exampleArray.Update();
    }
}
