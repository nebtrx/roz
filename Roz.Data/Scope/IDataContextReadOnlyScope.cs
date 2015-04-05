/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;

namespace Roz.Data.Scope
{
    /// <summary>
    /// A read-only DbContextScope. Refer to the comments for IDataContextScope
    /// for more details.
    /// </summary>
    public interface IDataContextReadOnlyScope : IDisposable
    {
        /// <summary>
        /// The DbContext instances that this DbContextScope manages.
        /// </summary>
        IDataContextCollection DataContexts { get; }
    }
}