using System.Windows.Forms;

namespace MidChess.lib
{
    public class GameDialog
    {
        private const string APP_TITLE = "MidChess";

        #region Draw Dialogs

        /// <summary>
        /// Shows a draw offer dialog to the opponent.
        /// </summary>
        /// <returns>True if opponent accepts the draw</returns>
        public bool ShowDrawOfferReceivedDialog()
        {
            return MessageBox.Show("Your opponent offers a draw. Accept?", "Draw Offer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows info that draw was accepted.
        /// </summary>
        public void ShowDrawAcceptedMessage()
        {
            MessageBox.Show("Draw accepted. The game is a draw.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that opponent accepted the draw.
        /// </summary>
        public void ShowOpponentAcceptedDrawMessage()
        {
            MessageBox.Show("Your opponent accepted the draw. The game is a draw.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that draw was declined.
        /// </summary>
        public void ShowDrawDeclinedMessage()
        {
            MessageBox.Show("Your opponent declined the draw offer.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that draw offer was sent.
        /// </summary>
        public void ShowDrawOfferSentMessage()
        {
            MessageBox.Show("Draw offer sent. Waiting for opponent's response...", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Takeback Dialogs

        /// <summary>
        /// Shows a takeback offer dialog to the opponent.
        /// </summary>
        /// <returns>True if opponent accepts the takeback</returns>
        public bool ShowTakebackOfferReceivedDialog()
        {
            return MessageBox.Show("Your opponent requests a takeback. Accept?", "Takeback Request",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows info that takeback was accepted.
        /// </summary>
        public void ShowTakebackAcceptedMessage()
        {
            MessageBox.Show("Takeback accepted.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that opponent accepted the takeback.
        /// </summary>
        public void ShowOpponentAcceptedTakebackMessage()
        {
            MessageBox.Show("Your opponent accepted the takeback.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that takeback was declined.
        /// </summary>
        public void ShowTakebackDeclinedMessage()
        {
            MessageBox.Show("Your opponent declined the takeback request.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that takeback request was sent.
        /// </summary>
        public void ShowTakebackOfferSentMessage()
        {
            MessageBox.Show("Takeback request sent. Waiting for opponent's response...", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Resign & Disconnect Dialogs

        /// <summary>
        /// Shows confirmation for resign action.
        /// </summary>
        /// <returns>True if user confirms resignation</returns>
        public bool ShowResignConfirmation()
        {
            return MessageBox.Show("Do you really want to resign? It will count as a win for your opponent!",
                APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows resignation confirmation message.
        /// </summary>
        public void ShowResignationMessage()
        {
            MessageBox.Show("You have resigned. Your opponent wins.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that opponent resigned.
        /// </summary>
        public void ShowOpponentResignedMessage()
        {
            MessageBox.Show("Your opponent has resigned. You win!", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows info that opponent disconnected.
        /// </summary>
        public void ShowOpponentDisconnectedMessage()
        {
            MessageBox.Show("Your opponent has disconnected.", APP_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Exit & Navigation Dialogs

        /// <summary>
        /// Shows confirmation for leaving a game.
        /// </summary>
        /// <returns>True if user confirms leaving</returns>
        public bool ShowLeaveGameConfirmation()
        {
            return MessageBox.Show("Do you really want to quit? It will count as a resignation, your opponent will win!",
                APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows confirmation for quit with resign warning.
        /// </summary>
        /// <returns>True if user confirms quit</returns>
        public bool ShowQuitWithResignConfirmation()
        {
            return MessageBox.Show("Do you really want to quit? It will count as a resignation!",
                APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Shows return to main menu dialog.
        /// </summary>
        /// <returns>True if user wants to return to main menu</returns>
        public bool ShowReturnToMenuDialog()
        {
            return MessageBox.Show("Return to main menu?", APP_TITLE,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion
    }
}