using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PareAqui
{
    public class Carro
    {
        public static List<Carro> carrosExistentes = new List<Carro>();
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Carro()
        {
            Tickets = new List<Ticket>();
        }
        public static void CadastrarCarro()
        {
            Console.WriteLine("Informe a placa do veículo (contendo hifen):");
            string placa = Console.ReadLine();

            if (Carro.ObterCarro(placa) != null)
            {
                Console.WriteLine("Veículo já cadastrado com essa placa! Pressione uma tecla para continuar...");
                Console.ReadLine();
                return;
            }
            while (placa.Trim() == "")
            {
                Console.WriteLine("Vamos tentar novamente, digite um valor válido: ");
                placa = Console.ReadLine();
            }

            Console.WriteLine("Informe o modelo do veículo:");
            string modelo = Console.ReadLine();

            while (modelo.Trim() == "")
            {
                Console.WriteLine("Vamos tentar novamente, digite um valor válido: ");
                modelo = Console.ReadLine();
            }

            Console.WriteLine("Informe a marca do veículo:");
            string marca = Console.ReadLine();

            while (marca.Trim() == "")
            {
                Console.WriteLine("Vamos tentar novamente, digite um valor válido: ");
                marca = Console.ReadLine();
            }

            Carro carro = new Carro();
            carro.Placa = placa;
            carro.Modelo = modelo;
            carro.Marca = marca;

            carrosExistentes.Add(carro);
            Console.WriteLine("Veículo cadastrado com sucesso! Pressione uma tecla para continuar...");
            Console.ReadLine();
        }

        public static Carro ObterCarro(string placa)
        {
            if (placa.Trim() != "")
            {
                return carrosExistentes.Find(x => x.Placa == placa);
            }
            return null;
        }
    }
}
