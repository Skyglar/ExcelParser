using ExcelParser.Domain.Entities;
using System.Collections.Generic;

namespace ExcelParser.Domain.Repository.Base
{
    public interface IRepository<T>
    {
        IEnumerable<Row> GetAll();
        int AddRange(ICollection<T> list);
        int UpdateRange(ICollection<T> entities);
        int Delete(int id);
    }
}
