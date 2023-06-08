using System;
using System.Data;

namespace NETCORE3.Infrastructure
{
    public interface IMyAdapter : IDisposable
    {
        bool TestConnection();
        DataTable ExecuteQuery(string query);
    }
}
