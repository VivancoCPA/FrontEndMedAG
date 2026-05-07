using System.Dynamic;

namespace MedicalCareR1.Shared.Contracts;

public interface ICatalogoService
{
    Task<List<ExpandoObject>> GetAll(string endpoint);
    Task Save(string endpoint, object item);
    Task Deactivate(string endpoint, object item);
}
