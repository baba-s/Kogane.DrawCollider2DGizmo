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
            Gizmos.color = setting.Color;

            var bounds = collider.bounds;
            var min    = bounds.min;
            var max    = bounds.max;

            Gizmos.DrawLine( min, new( max.x, min.y, min.z ) );
            Gizmos.DrawLine( min, new( min.x, max.y, min.z ) );
            Gizmos.DrawLine( max, new( min.x, max.y, max.z ) );
            Gizmos.DrawLine( max, new( max.x, min.y, min.z ) );
        }
    }
}