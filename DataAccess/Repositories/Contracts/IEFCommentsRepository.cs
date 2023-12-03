using DataAccess.Models;

namespace DataAccess.Repositories.Contracts;

public interface IEFCommentsRepository : IEFGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article);
}