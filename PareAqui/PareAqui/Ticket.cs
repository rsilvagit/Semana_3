using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PareAqui
{
    public class Ticket
    {
        private double valorMinuto = 0.09d;
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Ativo { get; set; }

        public Ticket(DateTime Entrada)
        {
            this.Entrada = Entrada;
            this.Ativo = true;
        }

        public double CalcularTempo()
        {
            var tempo = this.Saida - this.Entrada;
            return tempo.TotalMinutes;
        }

        public double CalcularValor()
        {
            return CalcularTempo() * this.valorMinuto;
        }

        public static void GerarTicket(string placa)
        {
            Carro carro = Carro.ObterCarro(placa);
            if (carro == null)
            {
                Console.WriteLine("Veículo não cadastrado! Pressione uma tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                if (carro.Tickets.Exists(x => x.Ativo == true))
                {
                    Console.WriteLine("Veículo já possui um ticket aberto! Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    DateTime dtEntrada = DateTime.Now;
                    Ticket ticket = new Ticket(dtEntrada);
                    carro.Tickets.Add(ticket);
                    Console.WriteLine($"Entrada marcada com sucesso em {dtEntrada.ToShortDateString()} às {dtEntrada.ToShortTimeString()}! Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }

        public static void Historico(string placa)
        {
            Carro carro = Carro.ObterCarro(placa);
            if (carro == null)
            {
                Console.WriteLine("Veículo não cadastrado! Pressione uma tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                if (carro.Tickets.Count == 0)
                {
                    Console.WriteLine("Veículo ainda não possui tickets vinculados! Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Exibindo histórico dos tickets:");
                    foreach (Ticket ticket in carro.Tickets)
                    {
                        if (ticket.Ativo)
                        {
                            Console.WriteLine($"Entrada: {ticket.Entrada.ToShortDateString()} às {ticket.Entrada.ToShortTimeString()} - Saída: Não houve saída (Ativo)");
                        }
                        else
                        {
                            Console.WriteLine($"Entrada: {ticket.Entrada.ToShortDateString()} às {ticket.Entrada.ToShortTimeString()} - Saída: {ticket.Saida.ToShortDateString()} às {ticket.Saida.ToShortTimeString()} Valor pago: R$ {ticket.CalcularValor().ToString("N2")}");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }

        public static void MarcarSaida(string placa)
        {
            Carro carro = Carro.ObterCarro(placa);
            if (carro == null)
            {
                Console.WriteLine("Veículo não cadastrado! Pressione uma tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                if (!carro.Tickets.Exists(x => x.Ativo == true))
                {
                    Console.WriteLine("Veículo não possui um ticket aberto! Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Ticket ticket = carro.Tickets.Find(x => x.Ativo == true);
                    DateTime dtSaida = DateTime.Now;
                    ticket.Saida = dtSaida;
                    ticket.Ativo = false;
                    Console.WriteLine($"Saída marcada com sucesso em {dtSaida.ToShortDateString()} às {dtSaida.ToShortTimeString()}! Pressione uma tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
