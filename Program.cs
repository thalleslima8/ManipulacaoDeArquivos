﻿using System;
using Entities;
using System.IO;
using System.Collections.Generic;

namespace ManipulacaoDeArquivos {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Digite o caminho do arquivo a ser criado: ");
            string sourceFilePath = Console.ReadLine();

            Console.WriteLine("Quantos itens serão cadastrados: ");
            int n = int.Parse(Console.ReadLine());
            List<Itens> itens = new List<Itens>();


            for (int i = 0; i < n; i++) {
                Console.WriteLine("Digite o nome do Item: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite a Quantidade: ");
                double qtd = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Valor Unitario: ");
                double valor = double.Parse(Console.ReadLine());

                itens.Add(new Itens(nome, valor, qtd));

            }

            try {

                if (!File.Exists(sourceFilePath)) {
                    string sourceFolderPath1 = Path.GetDirectoryName(sourceFilePath);
                    string targetFilePath1 = sourceFolderPath1 + @"\itens.csv";

                    using (StreamWriter sw = File.CreateText(targetFilePath1)) {
                        foreach (Itens i in itens) {
                            sw.WriteLine(i.Nome + "," + i.Qtd + "," + i.ValorUnitario);
                        }
                    }
                }

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                Console.WriteLine(sourceFolderPath);
                string targetFolderPath = sourceFolderPath + @"\out";
                Console.WriteLine(targetFolderPath);
                string targetFilePath = targetFolderPath + @"\summary.csv";
                Console.WriteLine(targetFilePath);

                Directory.CreateDirectory(targetFolderPath);

                if (!File.Exists(targetFilePath)) {
                    using (StreamWriter sw = File.CreateText(targetFilePath)) {
                        foreach (Itens i in itens) {
                            sw.WriteLine(i.Nome + "," + i.Qtd + "," + i.ValorUnitario + "," + i.valorTotalDoItem());
                        }
                    }
                } else {
                                        using (StreamWriter sw = File.AppendText(targetFilePath)) {
                        foreach (Itens i in itens) {
                            sw.WriteLine(i.Nome + "," + i.Qtd + "," + i.ValorUnitario + "," + i.valorTotalDoItem());
                        }
                    }
                }

            } catch (IOException e) {
                Console.Write("Erro: ");
                Console.WriteLine(e.Message);
            }




        }
    }
}
