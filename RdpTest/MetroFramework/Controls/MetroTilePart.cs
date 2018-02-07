using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Drawing.Html;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
    #region Enums

    public enum MetroTilePartContentType
    {
        Text,
        Image,
        Html
    }

    #endregion

    [ToolboxItem(false)]
    public class MetroTilePart : Control, IMetroControl
    {
        #region Interface

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        #endregion

        #region Fields

        private MetroTilePartContentType partContentType = MetroTilePartContentType.Text;
        [DefaultValue(MetroTilePartContentType.Text)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        public MetroTilePartContentType ContentType 
        {
            get { return partContentType; }
            set { partContentType = value; }
        }

        private string partHtmlContent = "";
        [DefaultValue("")]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public string HtmlContent
        {
            get { return partHtmlContent; }
            set { partHtmlContent = value; }
        }

        #endregion

        #region Constructor

        public MetroTilePart()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Dock = DockStyle.Fill;
        }

        #endregion

        #region Paint Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (partContentType == MetroTilePartContentType.Html)
            {
                HtmlRenderer.Render(e.Graphics, partHtmlContent, ClientRectangle, true);
            }
        }

        #endregion

        event EventHandler<Drawing.MetroPaintEventArgs> IMetroControl.CustomPaintBackground
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler<Drawing.MetroPaintEventArgs> IMetroControl.CustomPaint
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler<Drawing.MetroPaintEventArgs> IMetroControl.CustomPaintForeground
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        MetroColorStyle IMetroControl.Style
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        MetroThemeStyle IMetroControl.Theme
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        MetroStyleManager IMetroControl.StyleManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMetroControl.UseCustomBackColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMetroControl.UseCustomForeColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMetroControl.UseStyleColors
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IMetroControl.UseSelectable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
