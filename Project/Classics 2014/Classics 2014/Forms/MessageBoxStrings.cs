using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.MBox
{
    static class Generic
    {
        public static DialogResult Show(GenericMBoxType type)
        {
            DialogResult result = DialogResult.Cancel;
            switch (type)
            {
                case GenericMBoxType.CellNotValid:
                    result = MessageBox.Show("No valid cell selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.ClosingCheckNoSave:
                    result = MessageBox.Show("Are you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.ClosingCheckSave:
                    result = MessageBox.Show("Do you wish to save before exiting? Unsaved progress will be lost.", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.LandingAlreadyExists:
                    result = MessageBox.Show("A landing already exists in this cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.NoLandingSelected:
                    result = MessageBox.Show("Please select a landing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.NoScoreSelected:
                    result = MessageBox.Show("Please select a score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.SavingFailed:
                    result = MessageBox.Show("An error occured and saving was aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.RemoveCompetitor:
                    result = MessageBox.Show("Are you sure you wish to remove the selected competitor?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    break;
                case GenericMBoxType.RemoveCompetitors:
                    result = MessageBox.Show("Are you sure you wish to remove the selected competitors?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    break;
            }
            return result;
        }
    }

    enum GenericMBoxType
    {
        CellNotValid,
        NoLandingSelected,
        NoScoreSelected,
        LandingAlreadyExists,
        ClosingCheckSave,
        ClosingCheckNoSave,
        SavingFailed,
        RemoveCompetitor,
        RemoveCompetitors,
    }
}
