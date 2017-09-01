// =====================================================================
// Copyright 2013-2017 Fluffy Underware
// All rights reserved
// 
// http://www.fluffyunderware.com
// =====================================================================

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.Curvy.Generator.Modules;

namespace FluffyUnderware.CurvyEditor.Generator.Modules
{
    [CustomEditor(typeof(CreatePathLineRenderer))]
    public class CreatePathLineRendererEditor : CGModuleEditor<CreatePathLineRenderer>
    {

        protected override void OnCustomInspectorGUIBefore()
        {
            base.OnCustomInspectorGUIBefore();
            EditorGUILayout.HelpBox("Please edit parameters in inspector!", MessageType.Info);
            if (GUILayout.Button("Select Inspector"))
                Selection.activeGameObject = Target.gameObject;
        }
        
    }
   
}
