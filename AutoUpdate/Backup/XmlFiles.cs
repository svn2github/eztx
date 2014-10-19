using System;
using System.IO;
using System.Xml;

namespace AutoUpdate
{
	/// <summary>
	/// XmlFiles ��ժҪ˵����
	/// </summary>
	public class XmlFiles:XmlDocument
	{
		#region �ֶ�������
		private string _xmlFileName;
		public string XmlFileName
		{
			set{_xmlFileName = value;}
			get{return _xmlFileName;}
		}
		#endregion

		public XmlFiles(string xmlFile)
		{
			XmlFileName = xmlFile;
			
			this.Load(xmlFile);
		}
		/// <summary>
		/// ����һ���ڵ��xPath���ʽ������һ���ڵ�
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public XmlNode FindNode(string xPath)
		{
			XmlNode xmlNode = this.SelectSingleNode(xPath);
			return xmlNode;
		}
		/// <summary>
		/// ����һ���ڵ��xPath���ʽ������ֵ
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public string GetNodeValue(string xPath)
		{
			XmlNode xmlNode = this.SelectSingleNode(xPath);
			return xmlNode.InnerText;
		}
		/// <summary>
		/// ����һ���ڵ�ı��ʽ���ش˽ڵ��µĺ��ӽڵ��б�
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public XmlNodeList GetNodeList(string xPath)
		{
			XmlNodeList nodeList = this.SelectSingleNode(xPath).ChildNodes;
			return nodeList;

		}

	}
}
