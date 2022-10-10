using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal static class DrawCollider2DGizmo
    {
        [DrawGizmo( GizmoType.NotInSelectionHierarchy )]
        private static void DrawBoxCollider2D( BoxCollider2D collider, GizmoType type )
        {
            var setting = DrawCollider2DGizmoSetting.instance;

            if ( !setting.IsEnable ) return;

            var bounds = collider.bounds;
            var min    = bounds.min;
            var max    = bounds.max;

            DrawLine( min, new( max.x, min.y, min.z ) );
            DrawLine( min, new( min.x, max.y, min.z ) );
            DrawLine( max, new( min.x, max.y, max.z ) );
            DrawLine( max, new( max.x, min.y, min.z ) );
        }

        private static void DrawLine( Vector3 from, Vector3 to )
        {
            var setting = DrawCollider2DGizmoSetting.instance;

            Handles.DrawBezier
            (
                startPosition: from,
                endPosition: to,
                startTangent: from,
                endTangent: to,
                color: setting.Color,
                texture: null,
                width: setting.LineWidth
            );
        }
    }
}