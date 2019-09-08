using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Servicos
{
    public class OperacaoServices
    {
        public OperacaoServices(
            IOperacaoTransient transient,
            IOperacaoScoped scoped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }

        public IOperacaoTransient Transient { get; set; }
        public IOperacaoScoped Scoped { get; set; }
        public IOperacaoSingleton Singleton { get; set; }
        public IOperacaoSingletonInstance SingletonInstance { get; set; }
    }

    public class Operacao :
        IOperacaoTransient,
        IOperacaoScoped,
        IOperacaoSingleton,
        IOperacaoSingletonInstance
    {
        public Operacao() : this(Guid.NewGuid())
        {

        }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        public Guid OperacaoId { get; private set; }
    }
    public interface IOperacao
    {
        Guid OperacaoId { get;  }
    }

    public interface IOperacaoTransient: IOperacao { }
    public interface IOperacaoScoped : IOperacao { }
    public interface IOperacaoSingleton : IOperacao { }
    public interface IOperacaoSingletonInstance : IOperacao { }
}
