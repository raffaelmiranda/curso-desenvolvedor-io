using CursoEFCore.Data;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var db = new Data.ApplicationContext();
            //var existe = db.Database.GetPendingMigrations().Any();
            //if (existe){}

            //InserirProduto();
            //InserirDadosemMassa();
            //ConsultaDados();
            //CadastrarPedido();
            //ConsultaPedidoCarregamentoAdiantado();
            //AtualizarDados();
            RemoverRegistro();

        }

        private static void InserirProduto()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new ApplicationContext();

            //Forma de adicionar a entidade
            db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var registros = db.SaveChanges();

            Console.WriteLine($"Total Registro(s): {registros}");

        }

        private static void InserirDadosemMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente()
            {
                Nome = "Rafael Miranda",
                CEP = "05356000",
                Cidade = "Assis",
                Estado = "SP",
                Telefone = "1199878787"
            };

            var listaClientes = new[]
            {
                new Cliente()
                {
                    Nome = "Teste 1",
                    CEP = "05356000",
                    Cidade = "Assis",
                    Estado = "SP",
                    Telefone = "1199878787"
                },
                new Cliente()
                {
                    Nome = "Teste 2",
                    CEP = "05356000",
                    Cidade = "Assis",
                    Estado = "SP",
                    Telefone = "1199878787"
                }
            };


            using var db = new ApplicationContext();
            //db.AddRange(produto, cliente);
            //db.Clientes.AddRange(listaClientes);
            db.Set<Produto>().AddRange(produto);


            var registros = db.SaveChanges();

            Console.WriteLine($"Total Registro(s): {registros}");
        }

        private static void ConsultaDados()
        {
            using var db = new ApplicationContext();
            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes
                .Where(p => p.Id > 0)
                .OrderBy(p => p.Id)
                .ToList();

            foreach (var cliente in consultaPorMetodo)
            {
               Console.WriteLine($"Consultando Cliente: {cliente.Id}");
                //db.Clientes.Find(cliente.Id); // procura na memoria, se não achar vai na base
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
            }
        }

        private static void CadastrarPedido()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10

                    }
                }
            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }

        private static void ConsultaPedidoCarregamentoAdiantado()
        {
            using var db = new ApplicationContext();
            var pedidos = db
                .Pedidos.Include(p => p.Itens).ThenInclude(p => p.Produto).ToList();

            Console.WriteLine(pedidos.Count);
        }

        private static void AtualizarDados()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.Find(1);

            //var cliente = new Cliente
            //{
            //    Id = 1
            //};

            var clienteDesconectado = new
            {
                Nome = "Cliente Desconectado 2",
                Telefone = "22132323"
            };

            db.Attach(cliente);
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado); //Desconectado

            //db.Entry(cliente).State = EntityState.Modified; //Rastreamento
            //db.Clientes.Update(cliente);

            db.SaveChanges();



        }

        private static void RemoverRegistro()
        {
            using var db = new ApplicationContext();

            //Conectado
            //var cliente = db.Clientes.Find(3);
            //db.Clientes.Remove(cliente);
            //db.Remove(cliente);
            //db.Entry(cliente).State = EntityState.Deleted;

            //Desconectado
            var cliente = new Cliente { Id = 4 };
            db.Entry(cliente).State = EntityState.Deleted;

            db.SaveChanges();
        }

    }
}
