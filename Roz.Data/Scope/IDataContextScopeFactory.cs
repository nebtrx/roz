/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;
using System.Data;

namespace Roz.Data.Scope
{
    /// <summary>
    /// Convenience methods to create a new ambient DataContextScope. This is the prefered method
    /// to create a DataContextScope.
    /// </summary>
    public interface IDataContextScopeFactory
    {
        /// <summary>
        /// Creates a new DataContextScope.
        /// 
        /// By default, the new scope will join the existing ambient scope. This
        /// is what you want in most cases. This ensures that the same DataEngine instances
        /// are used by all services methods called within the scope of a business transaction.
        /// 
        /// Set 'joiningOption' to 'ForceCreateNew' if you want to ignore the ambient scope
        /// and force the creation of new DataEngine instances within that scope. Using 'ForceCreateNew'
        /// is an advanced feature that should be used with great care and only if you fully understand the
        /// implications of doing this.
        /// </summary>
        IDataContextScope Create(DataContextScopeOption joiningOption = DataContextScopeOption.JoinExisting);

        /// <summary>
        /// Creates a new DataContextScope for read-only queries.
        /// 
        /// By default, the new scope will join the existing ambient scope. This
        /// is what you want in most cases. This ensures that the same DataEngine instances
        /// are used by all services methods called within the scope of a business transaction.
        /// 
        /// Set 'joiningOption' to 'ForceCreateNew' if you want to ignore the ambient scope
        /// and force the creation of new DataEngine instances within that scope. Using 'ForceCreateNew'
        /// is an advanced feature that should be used with great care and only if you fully understand the
        /// implications of doing this.
        /// </summary>
        IDataContextReadOnlyScope CreateReadOnly(DataContextScopeOption joiningOption = DataContextScopeOption.JoinExisting);

        /// <summary>
        /// Forces the creation of a new ambient DataContextScope (i.e. does not
        /// join the ambient scope if there is one) and wraps all DataEngine instances
        /// created within that scope in an explicit database transaction with 
        /// the provided isolation level. 
        /// 
        /// WARNING: the database transaction will remain open for the whole 
        /// duration of the scope! So keep the scope as short-lived as possible.
        /// Don't make any remote API calls or perform any long running computation 
        /// within that scope.
        /// 
        /// This is an advanced feature that you should use very carefully
        /// and only if you fully understand the implications of doing this.
        /// </summary>
        IDataContextScope CreateWithTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Forces the creation of a new ambient read-only DataContextScope (i.e. does not
        /// join the ambient scope if there is one) and wraps all DataEngine instances
        /// created within that scope in an explicit database transaction with 
        /// the provided isolation level. 
        /// 
        /// WARNING: the database transaction will remain open for the whole 
        /// duration of the scope! So keep the scope as short-lived as possible.
        /// Don't make any remote API calls or perform any long running computation 
        /// within that scope.
        /// 
        /// This is an advanced feature that you should use very carefully
        /// and only if you fully understand the implications of doing this.
        /// </summary>
        IDataContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Temporarily suppresses the ambient DataContextScope. 
        /// 
        /// Always use this if you need to  kick off parallel tasks within a DataContextScope. 
        /// This will prevent the parallel tasks from using the current ambient scope. If you
        /// were to kick off parallel tasks within a DataContextScope without suppressing the ambient
        /// context first, all the parallel tasks would end up using the same ambient DataContextScope, which 
        /// would result in multiple threads accesssing the same DataEngine instances at the same 
        /// time.
        /// </summary>
        IDisposable SuppressAmbientContext();
    }
}
