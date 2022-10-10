using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    [EditorToolbarElement( ID, typeof( SceneView ) )]
    internal sealed class DrawCollider2DGizmoToolbarToggle : ToolbarToggle
    {
        public const string ID =
            nameof( DrawCollider2DGizmoToolbarOverlay ) + "." +
            nameof( DrawCollider2DGizmoToolbarToggle );

        private DrawCollider2DGizmoToolbarToggle()
        {
            value = DrawCollider2DGizmoSetting.instance.IsEnable;
            text  = "Draw Collider 2D Gizmo";
            RegisterCallback<ChangeEvent<bool>>( HandleCallback );
        }

        private static void HandleCallback( ChangeEvent<bool> changeEvent )
        {
            var setting = DrawCollider2DGizmoSetting.instance;
            setting.IsEnable = changeEvent.newValue;
            setting.Save();
        }
    }
}