using UnityEditor;
using UnityEditor.Overlays;

namespace Kogane.Internal
{
    [Overlay( typeof( SceneView ), "Kogane/Draw Collider 2D Gizmo" )]
    internal sealed class DrawCollider2DGizmoToolbarOverlay : ToolbarOverlay
    {
        private DrawCollider2DGizmoToolbarOverlay() : base
        (
            DrawCollider2DGizmoToolbarToggle.ID
        )
        {
        }
    }
}