using System;

namespace NerdStore.Catalogo.Domain.Tests
{
    internal class Produto
    {
        private string v1;
        private string empty;
        private bool v2;
        private int v3;
        private Guid guid;
        private DateTime now;
        private string v4;
        private Dimensoes dimensoes;

        public Produto(string v1, string empty, bool v2, int v3, Guid guid, DateTime now, string v4, Dimensoes dimensoes)
        {
            this.v1 = v1;
            this.empty = empty;
            this.v2 = v2;
            this.v3 = v3;
            this.guid = guid;
            this.now = now;
            this.v4 = v4;
            this.dimensoes = dimensoes;
        }
    }
}