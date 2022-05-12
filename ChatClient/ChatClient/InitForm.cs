﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class InitForm : UserControl
    {
        public MainForm mainForm;

        public InitForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void connectFormBtn_Click(object sender, EventArgs e)
        {
            if (Client.getInstance() != null)
            {
                MessageBox.Show("이미 접속되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mainForm.ShowPage(MainForm.TYPE_PAGE.CONNECT_SERVER);
        }

        private void setNameBtn_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(MainForm.TYPE_PAGE.SET_NAME);
        }

        public void LoadConnectState()
        {
            if(Client.getInstance() != null)
            {
                connectState.Text = Client.getInstance().Name;
            }
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            if(Client.getInstance() == null)
            {
                MessageBox.Show("먼저 서버와 연결해주세요.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if(Client.getInstance().Name == null)
            {
                MessageBox.Show("먼저 이름을 설정해주세요.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mainForm.ShowPage(MainForm.TYPE_PAGE.CHAT_PAGE);
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            LoadConnectState();
        }
    }
}
