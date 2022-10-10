using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/DrawCollider2DGizmoSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class DrawCollider2DGizmoSetting : ScriptableSingleton<DrawCollider2DGizmoSetting>
    {
        [SerializeField] private bool  m_isEnable;
        [SerializeField] private Color m_color = Color.white;

        public bool  IsEnable => m_isEnable;
        public Color Color    => m_color;

        public void Save()
        {
            Save( true );
        }
    }
}