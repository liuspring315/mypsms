using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace psms
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm;

        public MainForm()
        {
            mainForm = this;
            InitializeComponent();
        }

        #region Form_Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            SkinClass.AddSkinMenu(this.skinToolStripMenuItem);
            StartForm startForm = new StartForm();
            if (startForm.ShowDialog(this) == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }

        }
        #endregion 

        #region ϵͳά������
        //����Ʒ������Ϣά������
        private void preInfoReformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(0);
        }

        //����Ʒϵ����Ϣά��
        private void preToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(1);
        }

        //��ⵥλ��Ϣά��
        private void inGroupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(2);
        }

        //�ջ���λ��Ϣά��
        private void getGroupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(3);
        }

        //���쵥λ��Ϣά��
        private void deptInfoReformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(4);
        }

        //�û���¼��Ϣά��
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(5);
        }



        private void showSetInfoForm(int tabPagesIndex)
        {
            SetInfoForm setInfoForm = new SetInfoForm();
            setInfoForm.SetInfoTabControl.SelectedTab = setInfoForm.SetInfoTabControl.TabPages[tabPagesIndex];
            setInfoForm.Show();
            this.Hide();
        }
        #endregion


        #region �����ƾ֤¼��
        private void intableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInOutTableForm(0);
        }

        private void outtableINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInOutTableForm(1);
        }

        private void inTableResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInOutTableForm(2);
        }
        private void showInOutTableForm(int tabPagesIndex)
        {
            InOutTableForm inOutTableForm = new InOutTableForm();
            inOutTableForm.InOutTabletabControl.SelectedTab = inOutTableForm.InOutTabletabControl.TabPages[tabPagesIndex];
            inOutTableForm.Show();
            this.Hide();
        }
        #endregion



        #region ���ƾ֤�޸����


        private void inTableUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInTableForm updateIntableForm = new UpdateInTableForm();
            updateIntableForm.Show();
            this.Hide();
        }
        #endregion

        #region ����ƾ֤�޸����
        private void outTableUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOutTableForm updateOutTableForm = new UpdateOutTableForm();
            updateOutTableForm.Show();
            this.Hide();
        }
        #endregion



        #region ����Ʒ�̴����
        private void checkTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckTableForm checkTableForm = new CheckTableForm();
            checkTableForm.Show();
            this.Hide();
        }
         #endregion

        #region ����ͳ�����
        
        
        private void inOutTableSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showStatInOutTableForm(0);
        }

        private void vipPrcSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showStatInOutTableForm(1);
        }

        private void bumenlingquSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showStatInOutTableForm(2);
        }

        private void inoutSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showStatInOutTableForm(3);
        }

        private void showStatInOutTableForm(int tabPagesIndex)
        {
            StatInOutTableForm statInOutTableForm = new StatInOutTableForm();
            statInOutTableForm.TabControlStat.SelectedTab = statInOutTableForm.TabControlStat.TabPages[tabPagesIndex];
            statInOutTableForm.Show();
            this.Hide();
        }

        #endregion

        #region �������
        
       
        private void accToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InOutACCForm inoutAccForm = new InOutACCForm();
            inoutAccForm.Show();
            this.Hide();

        }
        #endregion



        #region ���ƾ֤��ѯ���
        
        
        private void intablequeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryInTableForm queryInTableForm = new QueryInTableForm();
            queryInTableForm.Show();
            this.Hide();
        }
        #endregion

        #region ����ƾ֤��ѯ���
        
        
        private void outTableQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryOutTableForm queryOutTableForm = new QueryOutTableForm();
            queryOutTableForm.Show();
            this.Hide();
        }
        #endregion

        #region ��ǰ����ѯ���
        
       
        private void accQntQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryPreInfoForm queryPerInfoForm = new QueryPreInfoForm();
            queryPerInfoForm.Show();
            this.Hide();
        }
        #endregion

        #region �̴��¼��ѯ���
        private void preAccQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryCheckTableForm queryCheckTableForm = new QueryCheckTableForm();
            queryCheckTableForm.Show();
            this.Hide();
        }
         #endregion




        #region ����Ʒ����嵥���
        private void inTableReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InTableReportForm intableReportForm = new InTableReportForm();
            intableReportForm.Show();
            this.Hide();
        }
        #endregion

        #region ����Ʒ�����嵥���
        private void outTableReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutTableReportForm outTableReportForm = new OutTableReportForm();
            outTableReportForm.Show();
            this.Hide();
        }
        #endregion

        #region ����Ʒ�����嵥���
        private void preInfoVipouReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VipOuReportForm vipOuReportForm = new VipOuReportForm();
            vipOuReportForm.Show();
            this.Hide();
        }
        #endregion

        #region ����Ʒ�����嵥���
        private void preInfooutouReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutOuReportForm outOuReportForm = new OutOuReportForm();
            outOuReportForm.Show();
            this.Hide();
        }

        #endregion

        #region ����Ʒ�������嵥���
        private void inoutReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InOutReportForm inOutReportForm = new InOutReportForm();
            inOutReportForm.Show();
            this.Hide();
        }
        #endregion

        private void exitloginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryPreInfoForm queryPerInfoForm = new QueryPreInfoForm();
            queryPerInfoForm.Show();
            this.Hide();
        }

        private void tuikuTableReportToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TuiKuTableReportForm tuikutableReportForm = new TuiKuTableReportForm();
            tuikutableReportForm.Show();
            this.Hide();
        }

        private void LogFormStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.Show();
            this.Hide();
        }

    }
}