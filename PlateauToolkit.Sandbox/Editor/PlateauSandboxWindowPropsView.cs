﻿using UnityEditor;

namespace PlateauToolkit.Sandbox.Editor
{
    class PlateauSandboxWindowPropsView : IPlateauSandboxWindowView
    {
        readonly PlateauSandboxAssetListState<PlateauSandboxProp> m_AssetListState = new();

        public string Name => "アイテム";

        public void OnGUI(PlateauSandboxContext context, EditorWindow window)
        {
            EditorGUILayout.LabelField("ツール", EditorStyles.boldLabel);
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                PlateauSandboxGUI.PlacementToolButton(context);
            }

            PlateauSandboxAssetListGUI.OnGUI(window.position.width, context, m_AssetListState);
        }
    }
}