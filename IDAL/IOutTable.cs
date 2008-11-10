using System.Collections.Generic;

//References to psms specific libraries
//psms busOutes entity library
using psms.Model;
using System.Data;

namespace psms.IDAL
{
    /// <summary>
    /// Outterface to the OutTable DAL
    /// </summary>
    public interface IOutTable
    {

        /// <summary>
        /// </summary>
        /// <returns>Outterface to Model Collection Generic of the results</returns>
        IList<OutTableInfo> GetAllOutTable();

        bool updateOutTable(OutTableInfo data);

        bool insertOutTable(OutTableInfo data);


        IList<OutTableInfo> GetOutTableByCondition(string condition);

        /// <summary>
        /// ƾ֤����ͳ��
        /// </summary>
        /// <returns></returns>
        DataTable GetOutTableForStatQntSum(string startTime, string endTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetOutTableForSUM(string startTime, string endTime, string condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetOutTableForStatQntSum(string startTime, string endTime, string condition);


        /// <summary>
        /// ����ȡ��Ʒ��λ����
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<IList<string>> GetStatOutTableGroupByOutOuByCon(string condition);


        /// <summary>
        /// ��������ͳ�����еĳ�������
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetStatOutTableAllOutOuByCon(string condition);

        /// <summary>
        /// ����ͳ�Ʊ���
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetOutTableDataTableForStatQntSum(string startTime, string endTime, string condition);


        /// <summary>
        /// ����ȡ��Ʒ��λ���� ���ڲ�����ȡ���ͳ�Ʊ���
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetStatOutOuGroupByOutOuByCon(string condition);

        /// <summary>
        /// ����ȡ��Ʒ��λ���� �����������ͳ�Ʊ���
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable GetStatVipOuGroupByOutOuByCon(string condition);


        /// <summary>
        /// ƾ֤����ͳ��
        /// </summary>
        /// <returns></returns>
        
        DataTable GetOutTableForStatQntSum(string condition);

        /// <summary>
        /// �õ����ĳ���ƾ֤���
        /// </summary>
        /// <returns></returns>
        
        string GetTopOutScrpNo();



        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="out_scrpno"></param>
        /// <returns></returns>
        bool deleteOutTable(string out_scrpno);




    }
}
