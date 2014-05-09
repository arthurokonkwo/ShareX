﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2014 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using HelpersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenCaptureLib
{
    public partial class FFmpegOptionsForm : Form
    {
        private FFmpegNetOptions Options;

        public FFmpegOptionsForm(FFmpegNetOptions options)
        {
            InitializeComponent();
            Options = options;
            this.Text = string.Format("{0} - FFmpeg Options", Application.ProductName);
            this.Icon = ShareXResources.Icon;

            comboBoxCodecs.Items.AddRange(Helpers.GetEnumDescriptions<FFmpegNetVideoCodec>());
            comboBoxCodecs.SelectedIndex = (int)options.VideoCodec;

            nudBitrate.Value = Options.BitRate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxCodecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.VideoCodec = (FFmpegNetVideoCodec)comboBoxCodecs.SelectedIndex;
        }

        private void nudBitrate_ValueChanged(object sender, EventArgs e)
        {
            Options.BitRate = (int)nudBitrate.Value;
        }
    }
}