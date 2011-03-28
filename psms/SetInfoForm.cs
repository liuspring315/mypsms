using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using psms.util;
using psms.Model;

namespace psms
{
    public partial class SetInfoForm : Form
    {

        public SetInfoForm()
        {
            InitializeComponent();
        }

        //tabControl��ǩ����
        public TabControl SetInfoTabControl
        {
            get { return this.setInfotabControl; }
        }

        //Form_load
        private void SetInfoForm_Load(object sender, EventArgs e)
        {
            //��ʼ������
            DataLoadBySelectTab();
        }

        //���ı��ǩѡ��ʱ�¼�
        private void setInfotabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��ʼ������
            DataLoadBySelectTab();
        }

        //��ʼ������
        private void DataLoadBySelectTab()
        {
            //������Ʒ��Ϣ��ǩ ��ʼ������
            if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[0])
            {
                setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                setTextValueFromDataGrid();
            }
            //������Ʒϵ�б�ǩ ��ʼ������
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[1])
            {
                setPreTypeDataGridViewDataSource();
                setPreTypeTextValueFromDataGrid();
            }
            //����ⵥλ��ǩ ��ʼ������
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[2])
            {
                setInInfoDataGridViewDataSource();
                setInInfoTextValueFromDataGrid();
            }
            //���ջ���λ��ǩ ��ʼ������
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[3])
            {
                setOutInfoDataGridViewDataSource();
                setOutInfoTextValueFromDataGrid();
            }
            //�����쵥λ��ǩ ��ʼ������
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[4])
            {
                setVipInfoDataGridViewDataSource();
                setVipInfoTextValueFromDataGrid();
            }
            //���û���Ϣ��ǩ ��ʼ������
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[5])
            {
                setLoginUserDataGridViewLoginUserDataSource();
                setLoginUserTextValueFromDataGrid();
            }
            
        }

        //���˴��ڹر���ʾ������
        private void SetInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        #region ����Ʒ��Ϣά��

        #region ����Ʒ��Ϣ˽���ֶ�
        //����Ʒid
        private int preId;
        //�޸ġ�������־
        private string upOrAdd = "";
        #endregion

        #region Ϊ����Ʒ��ϢDataGridView������Դ
        private void setPreDataGridViewDataSource(IList<PreInfoData> data)
        {
            try
            {
                this.PreDataGridView.DataSource = data;
                this.PreDataGridView.Columns["p_no"].DisplayIndex = 0;
                this.PreDataGridView.Columns["pretype"].DisplayIndex = 1;
                this.PreDataGridView.Columns["p_name"].DisplayIndex = 2;
                this.PreDataGridView.Columns["unit"].DisplayIndex = 3;
                this.PreDataGridView.Columns["unit_price"].DisplayIndex = 4;
                this.PreDataGridView.Columns["cost_price"].DisplayIndex = 5;
                this.PreDataGridView.Columns["acc_qnt"].DisplayIndex = 6;
                this.PreDataGridView.Columns["id"].DisplayIndex = 7;

                //��¼��
                this.groupBoxPreInfo.Text = "��������Ʒ��¼" + data.Count + "��";

                //��ʼ������Ʒϵ�������б�
                this.cobPreType.DataSource = new BLL.PreType().GetAllPreTypeInfo();
                this.cobPreType.DisplayMember = "typeName";
                this.cobPreType.ValueMember = "typeName";

                BindingList < PreTypeInfo >  preTypeList = new BLL.PreType().GetAllPreTypeInfo();
                preTypeList.Add(new PreTypeInfo(0,""));
                this.comboBoxQueryPreType.DataSource = preTypeList;
                this.comboBoxQueryPreType.DisplayMember = "typeName";
                this.comboBoxQueryPreType.ValueMember = "typeName";
                this.comboBoxQueryPreType.SelectedIndex = preTypeList.Count - 1;

            }
            catch (Exception ex)
            {
                Log.WriteLog("Ϊ����Ʒ��ϢDataGridView������Դ��������Ϣ��" + ex.ToString());
            }
            
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void PageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnPrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.LAST);
                }

                setTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                Log.WriteLog("������ť�����¼���������Ϣ��" + ex.ToString());
            }


        }

        //�޸İ�ť
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PreDataGridView.RowCount > 0)
                {
                    this.upOrAdd = StrUtil.UP;
                    //TextBox Enabled
                    setTxtEnabled(true);
                    //RowBtn Enabled
                    setBtnRow(false);
                    //Save and Cancel Button
                    setBtnSaveCancel(true);

                    this.txtP_no.Enabled = false;
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("û��Ҫ�޸ĵļ�¼");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("�޸İ�ť��������Ϣ��" + ex.ToString());
            }

        }

        //ɾ����ť�¼�
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.preId == 0)
                {
                    MessageBox.Show("��ѡ��Ҫɾ��������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ��������Ʒ��¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        BLL.PreInfo preInfoBll = new BLL.PreInfo();
                        if (preInfoBll.haveInOutScrpByPno(this.preId))
                        {
                            MessageBox.Show("Ҫɾ��������Ʒ�����ƾ֤���ڳ���ƾ֤���м�¼�����ܱ�ɾ��", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        preInfoBll.deletePerInfo(this.preId);
                        MessageBox.Show("ɾ������Ʒ��¼�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                        setTextValueFromDataGrid();
                        btnCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("ɾ������Ʒ��¼", ex);
            }
        }

        //������ť�¼�
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //TextBox Enabled
                setTxtEnabled(true);
                //RowBtn Enabled
                setBtnRow(false);
                //Save and Cancel Button
                setBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setTxtEmpty();
                this.upOrAdd = StrUtil.ADD;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("������ť�¼�", ex);
                return;
            }
        }

        //���水ť�¼�
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatePreInfoText())
                {

                    string p_no = this.txtP_no.Text.Trim();
                    string p_name = this.txtP_name.Text.Trim();
                    string unit = this.comboUnit.Text.ToString().Trim();
                    string unit_price = this.txtUnit_price.Text.Trim();
                    string cost_price = this.txtCost_price.Text.Trim();
                    string acc_qnt = this.txtAcc_qnt.Text.Trim();
                    string pretype = this.cobPreType.Text.ToString();

                    //
                    PreInfoData data = new PreInfoData(preId, p_no, pretype, p_name, unit, Decimal.Parse(unit_price), Decimal.Parse(cost_price), 0);


                    BLL.PreInfo preInfoBll = new psms.BLL.PreInfo();
                    if (this.upOrAdd == StrUtil.UP)
                    {
                        try
                        {
                            data.Acc_qnt = Int32.Parse(acc_qnt);
                            preInfoBll.updatePreInfo(data);
                            MessageBox.Show("�޸�����Ʒ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowErrorMessageBox("�޸�����Ʒ", ex);
                            return;
                        }

                    }
                    else if (this.upOrAdd == StrUtil.ADD)
                    {
                        try
                        {
                            preInfoBll.insertPreInfo(data);
                            this.preId = 0;
                            MessageBox.Show("��������Ʒ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowErrorMessageBox("��������Ʒ", ex);
                            return;
                        }
                    }

                    try
                    {
                        //���°�����
                        setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                        btnCancel_Click(sender, e);
                        //ѡ�и��µ���
                        DataGirdViewUtil.selectedRowByValue(this.PreDataGridView, "p_no", data.P_no);
                    }
                    catch (Exception ex)
                    {
                        MyMessageBox.ShowErrorMessageBox("���°�����", ex);
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��������Ʒ", ex);
                return;
            }
            
        }

        //ȡ����ť�¼�
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.upOrAdd = "";
                //TextBox Enabled
                setTxtEnabled(false);
                //RowBtn Enabled
                setBtnRow(true);
                //Save and Cancel Button
                setBtnSaveCancel(false);

                this.btnUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.getRowById(this.PreDataGridView, preId, "id");
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("ȡ����ť�¼�", ex);
                return;
            }

        }

        //����DataGrid��Ԫ���¼�
        private void PreDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setTextValueFromDataGrid();
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("ȡ����ť�¼�", ex);
                return;
            }
        }

        //�������ý���
        private void txtPreInfoQueryPNo_Enter(object sender, EventArgs e)
        {
            if (this.txtPreInfoQueryPNo.Text == "��������Ʒ���ģ������")
            {
                this.txtPreInfoQueryPNo.Text = "";
            }
        }
        //������ť�¼�
        private void btnPreInfoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                
                //IList<PreInfoData> data = new List<PreInfoData>();
                string pno = this.txtPreInfoQueryPNo.Text.Trim();
                StringBuilder condition = new StringBuilder(" where 1=1 ");
                if (pno != "" && pno != "��������Ʒ���ģ������")
                {
                    condition.Append(" and  (P_NO + p_NAME LIKE '%").Append(pno).Append("%')");

                }
                if (comboBoxQueryPreType.Text.Trim() != "")
                {
                    condition.Append(" and  (pretype = '").Append(comboBoxQueryPreType.Text.Trim()).Append("')");
                }
                //�ɱ���
                if (this.txtCostPrice1.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCostPrice1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("�ɱ�������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.cost_price >= ").Append(this.txtCostPrice1.Text.Trim());
                }
                if (this.txtCostPrice2.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCostPrice2.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("�ɱ�������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.cost_price <= ").Append(this.txtCostPrice2.Text.Trim());
                }
                //���ۼ�
                if (this.txtUnitPrice1.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnitPrice1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("���ۼ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.unit_price >= ").Append(this.txtUnitPrice1.Text.Trim());
                }
                if (this.txtUnitPrice2.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnitPrice2.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("���ۼ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.unit_price <= ").Append(this.txtUnitPrice2.Text.Trim());
                }
                BLL.PreInfo preInfoBll = new psms.BLL.PreInfo();
                IList<PreInfoData> preInfoData = preInfoBll.GetAllPreInfoByCondition(condition.ToString());
                setPreDataGridViewDataSource(preInfoData);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����", ex);
                return;
            }
        }

        #endregion
        
        #region ������֤
        private void txtP_no_Validating(object sender, CancelEventArgs e)
        {
        }
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
                if (new BLL.PreInfo().GetPreInfoByNo(p_no, preId) > 0)
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
            else if(p_name.Length > 50)
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
        private void btnSave_Validating(object sender, CancelEventArgs e)
        {
            txtP_no_Validating(sender, e);
        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setTextValueFromDataGrid()
        {
            try
            {
                if (this.PreDataGridView.RowCount > 0)
                {
                    this.txtP_no.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "p_no").Trim();
                    this.txtP_name.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "p_name").Trim();
                    this.comboUnit.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "unit").Trim();
                    this.txtUnit_price.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "unit_price").Trim();
                    this.txtCost_price.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "cost_price").Trim();
                    this.txtAcc_qnt.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "acc_qnt").Trim();
                    this.cobPreType.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "pretype").Trim();
                    this.preId = Int32.Parse(DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "id").Trim());
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("DataGrid���ݵ�����ʾ��TextBox", ex);
            }
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setBtnSaveCancel(bool enable)
        {
            this.btnSave.Enabled = enable;
            this.btnCancel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setTxtEnabled(bool enable)
        {
            this.txtP_no.Enabled = enable;
            this.txtP_name.Enabled = enable;
            this.comboUnit.Enabled = enable;
            this.txtUnit_price.Enabled = enable;
            this.txtCost_price.Enabled = enable;
            this.txtAcc_qnt.Enabled = enable;
            this.cobPreType.Enabled = enable;
        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setTxtEmpty()
        {
            this.txtP_no.Text = "";
            this.txtP_name.Text = "";
            this.comboUnit.SelectedItem = this.comboUnit.Items[this.comboUnit.FindString("��")];
            this.txtUnit_price.Text = "";
            this.txtCost_price.Text = "0.00";
            this.txtAcc_qnt.Text = "0";
            this.cobPreType.SelectedIndex = 0;
        }
        #endregion

        #region ������ť����������
        private void setBtnRow(bool enable)
        {
            this.btnLast.Enabled = enable;
            this.btnNext.Enabled = enable;
            this.btnOne.Enabled = enable;
            this.btnPrv.Enabled = enable;
            this.btnUpdate.Enabled = enable;
            this.btnAdd.Enabled = enable;
            this.btnDel.Enabled = enable;
            this.PreDataGridView.Enabled = enable;
            
        }
        #endregion
        
        #endregion

        #region ��ⵥλ��Ϣά��

        private string inInfoUpOrAdd = "";

        #region Ϊ��ⵥλ��ϢDataGridView������Դ

        private void setInInfoDataGridViewDataSource()
        {
            BLL.InInfo inInfoBll = new psms.BLL.InInfo();
            IList<InInfoData> data = inInfoBll.GetAllInInfo();
            this.dataGridViewInInfo.DataSource = data;
            this.dataGridViewInInfo.Columns["in_ou"].DisplayIndex = 0;

            this.groupBoxInInfo.Text = "������ⵥλ��¼" + data.Count + "��";
        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setInInfoTextValueFromDataGrid()
        {
            this.txtIn_ou.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInInfo, "in_ou").Trim();
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void InInfoPageButton_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (btnName == "btnInInfoOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.ONE);
            }
            else if (btnName == "btnInInfoPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.PRV);
            }
            else if (btnName == "btnInInfoNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.NEXT);
            }
            else if (btnName == "btnInInfoLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.LAST);
            }

            setInInfoTextValueFromDataGrid();


        }

        //�޸İ�ť
        private void btnInInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setInInfoTxtEnabled(true);
                //RowBtn Enabled
                setInInfoBtnRow(false);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ⵥλ��Ϣά���޸İ�ť�����¼�", ex);
            }

        }

        //ɾ����ť�¼�
        private void btnInInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIn_ou.Text.Trim() == "")
                {
                    MessageBox.Show("��ѡ��Ҫɾ������ⵥλ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ������ⵥλ��¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.InInfo().deleteInInfo(this.txtIn_ou.Text.Trim());
                        MessageBox.Show("ɾ����ⵥλ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setInInfoDataGridViewDataSource();
                        btnInInfoCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ⵥλɾ���¼�", ex);
            }
        }

        //������ť�¼�
        private void btnInInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setInInfoTxtEnabled(true);
                //RowBtn Enabled
                setInInfoBtnRow(false);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setInInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ⵥλ�����¼�", ex);
            }
        }

        //���水ť�¼�
        private void btnInInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                string in_ou = this.txtIn_ou.Text.Trim();
                if (in_ou == "")
                {
                    MessageBox.Show("��ⵥλ���Ʋ���Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (in_ou.Length > 10)
                {
                    MessageBox.Show("��ⵥλ���Ʋ��ܶ���10���֣�������" + in_ou.Length + "����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.InInfo inInfoBll = new psms.BLL.InInfo();
                if (inInfoBll.GetInInfoByInou(in_ou) > 0)
                {
                    MessageBox.Show("��ⵥλ�����Ѵ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.inInfoUpOrAdd == StrUtil.UP)
                {
                    string in_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInInfo, "in_ou").Trim();
                    inInfoBll.updateInInfo(in_ou, in_ou_old);
                    MessageBox.Show("�޸���ⵥλ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.inInfoUpOrAdd == StrUtil.ADD)
                {
                    inInfoBll.insertInInfo(in_ou);
                    MessageBox.Show("������ⵥλ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //���°�����
                setInInfoDataGridViewDataSource();
                btnInInfoCancel_Click(sender, e);
                //ѡ�м�¼
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewInInfo, "in_ou",in_ou);
                setInInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ⵥλ�����¼�", ex);
            }
        }

        //ȡ����ť�¼�
        private void btnInInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = "";
                //TextBox Enabled
                setInInfoTxtEnabled(false);
                //RowBtn Enabled
                setInInfoBtnRow(true);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(false);

                this.btnInInfoUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo,-1);
                setInInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ⵥλȡ���¼�", ex);
            }

        }
        //����DataGrid��Ԫ���¼�
        private void dataGridViewInInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setInInfoTextValueFromDataGrid();
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setInInfoBtnSaveCancel(bool enable)
        {
            this.btnInInfoSave.Enabled = enable;
            this.btnInInfoCancel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setInInfoTxtEnabled(bool enable)
        {
            this.txtIn_ou.Enabled = enable;
        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setInInfoTxtEmpty()
        {
            this.txtIn_ou.Text = "";
        }
        #endregion

        #region dao����ť����������
        private void setInInfoBtnRow(bool enable)
        {
            this.btnInInfoLast.Enabled = enable;
            this.btnInInfoNext.Enabled = enable;
            this.btnInInfoOne.Enabled = enable;
            this.btnInInfoPrv.Enabled = enable;
            this.btnInInfoAdd.Enabled = enable;
            this.btnInInfoUpdate.Enabled = enable;
            this.btnInInfoDelete.Enabled = enable;
            this.dataGridViewInInfo.Enabled = enable;
        }
        #endregion

        #endregion

        #region ����Ʒϵ����Ϣά��

        private string preTypeUpOrAdd = "";

        #region Ϊ����Ʒϵ����ϢDataGridView������Դ

        private void setPreTypeDataGridViewDataSource()
        {
            BLL.PreType preTypeBll = new psms.BLL.PreType();
            
            IList<PreTypeInfo> data = preTypeBll.GetAllPreTypeInfo();
            this.dataGridViewPreType.DataSource = data;
            this.dataGridViewPreType.Columns["typeName"].DisplayIndex = 0;
            this.dataGridViewPreType.Columns["code"].DisplayIndex = 1;

            this.groupBoxPerType.Text = "��������Ʒϵ�м�¼" + data.Count +"��";
        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setPreTypeTextValueFromDataGrid()
        {
            this.txtPreType.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "typename").Trim();
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void preTypePageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnPreTypeOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnPreTypePrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnPreTypeNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnPreTypeLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.LAST);
                }

                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("������ť�����¼�", ex);
            }


        }

        //�޸İ�ť
        private void btnPreTypeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setPreTypeTxtEnabled(true);
                //RowBtn Enabled
                setPreTypeBtnRow(false);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸İ�ť", ex);
            }

        }

        //ɾ����ť�¼�
        private void btnPreTypeDel_Click(object sender, EventArgs e)
        {
            try
            {
                string typeid = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "code").Trim();
                if (typeid == "")
                {
                    MessageBox.Show("��ѡ��Ҫɾ��������Ʒϵ��", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ��������Ʒϵ�м�¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.PreType().deletePerType(Int32.Parse(typeid));
                        MessageBox.Show("ɾ������Ʒϵ�гɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setPreTypeDataGridViewDataSource();
                        btnPreTypeCancel_Click(sender, e);
                        setPreTypeTextValueFromDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒϵ��ɾ����ť�¼�", ex);
            }
        }

        //������ť�¼�
        private void btnPreTypeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setPreTypeTxtEnabled(true);
                //RowBtn Enabled
                setPreTypeBtnRow(false);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setPreTypeTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒϵ��������ť�¼�", ex);
            }
        }

        //���水ť�¼�
        private void btnPreTypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                string pretype = this.txtPreType.Text.Trim();
                if (pretype == "")
                {
                    MessageBox.Show("����Ʒϵ�����Ʋ���Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (pretype.Length > 10)
                {
                    MessageBox.Show("����Ʒϵ�����Ʋ��ܶ���10���֣�������" + pretype.Length + "����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.PreType preTypeBll = new psms.BLL.PreType();
                if (preTypeBll.GetPreTypeByTypeName(pretype) > 0)
                {
                    MessageBox.Show("����Ʒϵ�������Ѿ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.preTypeUpOrAdd == StrUtil.UP)
                {
                    string typeid = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "code").Trim();
                    preTypeBll.updatePreType(pretype, Int32.Parse(typeid));
                    MessageBox.Show("�޸�����Ʒϵ�гɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.preTypeUpOrAdd == StrUtil.ADD)
                {
                    preTypeBll.insertPreType(pretype);
                    MessageBox.Show("��������Ʒϵ�гɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //���°�����
                setPreTypeDataGridViewDataSource();
                btnPreTypeCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewPreType, "typename", pretype);
                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒϵ�б��水ť�¼�", ex);
            }
        }

        //ȡ����ť�¼�
        private void btnPreTypeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = "";
                //TextBox Enabled
                setPreTypeTxtEnabled(false);
                //RowBtn Enabled
                setPreTypeBtnRow(true);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(false);

                this.btnPreTypeUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.getRowById(this.dataGridViewPreType, 0, "typeid");
                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒϵ��ȡ����ť�¼�", ex);
            }

        }
        //����DataGrid��Ԫ���¼�
        private void dataGridViewPreType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setPreTypeTextValueFromDataGrid();
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒϵ�е���DataGrid��Ԫ���¼�", ex);
            }
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setPreTypeBtnSaveCancel(bool enable)
        {
            this.btnPreTypeSave.Enabled = enable;
            this.btnPreTypeConcel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setPreTypeTxtEnabled(bool enable)
        {
            this.txtPreType.Enabled = enable;
        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setPreTypeTxtEmpty()
        {
            this.txtPreType.Text = "";
        }
        #endregion

        #region dao����ť����������
        private void setPreTypeBtnRow(bool enable)
        {
            this.btnPreTypeLast.Enabled = enable;
            this.btnPreTypeNext.Enabled = enable;
            this.btnPreTypeOne.Enabled = enable;
            this.btnPreTypePrv.Enabled = enable;
            this.btnPreTypeAdd.Enabled = enable;
            this.btnPreTypeDel.Enabled = enable;
            this.btnPreTypeUpdate.Enabled = enable;
            this.dataGridViewPreType.Enabled = enable;
        }
        #endregion



        #endregion

        #region �ջ���λ��Ϣά��

        private string outInfoUpOrAdd = "";

        #region Ϊ���쵥λ��ϢDataGridView������Դ

        private void setOutInfoDataGridViewDataSource()
        {
            BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
            IList<OutInfoData> data = outInfoBll.GetAllOutInfo();
            this.dataGridViewOutInfo.DataSource = data;
            this.dataGridViewOutInfo.Columns["out_ou"].DisplayIndex = 0;

            this.groupBoxOutInfo.Text = "�������쵥λ��¼" + data.Count + "��";
        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setOutInfoTextValueFromDataGrid()
        {
            this.txtOutInfo.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewOutInfo, "out_ou").Trim();
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void OutInfoPageButton_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (btnName == "btnOutInfoOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.ONE);
            }
            else if (btnName == "btnOutInfoPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.PRV);
            }
            else if (btnName == "btnOutInfoNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.NEXT);
            }
            else if (btnName == "btnOutInfoLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.LAST);
            }

            setOutInfoTextValueFromDataGrid();


        }

        //�޸İ�ť
        private void btnOutInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setOutInfoTxtEnabled(true);
                //RowBtn Enabled
                setOutInfoBtnRow(false);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���쵥λ�޸İ�ť�����¼�", ex);
            }

        }

        //ɾ����ť�¼�
        private void btnOutInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtOutInfo.Text.Trim() == "")
                {
                    MessageBox.Show("��ѡ��Ҫɾ�������쵥λ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ�������쵥λ��¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.OutInfo().deleteOutInfo(this.txtOutInfo.Text.Trim());
                        MessageBox.Show("ɾ�����쵥λ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setOutInfoDataGridViewDataSource();
                        btnOutInfoCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���쵥λɾ����ť�����¼�", ex);
            }
        }

        //������ť�¼�
        private void btnOutInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setOutInfoTxtEnabled(true);
                //RowBtn Enabled
                setOutInfoBtnRow(false);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setOutInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���쵥λ������ť�����¼�", ex);
            }
        }

        //���水ť�¼�
        private void btnOutInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                string out_ou = this.txtOutInfo.Text.Trim();
                if (out_ou == "")
                {
                    MessageBox.Show("���쵥λ���Ʋ���Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (out_ou.Length > 10)
                {
                    MessageBox.Show("���쵥λ���Ʋ��ܶ���10���֣�������" + out_ou.Length + "����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
                if (outInfoBll.GetOutInfoByOutou(out_ou) > 0)
                {
                    MessageBox.Show("���쵥λ�����Ѵ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.outInfoUpOrAdd == StrUtil.UP)
                {
                    string out_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewOutInfo, "out_ou").Trim();
                    outInfoBll.updateOutInfo(out_ou, out_ou_old);
                    MessageBox.Show("�޸����쵥λ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.outInfoUpOrAdd == StrUtil.ADD)
                {
                    outInfoBll.insertOutInfo(out_ou);
                    MessageBox.Show("�������쵥λ�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //���°�����
                setOutInfoDataGridViewDataSource();
                btnOutInfoCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewOutInfo, "out_ou", out_ou);
                setOutInfoTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���쵥λ���水ť�����¼�", ex);
            }
        }

        //ȡ����ť�¼�
        private void btnOutInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = "";
                //TextBox Enabled
                setOutInfoTxtEnabled(false);
                //RowBtn Enabled
                setOutInfoBtnRow(true);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(false);

                this.btnOutInfoUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, -1);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���쵥λȡ����ť�����¼�", ex);
            }

        }
        //����DataGrid��Ԫ���¼�
        private void dataGridViewOutInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setOutInfoTextValueFromDataGrid();
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setOutInfoBtnSaveCancel(bool enable)
        {
            this.btnOutInfoSave.Enabled = enable;
            this.btnOutInfoCancel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setOutInfoTxtEnabled(bool enable)
        {
            this.txtOutInfo.Enabled = enable;
        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setOutInfoTxtEmpty()
        {
            this.txtOutInfo.Text = "";
        }
        #endregion

        #region dao����ť����������
        private void setOutInfoBtnRow(bool enable)
        {
            this.btnOutInfoLast.Enabled = enable;
            this.btnOutInfoNext.Enabled = enable;
            this.btnOutInfoOne.Enabled = enable;
            this.btnOutInfoPrv.Enabled = enable;
            this.btnOutInfoAdd.Enabled = enable;
            this.btnOutInfoUpdate.Enabled = enable;
            this.btnOutInfoDel.Enabled = enable;
            this.dataGridViewOutInfo.Enabled = enable;
        }
        #endregion

        #endregion

        #region ���쵥λ��Ϣά��

        private string vipInfoUpOrAdd = "";

        #region Ϊ���쵥λ��ϢDataGridView������Դ

        private void setVipInfoDataGridViewDataSource()
        {
            BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
            IList<VipInfoData> data = vipInfoBll.GetAllVipInfo();
            this.dataGridViewVipInfo.DataSource = data;
            this.dataGridViewVipInfo.Columns["vip_ou"].DisplayIndex = 0;

            this.groupBoxVipInfo.Text = "�������ͷ����¼" + data.Count + "��";
        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setVipInfoTextValueFromDataGrid()
        {
            this.txtVipInfo.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewVipInfo, "vip_ou").Trim();
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void VipInfoPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnVipInfoOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnVipInfoPrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnVipInfoNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnVipInfoLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.LAST);
                }

                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ��ർ�������¼�", ex);
            }


        }

        //�޸İ�ť
        private void btnVipInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setVipInfoTxtEnabled(true);
                //RowBtn Enabled
                setVipInfoBtnRow(false);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ����޸İ�ť�����¼�", ex);
            }
        }

        //ɾ����ť�¼�
        private void btnVipInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtVipInfo.Text.Trim() == "")
                {
                    MessageBox.Show("��ѡ��Ҫɾ�������ͷ���", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ�������ͷ����¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.VipInfo().deleteVipInfo(this.txtVipInfo.Text.Trim());
                        MessageBox.Show("ɾ�����ͷ���ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setVipInfoDataGridViewDataSource();
                        btnVipInfoCancel_Click(sender, e);
                        setVipInfoTextValueFromDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ���ɾ����ť�����¼�", ex);
            }
        }

        //������ť�¼�
        private void btnVipInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setVipInfoTxtEnabled(true);
                //RowBtn Enabled
                setVipInfoBtnRow(false);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setVipInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ���������ť�����¼�", ex);
            }
        }

        //���水ť�¼�
        private void btnVipInfoSave_Click(object sender, EventArgs e)
        {
            try
            {

                string vip_ou = this.txtVipInfo.Text.Trim();
                if (vip_ou == "")
                {
                    MessageBox.Show("���ͷ������Ʋ���Ϊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (vip_ou.Length > 10)
                {
                    MessageBox.Show("���ͷ������Ʋ��ܶ���10���֣�������" + vip_ou.Length + "����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
                if (vipInfoBll.GetVipInfoByVipou(vip_ou) > 0)
                {
                    MessageBox.Show("���ͷ��������Ѵ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.vipInfoUpOrAdd == StrUtil.UP)
                {
                    string vip_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewVipInfo, "vip_ou").Trim();
                    vipInfoBll.updateVipInfo(vip_ou, vip_ou_old);
                    MessageBox.Show("�޸����ͷ���ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.vipInfoUpOrAdd == StrUtil.ADD)
                {
                    vipInfoBll.insertVipInfo(vip_ou);
                    MessageBox.Show("�������ͷ���ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //���°�����
                setVipInfoDataGridViewDataSource();
                btnVipInfoCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewVipInfo, "vip_ou", vip_ou);
                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ��ౣ�水ť�����¼�", ex);
            }
        }

        //ȡ����ť�¼�
        private void btnVipInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = "";
                //TextBox Enabled
                setVipInfoTxtEnabled(false);
                //RowBtn Enabled
                setVipInfoBtnRow(true);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(false);

                this.btnVipInfoUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo,-1);
                setVipInfoTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ���ȡ����ť�����¼�", ex);
            }

        }
        //����DataGrid��Ԫ���¼�
        private void dataGridViewVipInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ͷ��൥����Ԫ��ť�����¼�", ex);
            }
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setVipInfoBtnSaveCancel(bool enable)
        {
            this.btnVipInfoSave.Enabled = enable;
            this.btnVipInfoCancel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setVipInfoTxtEnabled(bool enable)
        {
            this.txtVipInfo.Enabled = enable;
        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setVipInfoTxtEmpty()
        {
            this.txtVipInfo.Text = "";
        }
        #endregion

        #region dao����ť����������
        private void setVipInfoBtnRow(bool enable)
        {
            this.btnVipInfoLast.Enabled = enable;
            this.btnVipInfoNext.Enabled = enable;
            this.btnVipInfoOne.Enabled = enable;
            this.btnVipInfoPrv.Enabled = enable;
            this.btnVipInfoAdd.Enabled = enable;
            this.btnVipInfoUpdate.Enabled = enable;
            this.btnVipInfoDel.Enabled = enable;
            this.dataGridViewVipInfo.Enabled = enable;
        }
        #endregion


        #endregion

        #region �û���Ϣά��

        #region �û���Ϣ˽���ֶ�
        //�û�id
        private int userId;
        //�޸ġ�������־
        private string loginUserUpOrAdd = "";
        #endregion

        #region Ϊ�û���ϢDataGridView������Դ
        private void setLoginUserDataGridViewLoginUserDataSource()
        {
            BLL.UserInfo userInfoBll = new psms.BLL.UserInfo();
            IList<UserInfoData> data = userInfoBll.GetAllUserInfo();
            this.dataGridViewLoginUser.DataSource = data;
            this.dataGridViewLoginUser.Columns["name"].DisplayIndex = 0;
            this.dataGridViewLoginUser.Columns["username"].DisplayIndex = 1;
            this.dataGridViewLoginUser.Columns["power"].DisplayIndex = 2;
            this.dataGridViewLoginUser.Columns["password"].DisplayIndex = 3;
            this.dataGridViewLoginUser.Columns["loginUserId"].DisplayIndex = 4;

            this.groupBoxLoginUser.Text = "�����û���¼" + data.Count + "��";

            //��ʼ���û�quanxian�����б�
           
        }
        #endregion

        #region �¼�
        //������ť�����¼�
        private void UserLoginPageButton_Click(object sender, EventArgs e)
        {
            string btnLoginUserName = ((Button)sender).Name;
            if (btnLoginUserName == "btnLoginUserOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.ONE);
            }
            else if (btnLoginUserName == "btnLoginUserPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.PRV);
            }
            else if (btnLoginUserName == "btnLoginUserNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.NEXT);
            }
            else if (btnLoginUserName == "btnLoginUserLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.LAST);
            }

            setLoginUserTextValueFromDataGrid();


        }

        //�޸İ�ť
        private void btnLoginUserUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.loginUserUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setLoginUserTxtEnabled(true);
                //RowBtn Enabled
                setLoginUserBtnRow(false);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û������޸İ�ť�����¼�", ex);
            }

        }

        //ɾ����ť�¼�
        private void btnLoginUserDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.userId == 0)
                {
                    MessageBox.Show("��ѡ��Ҫɾ�����û�", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("ȷ��ɾ�����û���¼��", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.UserInfo().deleteUserInfo(this.userId);
                        MessageBox.Show("ɾ���û��ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //���°�����
                        setLoginUserDataGridViewLoginUserDataSource();
                        btnLoginUserCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û�����ɾ����ť�����¼�", ex);
            }
        }

        //������ť�¼�
        private void btnLoginUserAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //TextBox Enabled
                setLoginUserTxtEnabled(true);
                //RowBtn Enabled
                setLoginUserBtnRow(false);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(true);

                this.btnLoginUserUpdate.Enabled = false;
                setLoginUserTxtEmpty();
                this.loginUserUpOrAdd = StrUtil.ADD;
                this.userId = 0;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û�����������ť�����¼�", ex);
            }
        }

        //���水ť�¼�
        private void btnLoginUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.txtLoginName.Text.Trim();
                string name = this.txtUserName.Text.Trim();
                string power = this.cobUserPower.Text.ToString();
                string password = this.txtPassword.Text.ToString().Trim();
                string password2 = this.txtPassword2.Text.ToString().Trim();
                if (password != password2)
                {
                    MessageBox.Show("�����������벻һ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (new BLL.UserInfo().GetUserInfoByNo(username, userId) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "���û������Ѿ�����");
                    MessageBox.Show("���û������Ѿ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "");
                }

                UserInfoData data = new UserInfoData(userId, username, name,password, power);
                BLL.UserInfo userInfoBll = new psms.BLL.UserInfo();
                if (this.loginUserUpOrAdd == StrUtil.UP)
                {
                    userInfoBll.updateUserInfo(data);
                    MessageBox.Show("�޸��û��ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.loginUserUpOrAdd == StrUtil.ADD)
                {
                    userInfoBll.insertUserInfo(data);
                    this.userId = 0;
                    MessageBox.Show("�����û��ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //���°�����
                setLoginUserDataGridViewLoginUserDataSource();
                btnLoginUserCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewLoginUser, "username", username);
                setLoginUserTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û������水ť�����¼�", ex);
            }
        }

        //ȡ����ť�¼�
        private void btnLoginUserCancel_Click(object sender, EventArgs e)
        {
            try
            {

                this.loginUserUpOrAdd = "";
                //TextBox Enabled
                setLoginUserTxtEnabled(false);
                //RowBtn Enabled
                setLoginUserBtnRow(true);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(false);

                this.btnLoginUserUpdate.Enabled = true;
                //ѡ�м�¼
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, -1);
                setLoginUserTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û�����ȡ����ť�����¼�", ex);
            }

        }

        //����DataGrid��Ԫ���¼�
        private void DataGridViewLoginUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setLoginUserTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�û�����Ԫ��ť�����¼�", ex);
            }
        }

        #endregion

        #region ������֤
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            if (username == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtUserName, "�û���Ų��ܿ�");
            }
            else
            {
                if (new BLL.UserInfo().GetUserInfoByNo(username, userId) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "���û�����Ѿ�����");
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "");
                }
            }



        }
        #endregion

        #region DataGrid���ݵ�����ʾ��TextBox
        private void setLoginUserTextValueFromDataGrid()
        {
            this.txtLoginName.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "username").Trim();
            this.txtUserName.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "name").Trim();
            
            this.cobUserPower.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "power").Trim();
            this.txtPassword.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "password").Trim();
            this.txtPassword2.Text = "";
            this.userId = Int32.Parse(DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "loginUserId").Trim());
        }
        #endregion

        #region ���� ȡ����ť����������
        private void setLoginUserBtnSaveCancel(bool enable)
        {
            this.btnLoginUserSave.Enabled = enable;
            this.btnLoginUserCancel.Enabled = enable;
        }

        #endregion

        #region �ı������������
        private void setLoginUserTxtEnabled(bool enable)
        {
            this.txtLoginName.Enabled = enable;
            this.txtUserName.Enabled = enable;
            this.cobUserPower.Enabled = enable;
            this.txtPassword.Enabled = enable;
            this.txtPassword2.Enabled = enable;

        }

        #endregion

        #region ʹ�ı���Ϊ��
        private void setLoginUserTxtEmpty()
        {
            this.txtUserName.Text = "";
            this.txtLoginName.Text = "";
            this.txtPassword2.Text = "";
            this.txtPassword.Text = "";
            this.cobUserPower.Text = "";
        }
        #endregion

        #region ������ť����������
        private void setLoginUserBtnRow(bool enable)
        {
            this.btnLoginUserLast.Enabled = enable;
            this.btnLoginUserNext.Enabled = enable;
            this.btnLoginUserOne.Enabled = enable;
            this.btnLoginUserPrv.Enabled = enable;
            this.btnLoginUserAdd.Enabled = enable;
            this.btnLoginUserDel.Enabled = enable;
            this.btnLoginUserUpdate.Enabled = enable;
            this.dataGridViewLoginUser.Enabled = enable;
        }
        #endregion


        #endregion



    }
}