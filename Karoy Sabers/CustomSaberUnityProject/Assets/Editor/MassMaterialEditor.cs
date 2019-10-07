using UnityEditor;
using UnityEngine;
 
public class MassMaterialCHange : ScriptableWizard
{  
    public enum colorProperty { MainColor = 1, SpecularColor = 2, EmissionColor = 3, ReflectionColor = 4};
    public colorProperty ColorProperty;
    public Color newColor;
   
    void OnWizardCreate()
    {
        ChangeColors((int)ColorProperty,newColor);
    }
   
    [MenuItem("Editor/Material/Change Material Colors...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard(
            "Change Materials Colors", typeof(MassMaterialCHange), "Change"
        );
    }
   
    [MenuItem("Editor/Material/Change Shader to NPR Alpha")]
    static void Change1()
    {
        Shader newshader = Shader.Find( "BeatSaberNPR/Alpha" );
        ChangeShaders(newshader);
    }
   
    [MenuItem("Editor/Material/Change Shader to NPR Opaque Glow")]
    static void Change2()
    {
        Shader newshader = Shader.Find( "BeatSaberNPR/OpaqueGlow" );
        ChangeShaders(newshader);
    }

    static Object[] GetSelectedMaterials()
    {
        return Selection.GetFiltered(typeof(Material), SelectionMode.DeepAssets);
    }
 
    static void ChangeColors(int ColorProperty, Color newColor)
   {
      int counter = 0;
       if (Selection.objects.Length > 0)
        {
            Object[] materiales = GetSelectedMaterials();
            if (materiales.Length > 0)
            {
                foreach( Material mat in materiales )
                {  
                    string property = "";
                    if (ColorProperty == 1) property = "_Color";
                    if (ColorProperty == 2) property = "_SpecColor";
                    if (ColorProperty == 3) property = "_Emission";
                    if (ColorProperty == 4) property = "_ReflectColor";
                    if( mat.HasProperty(property) )
                    {
                        mat.SetColor(property,newColor);
                        counter++;
                    }
                }
 
            }
        }
      EditorUtility.DisplayDialog( "Message", "materials changed: " + counter, "OK" );
   }
   
   static void ChangeShaders(Shader newShader)
   {
      int counter = 0;
       if (Selection.objects.Length > 0)
        {
            Object[] materiales = GetSelectedMaterials();
            if (materiales.Length > 0)
            {
                foreach( Material mat in materiales )
                {  
                    mat.shader = newShader;
                    counter++;
                }
 
            }
        }
      EditorUtility.DisplayDialog( "Message", "materials changed: " + counter, "OK" );
   }
   
}