//-----------------------------------------------------------------------
// <copyright file="AuthorizationForm.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleScrobbler
{
    public partial class AuthorizationForm : Form
    {
        private string _link;

        public AuthorizationForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;
        }

        public AuthorizationForm(string link)
            : this()
        {
            _link = link;
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            btnContinue.Enabled = true;
            btnAuthorize.Enabled = false;

            if (!string.IsNullOrWhiteSpace(_link))
            {
                Process.Start(_link);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
