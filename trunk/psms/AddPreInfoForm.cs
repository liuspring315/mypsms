using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using psms.Model;

namespace psms
{
    public partial class AddPreInfoForm : Form
    {
        public delegate void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e);
        public event SelectionChangedEventHandler SelectionChanged;

        public AddPreInfoForm()
        {
            InitializeComponent();
        }


        #region �¼�
        
       

        private void AddPreInfoForm_Load(object sender, EventArgs e)
        {
            //��ʼ������Ʒϵ�������б�
            this.cobPreType.DataSource = new BLL.PreType().GetAllPreTypeInfo();
            this.cobPreType.DisplayMember = "typeName";
            this.cobPreType.ValueMember = "code";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validatePreInfoText())
            {
                try
                {
                    string p_no = this.txtP_no.Text.Trim();
                    string p_name = this.txtP_name.Text.Trim();
                    string unit = this.comboUnit.Text.ToString().Trim();
                    string unit_price = this.txtUnit_price.Text.Trim();
                    string cost_price = this.txtCost_price.Text.Trim();
                    //string acc_qnt = this.txtAcc_qnt.Text.Trim();
                    string pretype = this.cobPreType.SelectedValue.ToString();

                    //
                    PreInfoData data = new PreInfoData(0, p_no, pretype, p_name, unit, Decimal.Parse(unit_price), Decimal.Parse(cost_price), 0);
                    BLL.PreInfo preInfoBll = new psms.BLL.PreInfo();

                    preInfoBll.insertPreInfo(data);
                    MessageBox.Show("��������Ʒ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //�¼�֪ͨ
                    SelectionChangedEventArgs ee = new SelectionChangedEventArgs(p_no);
                    SelectionChanged(this, ee);
                    //�ر�
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("��������Ʒ����������Ϣ��"+ex.Message, "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region ˽�з���
        private bool validatePreInfoText()
        {
            string p_no = this.txtP_no.Text.Trim();
            if (p_no == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_no, "����Ʒ��Ų��ܿ�");
                MessageBox.Show("����Ʒ��Ų��ܿ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (new BLL.PreInfo().GetPreInfoByNo(p_no, 0) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "������Ʒ����Ѿ�����");
                    MessageBox.Show("������Ʒ����Ѿ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (p_no.Length > 20)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "����Ʒ��Ų��ܶ���20��");
                    MessageBox.Show("����Ʒ��Ų��ܶ���20��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "");
                }
            }
            string p_name = this.txtP_name.Text.Trim();
            if (p_name == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "����Ʒ���Ʋ���Ϊ��");
                MessageBox.Show("����Ʒ���Ʋ���Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (p_name.Length > 50)
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "����Ʒ���Ʋ��ܶ���50��");
                MessageBox.Show("����Ʒ���Ʋ��ܶ���50��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "");
            }
            try
            {
                Double.Parse(this.txtUnit_price.Text.Trim());
                this.SetPreInfoerrorProvider.SetError(this.txtUnit_price, "");
            }
            catch
            {
                this.SetPreInfoerrorProvider.SetError(this.txtUnit_price, "���ۼ�Ӧ��������");
                MessageBox.Show("���ۼ�Ӧ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                Double.Parse(this.txtCost_price.Text.Trim());
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "");
            }
            catch
            {
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "�ɱ���Ӧ��������");
                MessageBox.Show("�ɱ���Ӧ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion


        




    }



    public class SelectionChangedEventArgs : EventArgs
    {
        private string m_selection;

        //���������ڴ����¼�����
        public string Selection
        {
            get { return m_selection; }
        }

        public SelectionChangedEventArgs(string selection)
        {
            m_selection = selection;
        }
    }

}