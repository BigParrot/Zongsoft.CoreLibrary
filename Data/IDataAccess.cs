/*
 * Authors:
 *   �ӷ�(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2003-2010 Zongsoft Corporation <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.CoreLibrary.
 *
 * Zongsoft.CoreLibrary is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Zongsoft.CoreLibrary is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Zongsoft.CoreLibrary; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zongsoft.Data
{
	/// <summary>
	/// ��ʾ���ݷ��ʵĹ����ӿڡ�
	/// </summary>
	[Obsolete]
	public interface IDataAccess
	{
		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������������ѯ�����ز�ѯ�����ݼ���
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <param name="parameterNames">������ѯ�������Ƶ����顣</param>
		/// <param name="parameterValues">������ѯ����ֵ������</param>
		/// <returns>�����������Ĵ�������ѯ�����ݼ���</returns>
		//DataSet Select(string adapterName, string[] parameterNames, object[] parameterValues);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������������ѯ�����ز�ѯ�����ݼ���
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <param name="inningParameters">������ѯ�������б�</param>
		/// <returns>�����������Ĵ�������ѯ�����ݼ���</returns>
		DataSet Select(string adapterName, IDictionary<string, object> inningParameters);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������������ѯ�����ز�ѯ�����ݼ���
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <param name="inningParameters">������ѯ�������б�</param>
		/// <param name="outingParameters">���������ָʾ��ѯ����ص����в����б�</param>
		/// <returns>�����������Ĵ�������ѯ�����ݼ���</returns>
		DataSet Select(string adapterName, IDictionary<string, object> inningParameters, out IDictionary<string, object> outingParameters);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������ѯ�����ز�ѯ�����ݼ���
		/// <para>
		///		ע�⣺�ò�ѯ�����������������ز�ѯ����е����м�¼��
		/// </para>
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <returns>��������Ĳ�ѯ�����ݼ���</returns>
		DataSet SelectAll(string adapterName);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������ѯ�����ز�ѯ�����ݼ���
		/// <para>
		///		ע�⣺�ò�ѯ�����������������ز�ѯ����е����м�¼��
		/// </para>
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <param name="outingParameters">���������ָʾ��ѯ����ص����в����б�</param>
		/// <returns>��������Ĳ�ѯ�����ݼ���</returns>
		DataSet SelectAll(string adapterName, out IDictionary<string, object> outingParameters);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������ѯ�����ز�ѯ�Ŀ����ݼ�(���ؽ���������ݣ�ֻ�������ݼ��Ľṹ)��
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <returns>������������ѯ�Ŀ����ݼ���</returns>
		DataSet SelectSchema(string adapterName);

		/// <summary>
		/// ��ӳ���и���ָ�������������ƣ�������ѯ�����ز�ѯ�Ŀ����ݼ�(���ؽ���������ݣ�ֻ�������ݼ��Ľṹ)��
		/// </summary>
		/// <param name="adapterName">��ѯ�����������ơ�</param>
		/// <param name="outingParameters">���������ָʾ��ѯ����ص����в����б�</param>
		/// <returns>������������ѯ�Ŀ����ݼ���</returns>
		DataSet SelectSchema(string adapterName, out IDictionary<string, object> outingParameters);

		/// <summary>
		/// ��ӳ���и����ƶ��ķ��������ƣ�������Ӧ�������������ݼ���������������Դ�С�
		/// <para>
		///		ע�⣺���ָ���ķ�������ӳ���ļ��еķ����������������ڣ������������������н��в��ҡ�
		/// </para>
		/// </summary>
		/// <param name="accessorName">�������ݼ��ķ����������������ơ�</param>
		/// <param name="dataSet">Ҫ���б�������ݼ�����</param>
		/// <returns>���ر���ɹ�����Ӱ��ļ�¼�����÷���ֵΪָ�����ݼ������б����Ӱ��ļ�¼����</returns>
		int Update(string accessorName, DataSet dataSet);
	}
}
