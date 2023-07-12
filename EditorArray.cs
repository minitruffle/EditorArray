using UnityEditor;
using UnityEngine;

public class EditorArray
{
    public int length;
    public string name;
    public bool expanded;

    public YourClass[] arr;

    public EditorArray(int length, string name)
    {
        this.length = length;
        this.name = name;
        arr = new YourClass[length];
    }

    int last;

    YourClass[] lastArr;

    public void Update()
    {
        GUILayout.BeginHorizontal();

        expanded = EditorGUILayout.Foldout(expanded, name, EditorStyles.foldoutHeader);
        length = EditorGUILayout.IntField(length, GUILayout.Width(50));
        
        OnLengthUpdate();

        GUILayout.EndHorizontal();

        if (expanded)
        {
            for (int i = 0; i < length; i++)
            {
                arr[i] = EditorGUILayout.ObjectField(arr[i], typeof(YourClass), false) as YourClass;
            }

            GUILayout.BeginHorizontal();


            if (GUILayout.Button("+", EditorStyles.miniButtonLeft, GUILayout.Width(35)))
            {
                length++;
            }

            if (GUILayout.Button("-", EditorStyles.miniButtonMid, GUILayout.Width(35)))
            { 
                length--;
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(15);
        }

        OnLengthUpdate();

        last = length;
        lastArr = arr;
    }

    void OnLengthUpdate()
    {
        if (length != last)
        {
            arr = new YourClass[length];
            
            if (length > last)
            {
                for(int i = 0; i < last; i++)
                {
                    arr[i] = lastArr[i];
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    arr[i] = lastArr[i];
                }
            }
        }
    }

}
