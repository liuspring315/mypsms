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

        #region 系统维护窗口
        //宣传品基础信息维护窗口
        private void preInfoReformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(0);
        }

        //宣传品系列信息维护
        private void preToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(1);
        }

        //入库单位信息维护
        private void inGroupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(2);
        }

        //收货单位信息维护
        private void getGroupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(3);
        }

        //请领单位信息维护
        private void deptInfoReformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSetInfoForm(4);
        }

        //用户登录信息维护
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


        #region 出入库凭证录入
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



        #region 入库凭证修改入口


        private void inTableUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInTableForm updateIntableForm = new UpdateInTableForm();
            updateIntableForm.Show();
            this.Hide();
        }
        #endregion

        #region 出库凭证修改入口
        private void outTableUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOutTableForm updateOutTableForm = new UpdateOutTableForm();
            updateOutTableForm.Show();
            this.Hide();
        }
        #endregion



        #region 宣传品盘存入口
        private void checkTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckTableForm checkTableForm = new CheckTableForm();
            checkTableForm.Show();
            this.Hide();
        }
         #endregion

        #region 数据统计入口
        
        
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

        #region 作帐入口
        
       
        private void accToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InOutACCForm inoutAccForm = new InOutACCForm();
            inoutAccForm.Show();
            this.Hide();

        }
        #endregion



        #region 入库凭证查询入口
        
        
        private void intablequeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryInTableForm queryInTableForm = new QueryInTableForm();
            queryInTableForm.Show();
            this.Hide();
        }
        #endregion

        #region 出库凭证查询入口
        
        
        private void outTableQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryOutTableForm queryOutTableForm = new QueryOutTableForm();
            queryOutTableForm.Show();
            this.Hide();
        }
        #endregion

        #region 当前库存查询入口
        
       
        private void accQntQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryPreInfoForm queryPerInfoForm = new QueryPreInfoForm();
            queryPerInfoForm.Show();
            this.Hide();
        }
        #endregion

        #region 盘存记录查询入口
        private void preAccQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryCheckTableForm queryCheckTableForm = new QueryCheckTableForm();
            queryCheckTableForm.Show();
            this.Hide();
        }
         #endregion




        #region 宣传品入库清单入口
        private void inTableReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InTableReportForm intableReportForm = new InTableReportForm();
            intableReportForm.Show();
            this.Hide();
        }
        #endregion

        #region 宣传品出库清单入口
        private void outTableReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutTableReportForm outTableReportForm = new OutTableReportForm();
            outTableReportForm.Show();
            this.Hide();
        }
        #endregion

        #region 宣传品请领清单入口
        private void preInfoVipouReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VipOuReportForm vipOuReportForm = new VipOuReportForm();
            vipOuReportForm.Show();
            this.Hide();
        }
        #endregion

        #region 宣传品赠送清单入口
        private void preInfooutouReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutOuReportForm outOuReportForm = new OutOuReportForm();
            outOuReportForm.Show();
            this.Hide();
        }

        #endregion

        #region 宣传品进销存清单入口
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