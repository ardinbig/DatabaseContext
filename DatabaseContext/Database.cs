using System;

namespace DatabaseContext
{
    public class Database
    {
        public Database() { }

        private string _dbName = "";
        private string _user = "";

        public string Server { get; set; } = "localhost";

        public string DbName
        {
            get
            {
                return _dbName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("No null database");
                else
                    _dbName = value;
            }
        }

        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("No null user");
                else
                    _user = value;
            }
        }

        public string Password { get; set; } = "";

        public int Port { get; set; } = 0;
    }
}
