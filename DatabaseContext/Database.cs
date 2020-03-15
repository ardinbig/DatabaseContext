using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public class Database
    {
        public Database() { }

        private string _server = "localhost";
        private string _dbName = "";
        private string _user = "";
        private string _password = "";
        private int _port = 0;

        public string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
            }
        }

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

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }
    }
}
