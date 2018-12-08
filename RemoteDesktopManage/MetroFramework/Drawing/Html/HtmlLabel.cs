using System;
using System.ComponentModel;

namespace MetroFramework.Drawing.Html
{
    /// <summary>
    /// Provides HTML rendering on the text of the label
    /// </summary>
    [CLSCompliant(false)]
    public class HtmlLabel
        : HtmlPanel
    {
        #region Fields

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new HTML Label
        /// </summary>
        public HtmlLabel()
        {
            SetStyle(System.Windows.Forms.ControlStyles.Opaque, false);

            AutoScroll = false;
        }

        #endregion

        #region Properties

        [DefaultValue(true)]
        [Description("Automatically sets the size of the label by measuring the content")]
        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;

                if (value)
                {
                    MeasureBounds();
                }
            }
        }

        #endregion

        #region Methods

        protected override void CreateFragment()
        {
            string text = Text;
            string font = string.Format("font: {0}pt {1}", Font.Size, Font.FontFamily.Name);

            //Create fragment container
            htmlContainer = new InitialContainer("<table border=0 cellspacing=5 cellpadding=0 style=\"" + font + "\"><tr><td>" + text + "</td></tr></table>");
            //_htmlContainer.SetBounds(new Rectangle(0, 0, 10, 10));
            
        }

        public override void MeasureBounds()
        {
            base.MeasureBounds();

            if(htmlContainer != null && AutoSize)
                Size = System.Drawing.Size.Round(htmlContainer.MaximumSize);
        }

        #endregion
    }
}
