using Ninject;

namespace Estoque.IOC.Repositories
{
    public interface IRegisterRepository
    {
        void Register(IKernel kernel);
    }
}
