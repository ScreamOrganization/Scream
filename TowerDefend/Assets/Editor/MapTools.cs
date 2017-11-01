using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
[CustomEditor(typeof(MapManager))]
public class MapTools : Editor
{
    #region inspector
    MapManager script;//所对应的脚本对象
    GameObject rootObject;//脚本的GameObject
    SerializedObject seriObject;//所对应的序列化对象
    SerializedProperty headColor;//一个[SerializeField][HideInInspector]且private的序列化的属性
    private static bool toggle = true;//toggle按钮的状态

    //初始化
    public void OnEnable()
    {
        seriObject = base.serializedObject;
        headColor = seriObject.FindProperty("headColor");
        var tscript = (MapManager)(base.serializedObject.targetObject);
        if (tscript != null)
        {
            script = tscript;
            rootObject = script.gameObject;
        }
        else
        {
            Console.Error.WriteLine("tscript is null");
        }
    }

    //清理
    public void OnDisable()
    {
        var tscript = (MapManager)(base.serializedObject.targetObject);
        if (tscript == null)
        {
            // 这种情况是脚本对象被移除了;  
            Debug.Log("tscript == null");
        }
        else
        {
            // 这种情况是编译脚本导致的重刷;  
            Debug.Log("tscript != null");
        }
        seriObject = null;
        script = null;
        rootObject = null;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        seriObject.Update();
        //将target转化为脚本对象
        script = target as MapManager;
        GUILayout.Space(20);
        //random按钮  
        if (GUILayout.Button("随机生成地图(测试用)", GUILayout.Height(30)))
        {
            //注册undo，可以在edit菜单里看到undo，也可以通过ctrl+z来回退
            Undo.RecordObject(script, "revert random num");
            script.RandomLevel();
        }
        
        ////save scene和toggle这组按钮
        //GUILayout.BeginHorizontal();
        //{
        //    if (GUILayout.Button("SaveScene"))
        //    {
        //        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        //    }
        //    if (GUILayout.Button(toggle ? "untoggle" : "toggle"))
        //    {
        //        toggle = !toggle;
        //    }
        //}
        //GUILayout.EndHorizontal();

        //script.isAlive = EditorGUILayout.BeginToggleGroup("isAlive", script.isAlive);
        //if (script.isAlive)//如果isAlive不勾选则不显示life
        //{
        //    script.life = EditorGUILayout.Slider("life", script.life, 0, 100f);
        //}
        //EditorGUILayout.EndToggleGroup();

        ////可以显示TestInspector中序列化但是不在inspector中显示的属性
        //EditorGUILayout.PropertyField(headColor);
        //seriObject.ApplyModifiedProperties();

        ////展示普通信息
        //EditorGUILayout.LabelField("life " + script.life, GUILayout.Width(200));
        Repaint();
 
    }

    #endregion
}
