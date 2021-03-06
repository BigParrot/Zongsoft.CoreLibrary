﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2013 Zongsoft Corporation <http://www.zongsoft.com>
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zongsoft.Services.Composition
{
	public class ExecutingEventArgs : EventArgs
	{
		#region 成员字段
		private bool _cancel;
		private Executor _executor;
		private object _parameter;
		private object _result;
		#endregion

		#region 构造函数
		public ExecutingEventArgs(Executor executor, object parameter, bool cancel = false)
		{
			if(executor == null)
				throw new ArgumentNullException("executor");

			_executor = executor;
			_parameter = parameter;
			_cancel = cancel;
		}
		#endregion

		#region 公共属性
		public Executor Executor
		{
			get
			{
				return _executor;
			}
		}

		public object Parameter
		{
			get
			{
				return _parameter;
			}
		}

		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}

		public object Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
			}
		}
		#endregion
	}
}
