using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal static class DrawCollider2DGizmo
    {
        [DrawGizmo( GizmoType.NotInSelectionHierarchy | GizmoType.Selected )]
        private static void DrawBoxCollider2D( BoxCollider2D collider, GizmoType type )
        {
            var setting = DrawCollider2DGizmoSetting.instance;

            if ( !setting.IsEnable ) return;

            var bounds    = collider.bounds;
            var min       = bounds.min;
            var max       = bounds.max;
            var lineWidth = setting.LineWidth;

            Handles.color = setting.Color;

            Handles.DrawLine( min, new( max.x, min.y, min.z ), lineWidth );
            Handles.DrawLine( min, new( min.x, max.y, min.z ), lineWidth );
            Handles.DrawLine( max, new( min.x, max.y, max.z ), lineWidth );
            Handles.DrawLine( max, new( max.x, min.y, min.z ), lineWidth );
        }
    }
}