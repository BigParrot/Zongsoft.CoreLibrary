﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2014 Zongsoft Corporation <http://www.zongsoft.com>
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

namespace Zongsoft.IO
{
	/// <summary>
	/// 公开用于创建、移动和遍历目录和子目录等功能的抽象接口，该接口将提供不同文件系统的目录支持。
	/// </summary>
	public interface IDirectoryService
	{
		/// <summary>
		/// 获取指定目录路径对应的<see cref="DirectoryInfo"/>。
		/// </summary>
		/// <param name="path">指定的目录路径。</param>
		/// <returns>如果指定的路径是存在的则返回对应的<see cref="DirectoryInfo"/>，否则返回空(null)。</returns>
		DirectoryInfo GetInfo(string path);

		/// <summary>
		/// 创建一个指定路径的目录。
		/// </summary>
		/// <param name="path">指定要创建的目录路径。</param>
		/// <returns>如果创建成功则返回真(True)，否则返回假(False)。</returns>
		/// <remarks>
		///		<para>如果<paramref name="path"/>参数指定的路径不存在并且创建成功则返回真；如果指定的路径已存在则返回假。</para>
		/// </remarks>
		bool Create(string path);

		void Delete(string path, bool recursive = false);

		void Move(string source, string destination);
		bool Exists(string path);

		IEnumerable<string> GetChildren(string path);
		IEnumerable<string> GetChildren(string path, string pattern, bool recursive = false);

		IEnumerable<string> GetDirectories(string path);
		IEnumerable<string> GetDirectories(string path, string pattern, bool recursive = false);

		IEnumerable<string> GetFiles(string path);
		IEnumerable<string> GetFiles(string path, string pattern, bool recursive = false);
	}
}
