/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Data;
using System.Data.Entity;
using Roz.Data.Scope;

namespace Roz.Data.EntityFramework.Scope
{
    public class DbContextReadOnlyScope : IDataContextReadOnlyScope
    {
        private DbContextScope _internalScope;

        public IDataContextCollection DataContexts { get { return _internalScope.DataContexts; } }

        public DbContextReadOnlyScope(IDataContextFactory dbContextFactory = null)
            : this(joiningOption: DataContextScopeOption.JoinExisting, isolationLevel: null, dbContextFactory: dbContextFactory)
        {}

        public DbContextReadOnlyScope(IsolationLevel isolationLevel, IDataContextFactory dbContextFactory = null)
            : this(joiningOption: DataContextScopeOption.ForceCreateNew, isolationLevel: isolationLevel, dbContextFactory: dbContextFactory)
        { }

        public DbContextReadOnlyScope(DataContextScopeOption joiningOption, IsolationLevel? isolationLevel, IDataContextFactory dbContextFactory = null)
        {
            _internalScope = new DbContextScope(joiningOption: joiningOption, readOnly: true, isolationLevel: isolationLevel, dbContextFactory: dbContextFactory);
        }

        public void Dispose()
        {
            _internalScope.Dispose();
        }
    }
}