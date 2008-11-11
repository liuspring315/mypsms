using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.Model;
using psms.util;

namespace psms
{
    public partial class StartForm : Form
    {
        IList<UserInfoData> userInfoList;

        public StartForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("�������¼����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (this.findUserAndPassword(this.comboBoxUserName.Text.Trim(), this.txtPassword.Text.Trim()))
                {
                }
                else
                {
                    MessageBox.Show("��������û��������벻��ȷ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û���¼",ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            try
            {
                setComboBoxPno(this.comboBoxUserName);
                setComboBoxPno(this.comboBoxUserName2);
                this.txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û���¼�����������ݿ����", ex);
            }
        }


        //��ʼ���û������б�
        private void setComboBoxPno(ComboBox combo)
        {
            this.userInfoList = new BLL.UserInfo().GetAllUserInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < userInfoList.Count; i++)
            {
                UserInfoData data = userInfoList[i];
                valueList.Add(new util.ValueObject(data.Username, data.Username));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        private bool findUserAndPassword(string userName, string passWord)
        {
            for (int i = 0; i < this.userInfoList.Count; i++)
            {
                UserInfoData data = userInfoList[i];
                if (data.Username == userName)
                {
                    if (data.Password == passWord)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.textBoxPassOld.Text = "";
            this.textBoxNewPass1.Text = "";
            this.textBoxNewPass2.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.findUserAndPassword(this.comboBoxUserName2.Text.Trim(), this.textBoxPassOld.Text.Trim()))
                {
                    if (this.textBoxNewPass1.Text.Trim() == "")
                    {
                        MessageBox.Show("�����벻��Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        if (this.textBoxNewPass1.Text.Trim() == this.textBoxNewPass2.Text.Trim())
                        {
                            UserInfoData data = this.getUserInfoByUserName(this.comboBoxUserName2.Text.Trim());
                            if (data != null)
                            {
                                BLL.UserInfo userInfoBll = new psms.BLL.UserInfo();
                                data.Password = this.textBoxNewPass1.Text.Trim();
                                new BLL.UserInfo().updateUserInfo(data);
                                setComboBoxPno(this.comboBoxUserName);
                                setComboBoxPno(this.comboBoxUserName2);
                                MessageBox.Show("�޸�����ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("û���ҵ����û�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("����������������벻��ͬ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("������ľ����벻��ȷ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸�����", ex);
            }
        }

        private UserInfoData getUserInfoByUserName(string userName)
        {
            for (int i = 0; i < this.userInfoList.Count; i++)
            {
                UserInfoData data = userInfoList[i];
                if (data.Username == userName)
                {
                    return data;
                }
            }
            return null;
        }

    }
}