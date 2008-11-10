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


        #region 事件
        
       

        private void AddPreInfoForm_Load(object sender, EventArgs e)
        {
            //初始化宣传品系列下拉列表
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
                    MessageBox.Show("新增宣传品成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //事件通知
                    SelectionChangedEventArgs ee = new SelectionChangedEventArgs(p_no);
                    SelectionChanged(this, ee);
                    //关闭
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("新增宣传品出错，错误信息："+ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region 私有方法
        private bool validatePreInfoText()
        {
            string p_no = this.txtP_no.Text.Trim();
            if (p_no == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_no, "宣传品编号不能空");
                MessageBox.Show("宣传品编号不能空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (new BLL.PreInfo().GetPreInfoByNo(p_no, 0) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "此宣传品编号已经存在");
                    MessageBox.Show("此宣传品编号已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (p_no.Length > 20)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "宣传品编号不能多于20字");
                    MessageBox.Show("宣传品编号不能多于20字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "宣传品名称不能为空");
                MessageBox.Show("宣传品名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (p_name.Length > 50)
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "宣传品名称不能多于50字");
                MessageBox.Show("宣传品名称不能多于50字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.SetPreInfoerrorProvider.SetError(this.txtUnit_price, "销售价应输入数字");
                MessageBox.Show("销售价应输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                Double.Parse(this.txtCost_price.Text.Trim());
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "");
            }
            catch
            {
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "成本价应输入数字");
                MessageBox.Show("成本价应输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion


        




    }



    public class SelectionChangedEventArgs : EventArgs
    {
        private string m_selection;

        //本属性用于传递事件数据
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