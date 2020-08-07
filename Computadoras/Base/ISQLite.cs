using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Computadoras.Base
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
