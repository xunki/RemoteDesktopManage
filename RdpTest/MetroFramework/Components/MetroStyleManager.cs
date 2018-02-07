using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
    public sealed class MetroStyleManager : Component, ICloneable, ISupportInitialize
    {
        #region Fields

        private readonly IContainer parentContainer;

        private MetroColorStyle metroStyle = MetroDefaults.Style;
        [DefaultValue(MetroDefaults.Style)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroColorStyle Style
        {
            get { return metroStyle; }
            set
            {
                if (value == MetroColorStyle.Default)
                {
                    value = MetroDefaults.Style;
                }

                metroStyle = value;

                if (!isInitializing)
                {
                    Update();
                }
            }
        }

        private MetroThemeStyle metroTheme = MetroDefaults.Theme;
        [DefaultValue(MetroDefaults.Theme)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroThemeStyle Theme
        {
            get { return metroTheme; }
            set
            {
                if (value == MetroThemeStyle.Default)
                {
                    value = MetroDefaults.Theme;
                }

                metroTheme = value;

                if (!isInitializing)
                {
                    Update();
                }
            }
        }

        private ContainerControl owner;
        public ContainerControl Owner
        {
            get { return owner; }
            set
            {
                if (owner != null)
                {
                    owner.ControlAdded -= ControlAdded;
                }

                owner = value;

                if (value != null)
                {
                    owner.ControlAdded += ControlAdded;

                    if (!isInitializing)
                    {
                        UpdateControl(value);
                    }
                }
            }
        }

        #endregion

        #region Constructor

        public MetroStyleManager()
        {
        
        }

        public MetroStyleManager(IContainer parentContainer)
            : this()
        {
            if (parentContainer != null)
            {
                this.parentContainer = parentContainer;
                this.parentContainer.Add(this);
            }
        }

        #endregion

        #region ICloneable

        public object Clone()
        {
            MetroStyleManager newStyleManager = new MetroStyleManager();
            newStyleManager.metroTheme = Theme;
            newStyleManager.metroStyle = Style;
            return newStyleManager;
        }

        public object Clone(ContainerControl owner)
        {
            MetroStyleManager clonedManager = Clone() as MetroStyleManager;

            if (owner is IMetroForm)
            {
                clonedManager.Owner = owner;
            }

            return clonedManager;
        }

        #endregion

        #region ISupportInitialize

        private bool isInitializing;

        void ISupportInitialize.BeginInit()
        {
            isInitializing = true;
        }

        void ISupportInitialize.EndInit()
        {
            isInitializing = false;
            Update();
        }

        #endregion

        #region Management Methods

        private void ControlAdded(object sender, ControlEventArgs e)
        {
            if (!isInitializing)
            {
                UpdateControl(e.Control);
            }
        }

        public void Update()
        {
            if (owner != null)
            {
                UpdateControl(owner);
            }

            if (parentContainer == null || parentContainer.Components == null)
            {
                return;
            }

            foreach (Object obj in parentContainer.Components)
            {
                if (obj is IMetroComponent)
                {
                    ApplyTheme((IMetroComponent)obj);
                }

                if (obj.GetType() == typeof(MetroContextMenu))
                {
                    ApplyTheme((MetroContextMenu)obj);
                }
            }
        }

        private void UpdateControl(Control ctrl)
        {
            if (ctrl == null)
            {
                return;
            }

            IMetroControl metroControl = ctrl as IMetroControl;
            if (metroControl != null)
            {
                ApplyTheme(metroControl);
            }

            IMetroComponent metroComponent = ctrl as IMetroComponent;
            if (metroComponent != null)
            {
                ApplyTheme(metroComponent);
            }

            TabControl tabControl = ctrl as TabControl;
            if (tabControl != null)
            {
                foreach (TabPage tp in ((TabControl)ctrl).TabPages)
                {
                    UpdateControl(tp);
                }
            }

            if (ctrl.Controls != null)
            {
                foreach (Control child in ctrl.Controls)
                {
                    UpdateControl(child);
                }
            }

            if (ctrl.ContextMenuStrip != null)
            {
                UpdateControl(ctrl.ContextMenuStrip);
            }

            ctrl.Refresh();
        }

        private void ApplyTheme(IMetroControl control)
        {
            control.StyleManager = this;
        }

        private void ApplyTheme(IMetroComponent component)
        {
            component.StyleManager = this;
        }

        #endregion
    }
}
