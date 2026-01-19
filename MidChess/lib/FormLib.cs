using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidChess.lib
{
    public class FormLib
    {
        #region Config Variables

        private const string APP_TITLE = "MidChess";

        // MaintainRatio config
        private const double defaultMinFormRatio = 4.0 / 3.0;
        private const double defaultMaxFormRatio = 32.0 / 9.0;

        // ScalePadding config
        private const float paddingModifier1080 = 0.08f; // px
        private const float paddingModifier720 = 0.05f; // px
        private const float paddingModifier480 = 0.02f; // px

        // ScaleFont config
        private const int defaultBaseFormHeight = 480; // px 
        private const int defaultBaseFormWidth = 852; // px
        private const float defaultMinFontSize = 6f;
        private const float defaultMaxFontSize = 48f;

        #endregion

        /// <summary>
        /// Applies aspect ratio maintenance, padding scaling, and font scaling to the given form.
        /// </summary>
        /// <param name="form"></param>
        public void ApplyAll(Form form)
        {
            if (form.WindowState != FormWindowState.Minimized)
            {
                MaintainRatio(form);
                ScalePadding(form);
                ScaleAllFonts(form);
            }
        }
        
        #region Dialog Boxes

        /// <summary>
        /// Displays a confirmation dialog asking the user if they want to exit the application.
        /// Note: You can override this method to customize the exit confirmation behavior.
        /// </summary>
        /// <returns>True if the user confirms exit, false otherwise.</returns>
        public bool ConfirmExit()
        {
            return ShowConfirmDialog("Are you sure you want to quit?", "Confirm Exit");
        }

        /// <summary>
        /// Shows a Yes/No confirmation dialog.
        /// </summary>
        public bool ShowConfirmDialog(string message, string title = null)
        {
            return MessageBox.Show(message, title ?? APP_TITLE, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows an information message dialog.
        /// </summary>
        public void ShowInfoMessage(string message, string title = null)
        {
            MessageBox.Show(message, title ?? APP_TITLE, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a warning message dialog.
        /// </summary>
        public void ShowWarningMessage(string message, string title = null)
        {
            MessageBox.Show(message, title ?? APP_TITLE, 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Aspect Ratio and Padding

        /// <summary>
        /// Maintains the form's aspect ratio between minFormRatio and maxFormRatio by adjusting width and height.
        /// </summary>
        /// <param name="form">The form to maintain the aspect ratio for.</param>
        /// <param name="minFormRatio">The minimum aspect ratio allowed.</param>
        /// <param name="maxFormRatio">The maximum aspect ratio allowed.</param>
        public void MaintainRatio(Form form, double minFormRatio = defaultMinFormRatio, double maxFormRatio = defaultMaxFormRatio)
        {
            int width = form.Width;
            int height = form.Height;

            int minWidth = 0;
            int minHeight = 0;
            if (form.MinimumSize.Width > 0)
                minWidth = form.MinimumSize.Width;
            if (form.MinimumSize.Height > 0)
                minHeight = form.MinimumSize.Height;

            int maxWidth = int.MaxValue;
            int maxHeight = int.MaxValue;
            if (form.MaximumSize.Width > 0)
                maxWidth = form.MaximumSize.Width;
            if (form.MaximumSize.Height > 0)
                maxHeight = form.MaximumSize.Height;

            width = Math.Min(maxWidth, Math.Max(width, minWidth));
            height = Math.Min(maxHeight, Math.Max(height, minHeight));

            double currentRatio = (double)width / height;

            //Too tall
            if (currentRatio < minFormRatio)
            {
                int adjustedWidth = (int)(height * minFormRatio);
                if (adjustedWidth <= maxWidth)
                    width = adjustedWidth;
                else
                    height = (int)(width / minFormRatio);
            }

            currentRatio = (double)width / height;

            //Too wide
            if (currentRatio > maxFormRatio)
            {
                int adjustedHeight = (int)(width / maxFormRatio);
                if (adjustedHeight <= maxHeight)
                    height = adjustedHeight;
                else
                    width = (int)(height * maxFormRatio);
            }

            form.Width = width;
            form.Height = height;
        }

        /// <summary>
        /// Scales the form's padding based on the client height to maintain proper spacing at different resolutions.
        /// </summary>
        /// <param name="form">The form to scale padding for.</param>
        public void ScalePadding(Form form)
        {
            int screenHeight = form.ClientSize.Height;
            Padding newPadding;

            if (screenHeight >= 1080)
            {
                int pad = (int)(screenHeight * paddingModifier1080);
                newPadding = new Padding(pad);
            }
            else if (screenHeight >= 720)
            {
                int pad = (int)(screenHeight * paddingModifier720);
                newPadding = new Padding(pad);
            }
            else if (screenHeight >= 480)
            {
                int pad = (int)(screenHeight * paddingModifier480);
                newPadding = new Padding(pad);
            }
            else
                newPadding = new Padding(0);

            form.Padding = newPadding;
        }

        #endregion

        #region Fullscreen Handling
        /// <summary>
        /// Processes fullscreen-related keyboard shortcuts (F11, F, and Escape).
        /// </summary>
        /// <param name="form">The form processing the keys.</param>
        /// <param name="keyData">The key that was pressed.</param>
        /// <param name="isFullscreen">Reference to the current fullscreen state.</param>
        /// <returns>True if a fullscreen key was handled, false otherwise.</returns>
        public bool ProcessFullscreenKeys(Form form, Keys keyData, ref bool isFullscreen)
        {
            if (keyData == Keys.F11 || keyData == Keys.F)
                return true;

            if (keyData == Keys.Escape)
            {
                if (isFullscreen)
                    return true;
                else
                    form.Close();
            }

            return false;
        }

        /// <summary>
        /// Toggles the form between fullscreen and windowed mode.
        /// </summary>
        /// <param name="form">The form to toggle fullscreen for.</param>
        /// <param name="isFullscreen">Reference to the fullscreen state that will be toggled.</param>
        public void ToggleFullscreen(Form form, ref bool isFullscreen)
        {
            if (!isFullscreen)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                form.TopMost = true;
                isFullscreen = true;
            }
            else
            {
                form.TopMost = false;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.WindowState = FormWindowState.Normal;
                isFullscreen = false;
            }
        }

        #endregion

        #region Font Scaling
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        /// <summary>
        /// Scales the font of a specific control based on form dimensions, with minimum and maximum size limits.
        /// </summary>
        /// <param name="form">The parent form used to calculate scaling factors.</param>
        /// <param name="ctrl">The control whose font will be scaled.</param>
        /// <param name="baseFormHeight">The baseline height for scaling calculations (default: 480).</param>
        /// <param name="baseFormWidth">The baseline width for scaling calculations (default: 852).</param>
        /// <param name="minFontSize">The minimum font size allowed (default: 6f).</param>
        /// <param name="maxFontSize">The maximum font size allowed (default: 48f).</param>
        public void ScaleFont(Form form, Control ctrl, int baseFormHeight = defaultBaseFormHeight, int baseFormWidth = defaultBaseFormWidth, float minFontSize = defaultMinFontSize, float maxFontSize = defaultMaxFontSize)
        {
            if (!originalFontSizes.ContainsKey(ctrl))
                originalFontSizes[ctrl] = ctrl.Font.Size;

            float originalSize = originalFontSizes[ctrl];

            float scaleY = (float)form.Height / baseFormHeight;
            float scaleX = (float)form.Width / baseFormWidth;

            float scaleFactor = Math.Min(scaleX, scaleY);

            float newSize = originalSize * scaleFactor;
            newSize = Math.Max(minFontSize, Math.Min(maxFontSize, newSize));

            ctrl.Font = new Font(ctrl.Font.FontFamily, newSize, ctrl.Font.Style);
        }

        /// <summary>
        /// Scales all text controls on the form recursively based on form dimensions, with minimum and maximum size limits.
        /// </summary>
        /// <param name="form">The form whose controls will have their fonts scaled.</param>
        /// <param name="baseFormHeight">The baseline height for scaling calculations.</param>
        /// <param name="baseFormWidth">The baseline width for scaling calculations.</param>
        /// <param name="minFontSize">The minimum font size allowed.</param>
        /// <param name="maxFontSize">The maximum font size allowed.</param>
        public void ScaleAllFonts(
            Form form, int baseFormHeight = defaultBaseFormHeight, int baseFormWidth = defaultBaseFormWidth, float minFontSize = defaultMinFontSize, float maxFontSize = defaultMaxFontSize)
        {
            ScaleAllFontsRecursive(form, form, baseFormHeight, baseFormWidth, minFontSize, maxFontSize);
        }

        /// <summary>
        /// Recursively scales fonts for a control and all its children.
        /// </summary>
        /// <param name="form">The parent form used to calculate scaling factors.</param>
        /// <param name="ctrl">The control to process, including its child controls.</param>
        /// <param name="baseFormHeight">The baseline height for scaling calculations.</param>
        /// <param name="baseFormWidth">The baseline width for scaling calculations.</param>
        /// <param name="minFontSize">The minimum font size allowed.</param>
        /// <param name="maxFontSize">The maximum font size allowed.</param>
        private void ScaleAllFontsRecursive(Form form, Control ctrl, int baseFormHeight, int baseFormWidth, float minFontSize, float maxFontSize)
        {
            // Skip controls that don't scale well with standard font scaling
            if (!ShouldSkipFontScaling(ctrl) && !string.IsNullOrEmpty(ctrl.Text))
                ScaleFont(form, ctrl, baseFormHeight, baseFormWidth, minFontSize, maxFontSize);

            foreach (Control child in ctrl.Controls)
                ScaleAllFontsRecursive(form, child, baseFormHeight, baseFormWidth, minFontSize, maxFontSize);
        }
        #endregion

        #region Other Scaling

        private Size originalFormSize;
        private Dictionary<Control, ControlState> initialStates = new Dictionary<Control, ControlState>();

        /// <summary>
        /// Internal class to store the original state of a control for scaling calculations.
        /// </summary>
        private class ControlState
        {
            public Rectangle Bounds { get; set; }
            public float FontSize { get; set; }
        }

        /// <summary>
        /// Captures the initial state of all TextBox controls on the form for scaling purposes.
        /// This method stores the original size, position, and font size of each TextBox control
        /// to enable proper scaling when the form is resized.
        /// 
        /// Note: Call this method once during form initialization before any resizing occurs.
        /// </summary>
        /// <param name="form">The form whose TextBox controls should be captured</param>
        public void CaptureTextBoxStates(Form form)
        {
            originalFormSize = form.Size;
            initialStates.Clear();
            CaptureTextBoxStatesRecursive(form);
        }

        /// <summary>
        /// Recursively traverses the control hierarchy to find and capture all TextBox controls.
        /// </summary>
        /// <param name="parent">The parent control to search within</param>
        private void CaptureTextBoxStatesRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBoxBase)
                    initialStates[control] = new ControlState
                    {
                        Bounds = control.Bounds,
                        FontSize = control.Font.Size
                    };
                
                if (control.HasChildren)
                    CaptureTextBoxStatesRecursive(control);
            }
        }

        /// <summary>
        /// Scales TextBox controls proportionally based on form size changes.
        /// This method adjusts the position, size, and font of TextBox controls to maintain
        /// proper appearance when the form is resized.
        /// 
        /// Features:
        /// - Scales font size with min/max bounds to ensure readability
        /// - Proportionally scales width and position
        /// - Handles single-line TextBoxes (auto-height based on font)
        /// - Handles multi-line TextBoxes (scales height as well)
        /// 
        /// Note: CaptureTextBoxStates() must be called first to establish baseline measurements.
        /// </summary>
        /// <param name="form">The form whose TextBox controls should be scaled</param>
        public void ScaleTextBoxes(Form form)
        {
            // Safety check to prevent divide-by-zero errors
            if (originalFormSize.Width == 0 || originalFormSize.Height == 0) return;
            if (form.WindowState == FormWindowState.Minimized) return;

            // Calculate scale factors based on form size change
            float xRatio = (float)form.Width / originalFormSize.Width;
            float yRatio = (float)form.Height / originalFormSize.Height;

            // Use the smaller ratio for font scaling to prevent distortion
            float fontRatio = Math.Min(xRatio, yRatio);

            foreach (var entry in initialStates)
            {
                Control control = entry.Key;
                ControlState state = entry.Value;

                if (control is TextBoxBase textBoxBase)
                {
                    // Scale font size with bounds to maintain readability
                    float newFontSize = state.FontSize * fontRatio;
                    newFontSize = Math.Max(defaultMinFontSize, Math.Min(defaultMaxFontSize, newFontSize));

                    control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);

                    // Scale position
                    int newX = (int)(state.Bounds.X * xRatio);
                    int newY = (int)(state.Bounds.Y * yRatio);

                    int newWidth = (int)(state.Bounds.Width * xRatio);

                    // Apply scaled dimensions
                    if (!textBoxBase.Multiline)
                    {
                        // Single-line: Only set location and width
                        // Height is automatically determined by font size
                        control.Location = new Point(newX, newY);
                        control.Width = newWidth;
                    }
                    else
                    {
                        // Multi-line: Scale height as well
                        int newHeight = (int)(state.Bounds.Height * yRatio);
                        control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Excludes TextBox controls from font scaling to prevent conflicts with manual size management.
        /// Returns true if the control should be excluded from font scaling.
        /// </summary>
        /// <param name="ctrl">The control to check</param>
        /// <returns>True if the control should skip font scaling</returns>
        private bool ShouldSkipFontScaling(Control ctrl)
        {
            // Skip TextBoxBase controls (TextBox, MaskedTextBox, RichTextBox)
            // as they don't scale well with the standard font scaling
            return ctrl is TextBoxBase;
        }

        #endregion
    }
}