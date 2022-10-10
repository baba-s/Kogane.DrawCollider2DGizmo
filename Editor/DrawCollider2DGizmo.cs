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

        [DrawGizmo( GizmoType.NotInSelectionHierarchy | GizmoType.Selected )]
        private static void DrawCircleCollider2D( CircleCollider2D collider, GizmoType type )
        {
            var setting = DrawCollider2DGizmoSetting.instance;

            if ( !setting.IsEnable ) return;

            var radius    = collider.radius;
            var lineWidth = setting.LineWidth;

            Handles.color = setting.Color;

            Handles.DrawWireArc
            (
                center: collider.bounds.center,
                normal: Vector3.forward,
                from: Vector3.up * radius,
                angle: 360,
                radius: radius,
                thickness: lineWidth
            );
        }

        [DrawGizmo( GizmoType.NotInSelectionHierarchy | GizmoType.Selected )]
        private static void DrawPolygonCollider2D( PolygonCollider2D collider, GizmoType type )
        {
            var setting = DrawCollider2DGizmoSetting.instance;

            if ( !setting.IsEnable ) return;

            var lineWidth = setting.LineWidth;

            Handles.color = setting.Color;

            for ( var i = 0; i < collider.pathCount; i++ )
            {
                var pathArray = collider.GetPath( i );

                for ( var currentIndex = 0; currentIndex < pathArray.Length; currentIndex++ )
                {
                    var nextIndex = ( currentIndex + 1 ) % pathArray.Length;

                    Handles.DrawLine
                    (
                        p1: pathArray[ currentIndex ],
                        p2: pathArray[ nextIndex ],
                        thickness: lineWidth
                    );
                }
            }
        }
    }
}