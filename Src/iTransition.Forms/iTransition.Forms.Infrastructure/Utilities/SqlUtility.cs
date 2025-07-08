using iTransition.Forms.Domain;
using System.Data.Common;

namespace iTransition.Forms.Infrastructure.Utilities
{
    public class SqlUtility : ISqlUtility
    {
        private readonly DbConnection _connection;
        private readonly int _timeout;

        public SqlUtility(DbConnection connection, int timeout = 0)
        {
            _connection = connection;
            _timeout = timeout;
        }   
    }
}
