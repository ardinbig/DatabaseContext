using System.Data;

namespace DatabaseContext
{
    public interface IConnection
    {
        /// <summary>
        /// Retourne l'instance de la connexion à la base de données
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        IDbConnection Initialize(Database db);
    }
}
