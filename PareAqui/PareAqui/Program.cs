using PareAqui;

string opcao = "";
string placa = "";

do
{
    Console.WriteLine("Bem-vindo ao estacionamento PARE AQUI! O que você deseja fazer?");
    Console.WriteLine("1 - Cadastrar Carro");
    Console.WriteLine("2 - Marcar Entrada");
    Console.WriteLine("3 - Marcar Saída");
    Console.WriteLine("4 - Consultar histórico");
    Console.WriteLine("5 - Sair");

    opcao = Console.ReadLine();
    while (!(opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "5"))
    {
        Console.WriteLine("Vamos tentar novamente, escolha um item do menu: ");
        opcao = Console.ReadLine();
    }

    if (opcao == "1")
    {
        Console.WriteLine("Você escolheu 'Cadastrar Carro'! Precisamos coletar algumas informações:");
        Carro.CadastrarCarro();

    }
    else if (opcao == "2")
    {
        Console.WriteLine("Você escolheu 'Marcar Entrada'! Informe a placa do veículo: (contendo hífen)");
        placa = Console.ReadLine();
        while (placa.Trim() == "")
        {
            Console.WriteLine("Vamos tentar novamente, informe a placa do veículo: (contendo hífen)");
            placa = Console.ReadLine();
        }

        Ticket.GerarTicket(placa);

    }
    else if (opcao == "3")
    {
        Console.WriteLine("Você escolheu 'Marcar Saída'! Informe a placa do veículo: (contendo hífen)");
        placa = Console.ReadLine();
        while (placa.Trim() == "")
        {
            Console.WriteLine("Vamos tentar novamente, informe a placa do veículo: (contendo hífen)");
            placa = Console.ReadLine();
        }
        Ticket.MarcarSaida(placa);

    }
    else if (opcao == "4")
    {
        Console.WriteLine("Você escolheu 'Consultar histórico'! Informe a placa do veículo: (contendo hífen)");
        placa = Console.ReadLine();
        while (placa.Trim() == "")
        {
            Console.WriteLine("Vamos tentar novamente, informe a placa do veículo: (contendo hífen)");
            placa = Console.ReadLine();
        }

        Ticket.Historico(placa);
    }

} while (opcao != "5");


