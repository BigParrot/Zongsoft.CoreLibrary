﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2003-2014 Zongsoft Corporation <http://www.zongsoft.com>
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

namespace Zongsoft.Security.Membership
{
	/// <summary>
	/// 提供安全凭证相关操作的功能。
	/// </summary>
	public interface ICertificationProvider
	{
		/// <summary>
		/// 为指定的用户注册安全凭证。
		/// </summary>
		/// <param name="applicationId">指定的凭证所属的应用编号。</param>
		/// <param name="userName">指定的用户名称。</param>
		Certification Register(string applicationId, string userName);

		/// <summary>
		/// 从安全凭证容器中注销指定的凭证。
		/// </summary>
		/// <param name="certificationId">指定的要注销的安全凭证编号。</param>
		void Unregister(string certificationId);

		/// <summary>
		/// 续约指定的安全凭证。
		/// </summary>
		/// <param name="certificationId">指定要续约的安全凭证编号。</param>
		void Renew(string certificationId);

		/// <summary>
		/// 续约指定的安全凭证。
		/// </summary>
		/// <param name="certificationId">指定要续约的安全凭证编号。</param>
		/// <param name="duration">指定要续约的期限。</param>
		void Renew(string certificationId, TimeSpan duration);

		/// <summary>
		/// 获取当前安全凭证容器内的所有凭证数。
		/// </summary>
		/// <returns>返回的安全凭证数量。</returns>
		/// <remarks>
		///		<para>返回的凭证数包括有效和过期无效的凭证。</para>
		/// </remarks>
		int GetCount();

		/// <summary>
		/// 获取当前安全凭证容器内的指定应用程序的凭证数。
		/// </summary>
		/// <param name="applicationId">指定的应用程序编号。</param>
		/// <returns>返回的安全凭证数量。</returns>
		/// <remarks>
		///		<para>返回的凭证数包括有效和过期无效的凭证。</para>
		/// </remarks>
		int GetCount(string applicationId);

		/// <summary>
		/// 验证指定的安全凭证号是否有效。
		/// </summary>
		/// <param name="certificationId">指定的要验证的安全凭证号。</param>
		/// <remarks>
		///		<para>如果验证失败则抛出相应的异常。</para>
		/// </remarks>
		void Validate(string certificationId);

		/// <summary>
		/// 获取指定安全凭证号对应的应用编号。
		/// </summary>
		/// <param name="certificationId">指定的安全凭证号。</param>
		/// <returns>返回对应的应用编号，如果为空(null)则表示该凭证号无效。</returns>
		string GetApplicationId(string certificationId);

		/// <summary>
		/// 获取指定安全凭证编号对应的<see cref="Certification"/>安全凭证对象。
		/// </summary>
		/// <param name="certificationId">指定要获取的安全凭证编号。</param>
		/// <returns>返回的对应的安全凭证对象，如果指定的安全凭证编号不存在则返回空(null)。</returns>
		Certification GetCertification(string certificationId);

		/// <summary>
		/// 获取指定应用中的所有<see cref="Certification"/>安全凭证对象集。
		/// </summary>
		/// <param name="applicationId">指定要获取的安全凭证所属的应用编号。</param>
		/// <returns>返回的对应的安全凭证对象集，如果指定的应用下无安全凭证则返回空集合。</returns>
		IEnumerable<Certification> GetCertifications(string applicationId);

		/// <summary>
		/// 获取指定应用中的指定用户对应的<see cref="Certification"/>安全凭证对象集。
		/// </summary>
		/// <param name="applicationId">指定要获取的安全凭证所属的应用编号。</param>
		/// <param name="userName">指定要获取的安全凭证对应的用户名。</param>
		/// <returns></returns>
		IEnumerable<Certification> GetCertifications(string applicationId, string userName);
	}
}
