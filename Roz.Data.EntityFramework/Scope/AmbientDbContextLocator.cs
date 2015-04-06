/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;
using System.Data.Entity;
using Roz.Data.Scope;

namespace Roz.Data.EntityFramework.Scope
{
    public class AmbientDbContextLocator : IAmbientDataContextLocator
    {
        public TDataSessionContext Get<TDataSessionContext>() where TDataSessionContext : class 
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();
            return ambientDbContextScope == null ? default(TDataSessionContext) : ambientDbContextScope.DataContexts.Get<TDataSessionContext>();
        }

        public object Get(Type requestedType)
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();
            return ambientDbContextScope == null ? null : ambientDbContextScope.DataContexts.Get(requestedType);
        }
    }
}