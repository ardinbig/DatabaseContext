using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseContext
{
    /// <summary>
    /// Represents a database connection.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        [Required(ErrorMessage = "Server is required")]
        public string Server { get; set; } = "localhost";

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        private string _dbName;
        [Required(ErrorMessage = "Database name is required")]
        public string DbName
        {
            get => _dbName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Database name cannot be null or empty", nameof(DbName));
                _dbName = value;
            }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        private string _user;
        [Required(ErrorMessage = "User is required")]
        public string User
        {
            get => _user;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("User cannot be null or empty", nameof(User));
                _user = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        [Range(0, 65535, ErrorMessage = "Port must be between 0 and 65535")]
        public int Port { get; set; } = 0;
    }
}