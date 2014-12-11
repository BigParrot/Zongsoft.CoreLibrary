﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
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
using System.Collections;
using System.Collections.Generic;

namespace Zongsoft.Data
{
	public class ConditionClauseCollection : Zongsoft.Collections.Collection<ICondition>, ICondition
	{
		#region 成员字段
		private ConditionCombine _clauseCombine;
		#endregion

		#region 构造函数
		public ConditionClauseCollection(ConditionCombine clauseCombine)
		{
			_clauseCombine = clauseCombine;
		}

		public ConditionClauseCollection(ConditionCombine clauseCombine, IEnumerable<ICondition> items) : base(items)
		{
			_clauseCombine = clauseCombine;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置查询条件的组合方式。
		/// </summary>
		public ConditionCombine ClauseCombine
		{
			get
			{
				return _clauseCombine;
			}
			set
			{
				_clauseCombine = value;
			}
		}
		#endregion

		#region 接口实现
		public ConditionClauseCollection ToClauses()
		{
			return this;
		}

		public ConditionClauseCollection ToClauses(ConditionCombine combine)
		{
			return new ConditionClauseCollection(combine, this.Items);
		}
		#endregion
	}
}
