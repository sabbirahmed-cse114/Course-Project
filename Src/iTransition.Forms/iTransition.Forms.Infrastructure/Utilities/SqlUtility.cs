using System.Data.Common;
using iTransition.Forms.Domain;

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
