using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEditor; 
using System; 
using System.IO; 
 
 
public class UnityEditor_Controller : EditorWindow 
{ 
 
    [MenuItem("Window/PopUps")]//Makes it avaliable to use in the menu in the Window catagory 
    public static void ShowWindow() 
    { 
        UnityEditor_Controller popUps = (UnityEditor_Controller)GetWindow(typeof(UnityEditor_Controller)); 
        popUps.minSize = new Vector2(100, 200); 
        popUps.maxSize = new Vector2(500, 600); 
    } 
 
    private void OnGUI() { 
        if (GUILayout.Button("DeleteSaves")) 
        { 
             
            if (DataPersitanceManager.fullPathFile != "") 
            { 
                string[] testPathIguess = Directory.GetFiles(Application.persistentDataPath); 
                foreach (string pathArray in testPathIguess) 
                { 
                    System.IO.File.Delete(pathArray); 
                } 
            } 
            AssetDatabase.Refresh(); 
        } 
    } 
     
 
     
} 
