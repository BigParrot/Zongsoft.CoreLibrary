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
using System.Collections.Generic;

namespace Zongsoft.Data
{
	[Serializable]
	public class Parameter
	{
		#region ��̬�ֶ�
		/// <summary>�ṩ�����Ĺ��ڲ�ѯ׼��Ĳ������󡣸ò�������Ϊ��__Criteria__��Ĭ��ֵ��AND���������������</summary>
		public static readonly Parameter Criteria = new Parameter("__Criteria__", "AND", ParameterDirection.Input);

		/// <summary>�ṩ�����Ĺ��ڷ�ҳ��С�Ĳ������󡣸ò�������Ϊ��__PageSize__��Ĭ��ֵ��20���������������</summary>
		public static readonly Parameter PageSize = new Parameter("__PageSize__", 20, ParameterDirection.Input);

		/// <summary>�ṩ�����Ĺ��ڷ�ҳҳ�ŵĲ������󡣸ò�������Ϊ��__PageIndex__��Ĭ��ֵ��0���������������</summary>
		public static readonly Parameter PageIndex = new Parameter("__PageIndex__", 0, ParameterDirection.Input);

		/// <summary>�ṩ�����Ĺ��ڷ�ҳҳ���Ĳ������󡣸ò�������Ϊ��__PageCount__��Ĭ��ֵ��-1���������������</summary>
		public static readonly Parameter PageCount = new Parameter("__PageCount__", -1, ParameterDirection.Output);

		/// <summary>�ṩ�����Ĺ��ڼ�¼�����Ĳ������󡣸ò�������Ϊ��__TotalCount__��Ĭ��ֵ��-1���������������</summary>
		public static readonly Parameter TotalCount = new Parameter("__TotalCount__", -1, ParameterDirection.Output);
		#endregion

		#region ���캯��
		internal Parameter(string name, object value) : this(name, value, ParameterDirection.Input)
		{
		}

		internal Parameter(string name, object value, ParameterDirection direction)
		{
			if(string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			this.Name = name;
			this.Value = value;
			this.Direction = direction;
		}
		#endregion

		#region ��������
		public ParameterDirection Direction
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public object Value
		{
			get;
			set;
		}
		#endregion
	}
}
