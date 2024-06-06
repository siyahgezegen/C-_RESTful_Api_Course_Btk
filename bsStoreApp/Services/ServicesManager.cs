using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class ServicesManager : IServicesManager
    {
        //Lazy Loading
        private readonly Lazy<IBookServices> _bookServices;
        public IBookServices BookServices => _bookServices.Value;
        public ServicesManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _bookServices = new Lazy<IBookServices>(()=> new BookManager(repositoryManager, mapper));
        }
    }
}
