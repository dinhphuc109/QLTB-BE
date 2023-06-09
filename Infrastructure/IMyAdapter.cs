using System;
using System.Collections.Generic;
using System.Data;

namespace NETCORE3.Infrastructure
{
    public interface IMyAdapter : IDisposable
    {
        bool TestConnection();
        DataTable ExecuteQuery(string query);
        DataTable ExecuteQuery(string query, Dictionary<string, object> parameters);
        void OpenConnection();
        void CloseConnection();
        void Dispose();
    }
}
