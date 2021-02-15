using ExcelParser.Domain.Entities;
using ExcelParser.Domain.Repository.Base;

namespace ExcelParser.Domain.Repository.Contracts
{
    public interface ISpreadsheetRepository : IRepository<Row>
    {
    }
}
