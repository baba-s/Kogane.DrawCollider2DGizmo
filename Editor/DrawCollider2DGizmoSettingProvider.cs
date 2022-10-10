using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class DrawCollider2DGizmoSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Draw Collider 2D Gizmo";

        private Editor m_editor;

        private DrawCollider2DGizmoSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = DrawCollider2DGizmoSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            DrawCollider2DGizmoSetting.instance.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new DrawCollider2DGizmoSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}