/*
 * Authors:
 *   �ӷ�(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2008-2013 Zongsoft Corporation <http://www.zongsoft.com>
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
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace Zongsoft.ComponentModel
{
	[Obsolete]
	[Serializable]
	public class Condition : ICondition, INotifyPropertyChanged
	{
		#region ��������
		public const int DefaultPageSize = 20;
		#endregion

		#region �¼�����
		public event EventHandler PageSizeChanged;
		public event EventHandler PageIndexChanged;
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region ��Ա����
		private string _name;
		private bool _fuzzyInquiryEnabled;
		private ConditionCombine _conditionCombine;
		private int _pageSize;
		private int _pageIndex;
		private int _pageCount;
		private int _totalCount;
		private object _expression;
		private IDictionary<string, object> _output;
		private ConditionClauseCollection _clauses;
		#endregion

		#region ���캯��
		public Condition() : this(null, ConditionCombine.And, DefaultPageSize, 0)
		{
		}

		public Condition(string name) : this(name, ConditionCombine.And, DefaultPageSize, 0)
		{
		}

		public Condition(string name, ConditionCombine conditionCombine) : this(name, conditionCombine, DefaultPageSize, 0)
		{
		}

		public Condition(string name, ConditionCombine conditionCombine, int pageSize, int pageIndex)
		{
			_name = this.GetName(name);
			_fuzzyInquiryEnabled = false;
			_conditionCombine = conditionCombine;
			_pageSize = pageSize;
			_pageIndex = pageIndex;
			_pageCount = -1;
			_totalCount = 0;
			_output = null;
			_clauses = new ConditionClauseCollection();
		}
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡ��ѯ���������ơ�
		/// </summary>
		[IgnoreCondition()]
		[DisplayName("��������")]
		[Description("��ʾ��ѯ���������ƣ�������ͨ����Ӧ����ͬ��ѯ����")]
		public virtual string Name
		{
			get
			{
				return _name ?? string.Empty;
			}
			protected set
			{
				if(string.Equals(_name, value, StringComparison.OrdinalIgnoreCase))
					return;

				_name = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
				this.OnPropertyChanged("Name");
			}
		}

		[DefaultValue(true)]
		[IgnoreCondition()]
		[ParenthesizePropertyName(true)]
		[DisplayName("ģ����ѯ")]
		[Description("��ʾ��ѯ�����ж��ַ������͵������Ƿ�����ģ����ѯ����ͨ���֧�֣�Ĭ��Ϊ���á�")]
		public bool FuzzyInquiryEnabled
		{
			get
			{
				return _fuzzyInquiryEnabled;
			}
			set
			{
				if(_fuzzyInquiryEnabled != value)
				{
					_fuzzyInquiryEnabled = value;
					this.OnPropertyChanged("FuzzyInquiryEnabled");
				}
			}
		}

		[DefaultValue(ConditionCombine.And)]
		[IgnoreCondition()]
		[ParenthesizePropertyName(true)]
		[DisplayName("�������")]
		[Description("��ʾ��ѯ��������Ϸ�ʽ���С����ҡ��͡����ߡ�������ѡ�Ĭ��Ϊ�����ҡ���Ϸ�ʽ��")]
		[TypeConverter(typeof(EnumConverter))]
		public ConditionCombine ConditionCombine
		{
			get
			{
				return _conditionCombine;
			}
			set
			{
				if(_conditionCombine == value)
					return;

				_conditionCombine = value;
				this.OnPropertyChanged("ConditionCombine");
			}
		}

		[Browsable(false)]
		[DefaultValue(DefaultPageSize)]
		[IgnoreCondition()]
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				if(value < 0)
					throw new ArgumentOutOfRangeException();

				if(_pageSize == value)
					return;

				_pageSize = value;

				//������PageSizeChanged���¼�
				this.OnPageSizeChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[DefaultValue(0)]
		[IgnoreCondition()]
		public int PageIndex
		{
			get
			{
				return _pageIndex;
			}
			set
			{
				if(value < 0)
					throw new ArgumentOutOfRangeException();

				if(_pageIndex == value)
					return;

				_pageIndex = value;

				//������PageIndexChanged���¼�
				this.OnPageIndexChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[IgnoreCondition()]
		public int PageCount
		{
			get
			{
				return _pageCount;
			}
			set
			{
				if(_pageCount != value)
				{
					_pageCount = Math.Max(value, 0);

					//������PropertyChanged���¼�
					this.OnPropertyChanged("PageCount");
				}
			}
		}

		[Browsable(false)]
		[IgnoreCondition()]
		public int TotalCount
		{
			get
			{
				return _totalCount;
			}
			set
			{
				if(_totalCount == value)
					return;

				_totalCount = value;

				//������PropertyChanged���¼�
				this.OnPropertyChanged("TotalCount");
			}
		}

		[Browsable(false)]
		[IgnoreCondition()]
		public object Expression
		{
			get
			{
				return _expression;
			}
			set
			{
				_expression = value;
			}
		}

		[Browsable(false)]
		[IgnoreCondition()]
		public IDictionary<string, object> Output
		{
			get
			{
				if(_output == null)
					System.Threading.Interlocked.CompareExchange(ref _output, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);

				return _output;
			}
		}

		[IgnoreCondition]
		public ConditionClauseCollection Clauses
		{
			get
			{
				return _clauses;
			}
		}
		#endregion

		#region ���ⷽ��
		protected virtual void OnPageSizeChanged(EventArgs e)
		{
			if(this.PageSizeChanged != null)
				this.PageSizeChanged(this, e);
		}

		protected virtual void OnPageIndexChanged(EventArgs e)
		{
			if(this.PageIndexChanged != null)
				this.PageIndexChanged(this, e);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, e);
		}
		#endregion

		#region ˽�з���
		private string GetName(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				name = this.GetType().Name;

				if(name.Length > 9 && name.EndsWith("Condition", StringComparison.OrdinalIgnoreCase))
					return name.Substring(0, name.Length - 9);

				return name;
			}

			return name.Trim();
		}
		#endregion
	}
}
