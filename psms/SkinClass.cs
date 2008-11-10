using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data; 

namespace psms
{

    class SkinClass
    {
        public static Sunisoft.IrisSkin.SkinEngine se = null;
        /// <summary>
        /// ���ӻ����˵�
        /// </summary>
        /// <param name="toolMenu"></param>
        public static void AddSkinMenu(ToolStripMenuItem toolMenu)
        {
            DataSet skin = new DataSet();
            try
            {

                skin.ReadXml("skin.xml", XmlReadMode.Auto);
            }
            catch
            {

            }
            if (skin == null || skin.Tables.Count < 1)
            {
                skin = new DataSet();
                skin.Tables.Add("skin");
                skin.Tables["skin"].Columns.Add("style");
                System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                dr[0] = "ϵͳĬ��";
                skin.Tables[0].Rows.Add(dr);
                skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);
            }
            foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
            {
                toolMenu.DropDownItems.Add(new ToolStripMenuItem(st.ToString()));

                toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1].Click += new EventHandler(frm_Main_Click);
                if (st.ToString() == skin.Tables[0].Rows[0][0].ToString())
                {
                    ((ToolStripMenuItem)toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1]).Checked = true;
                    frm_Main_Click(toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1], null);

                }

            }

            toolMenu.DropDownItems.Add(new ToolStripMenuItem("ϵͳĬ��"));
            toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1].Click += new EventHandler(frm_Main_Click);
            if (skin.Tables[0].Rows[0][0].ToString() == "ϵͳĬ��")
            {
                ((ToolStripMenuItem)toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1]).Checked = true;
            }
        }
        static void frm_Main_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)sender).Text == ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text)
                {
                    ((ToolStripMenuItem)sender).CheckState = CheckState.Checked;
                    DataSet skin = new DataSet();
                    skin.Tables.Add("skin");
                    skin.Tables["skin"].Columns.Add("style");
                    System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                    dr[0] = ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text;
                    skin.Tables[0].Rows.Add(dr);
                    skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);

                }
                else
                {
                    ((ToolStripMenuItem)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i]).CheckState = CheckState.Unchecked;
                }
            }
            if (((ToolStripMenuItem)sender).Text == "ϵͳĬ��")
            {
                RemoveSkin();
                DataSet skin = new DataSet();
                skin.Tables.Add("skin");
                skin.Tables["skin"].Columns.Add("style");
                System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                dr[0] = "ϵͳĬ��";
                skin.Tables[0].Rows.Add(dr);
                skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);
                return;
            }
            foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
            {
                if (st.ToString() == ((ToolStripMenuItem)sender).Text)
                {
                    ChangeSkin(st);
                    return;
                }
            }
        }
        /// <summary>
        /// �ı�Ƥ��
        /// </summary>
        /// <param name="st"></param>
        public static void ChangeSkin(SkinType st)
        {
            System.Reflection.Assembly thisDll = System.Reflection.Assembly.GetExecutingAssembly();
            if (se == null)
            {
                //TestSkin��ָ�����ռ䣬��������Ի������Լ��ġ�
                se = new Sunisoft.IrisSkin.SkinEngine(Application.OpenForms[0], thisDll.GetManifestResourceStream("psms.skin." + st.ToString() + ".ssk"));
                se.Active = true;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    se.AddForm(Application.OpenForms[i]);
                }

            }
            else
            {
                //TestSkin��ָ�����ռ䣬��������Ի������Լ��ġ�
                se.SkinStream = thisDll.GetManifestResourceStream("psms.skin." + st.ToString() + ".ssk");
                se.Active = true;
            }
        }
        /// <summary>
        /// �Ƴ�Ƥ��
        /// </summary>
        public static void RemoveSkin()
        {
            if (se == null)
            {
                return;
            }
            else
            {
                se.Active = false;
            }
        }
    }
    /// <summary>
    /// ��������
    /// </summary>
    public enum SkinType
    {
        Calmness,
        DeepCyan,
        Eighteen,
        Emerald,
        GlassBrown,
        Longhorn,
        MacOS,
        Midsummer,
        MP10,
        MSN,
        OneBlue,
        Page,
        RealOne,
        Silver,
        SportsBlack,
        SteelBlack,
        vista1,
        Vista2,
        Warm,
        Wave,
        XPSilver
    }
}
