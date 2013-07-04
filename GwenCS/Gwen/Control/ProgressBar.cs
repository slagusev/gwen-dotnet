﻿using System;

namespace Gwen.Control
{
    /// <summary>
    /// Progress bar.
    /// </summary>
    public class ProgressBar : Label
    {
        private bool m_Horizontal;
        private bool m_AutoLabel;
        private float m_Progress;

        /// <summary>
        /// Determines whether the control is horizontal.
        /// </summary>
        public bool IsHorizontal { get { return m_Horizontal; } set { m_Horizontal = value; } }

        /// <summary>
        /// Progress value (0-1).
        /// </summary>
        public float Value
        {
            get { return m_Progress; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 1)
                    value = 1;

                m_Progress = value;
                if (m_AutoLabel)
                {
                    int displayVal = (int)(m_Progress * 100);
                    Text = displayVal.ToString() + "%";
                }
            }
        }

        /// <summary>
        /// Determines whether the label text is autogenerated from value.
        /// </summary>
        public bool AutoLabel { get { return m_AutoLabel; } set { m_AutoLabel = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public ProgressBar(Base parent)
            : base(parent)
        {
			AutoSizeToContents = false;

            SetSize(128, 32);
            TextPadding = Padding.Three;
            IsHorizontal = true;

            Alignment = Pos.Center;
            m_Progress = 0;
            m_AutoLabel = true;
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Render(Skin.Base skin)
        {
            skin.DrawProgressBar(this, m_Horizontal, m_Progress);
        }
    }
}
