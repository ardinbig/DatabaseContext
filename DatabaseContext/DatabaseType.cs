namespace DatabaseContext
{
    /// <summary>
    /// Specifies the type of database to connect to.
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MySQL database.
        /// </summary>
        MySql,

        /// <summary>
        /// Microsoft SQL Server database.
        /// </summary>
        SqlServer,

        /// <summary>
        /// PostgreSQL database.
        /// </summary>
        PostgreSql,

        /// <summary>
        /// Oracle database.
        /// </summary>
        Oracle
    }
}