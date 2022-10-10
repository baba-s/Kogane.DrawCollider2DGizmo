using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/DrawCollider2DGizmoSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class DrawCollider2DGizmoSetting : ScriptableSingleton<DrawCollider2DGizmoSetting>
    {
        [SerializeField] private bool  m_isEnable;
        [SerializeField] private Color m_color     = Color.white;
        [SerializeField] private float m_lineWidth = 1;

        public bool  IsEnable  => m_isEnable;
        public Color Color     => m_color;
        public float LineWidth => m_lineWidth;

        public void Save()
        {
            Save( true );
        }
    }
}