using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    class Itens {
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public double Qtd { get; set; }

        public Itens(string nome, double valorUnitario, double qtd) {
            Nome = nome;
            ValorUnitario = valorUnitario;
            Qtd = qtd;
        }


        public double valorTotalDoItem() {
            return ValorUnitario * Qtd;
        }

        public override string ToString() {
            return "Nome: " + Nome
                + ", Qtd: " + Qtd
                + ", Valor Unitario: R$ " + ValorUnitario
                + ", Valor Total: R$ " + valorTotalDoItem();
        }

    }
}
