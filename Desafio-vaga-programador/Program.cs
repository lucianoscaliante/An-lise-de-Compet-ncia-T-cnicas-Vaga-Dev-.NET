// Desafio lista de tarefa em C#
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ListaDeTarefas
{
    class Tarefa
    {
        public Tarefa(string? titulo, string? descricao, DateTime dataDeVencimento)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataDeVencimento = dataDeVencimento;
        }

        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public bool Concluida { get; set; }
    }

    class Program
    {
        static void EditarTarefa()// Função para editar tarefa 
        {
            Console.WriteLine("---- Editar Tarefa ----");

            //validando se a alguma tarefa para ser editada
            if (listaDeTarefas.Count == 0)
            {
                Console.WriteLine("Você não tem nenhuma tarefa a ser Editada....!");
                return;
            }

            int indiceTarefa;
            while (true)
            {
                Console.Write("Digite o indice da tarefa para ser editada:");
                if (int.TryParse(Console.ReadLine(), out indiceTarefa))// validadno o indice passado pelo usuário
                {
                    if (indiceTarefa > 0 && indiceTarefa <= listaDeTarefas.Count)// validando se o indice passado pelo usuário e valido
                    {
                        break;
                    }
                }
                Console.WriteLine("O índice informado não e válido! Tente novamente...");
            }

            Tarefa tarefaSelecionada = listaDeTarefas[indiceTarefa - 1];

            //Pegando novos dados para editar a tarefa selecionada pelo usuário
            Console.WriteLine("Digite os novos dados da tarefa Abaixo...!");
            Console.Write("Novo Título: "); // pegando o novo título digitado pelo usuário
            string? titulo = Console.ReadLine();

            Console.Write("Nova Descrição da tarefa: "); //pegando a nova descrição da tarefa
            string? descricao = Console.ReadLine();

            //validadando a nova data digitada pelo o usuário
            DateTime dataVencimento;

            while (true)
            {
                Console.Write("Digite um Nova Data de vencimento (dd/MM/yyyy): "); // pegando a nova data de vencimento digitada pelo usuário
                // validando a data digitada pelo usuário
                string? dataDeVencimentoStr = Console.ReadLine();// Data informada pelo usuário

                // Validando data informada pelo usuário
                if (DateTime.TryParseExact(dataDeVencimentoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
                {
                    var dataAtual = DateTime.Now;// pegando Data atual para validar com a data informada
                    if (dataVencimento > dataAtual)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Data informada no poede ser no passado!");
                    }
                }
                else
                {
                    Console.WriteLine("formato da data e inválido!");
                }
            }

            //salvando a tarefa editada
            tarefaSelecionada.Titulo = titulo; //salvando o novo título
            tarefaSelecionada.Descricao = descricao; // salvando nova descrição
            tarefaSelecionada.DataDeVencimento = dataVencimento; // salvando nova data de vencimento

            Console.WriteLine("Tarafa editada com sucesso.....!!");
        }// fim da função de editar tarefa

        static void AdicionarTarefa()// função para adicionar tarefa 
        {
            Console.WriteLine("----- Adicionar Tarefa -----");

            Console.Write("Título: ");
            string? titulo = Console.ReadLine();//Título informado pelo usuário

            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();//Descrição informada pelo usuário

            DateTime dataDeVencimento;
            while (true)
            {
                Console.Write("Data de vencimento (dd/mm/aaaa): ");
                string? dataDeVencimentoStr = Console.ReadLine();// Data informada pelo usuário

                // Validando data informada pelo usuário
                if (DateTime.TryParseExact(dataDeVencimentoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDeVencimento))
                {
                    var dataAtual = DateTime.Now;// pegando Data atual para validar com a data informada
                    if (dataDeVencimento > dataAtual)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Data informada no poede ser no passado!");
                    }
                }
                else
                {
                    Console.WriteLine("formato da data e inválido!");
                }
            }

            Tarefa novaTarefa = new Tarefa(titulo, descricao, dataDeVencimento);
            listaDeTarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }// fim da função de adicionar tarefa

        static void ListarTarefas() //função para listar todas as tarefas
        {
            Console.WriteLine("----Lista de Tarefas Cadastradas-----");
            if (listaDeTarefas.Count == 0)//validando se tem alguma tarefa cadastrada
            {
                Console.WriteLine("Você não possui nenhum Tarefa Cadastrada....!");
            }

            // Ordenando lista de tarefas com base no vencimento delas
            listaDeTarefas.Sort((tarefa1, tarefa2) => tarefa1.DataDeVencimento.CompareTo(tarefa2.DataDeVencimento));

            Console.WriteLine("---|-ID-|----|-Titulo-|----|-Descrição-|----|-Status-|---");
            for (int i = 0; i < listaDeTarefas.Count; i++)
            {
                Tarefa tarefa = listaDeTarefas[i];
                //exibindo todas as tarefas 
                Console.WriteLine($"[{i + 1}] {tarefa.Titulo} - {tarefa.Descricao} - {tarefa.DataDeVencimento:dd/MM/yyyy} - {(tarefa.Concluida ? "Concluída" : "Pendente")}");
            }
        }// fim da função de listar tarefas

        static void ExcluirTarefa()// função para excluir uma tarefa especifica 
        {
            Console.WriteLine("---- Exluindo Tarefa especifica ------");

            // Validadndo se tem alguma tarefa cadastrada 
            if (listaDeTarefas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma tarefa cadastrada para ser excluida...");
                return;
            }

            int indiceTarefa; // indice da tarefa selecionada para excluir 
            while (true)
            {
                Console.Write("Digite o indice da Tarefa a ser excluída:");
                if (int.TryParse(Console.ReadLine(), out indiceTarefa))// validando se e um valor inteiro informado pelo usuário 
                {
                    if (indiceTarefa > 0 && indiceTarefa <= listaDeTarefas.Count)// validando se o indice informado existe
                    {
                        break;
                    }
                }
                Console.WriteLine("Índice inválido! Tente novamente.");
            }


            Tarefa tarefaSelecionada = listaDeTarefas[indiceTarefa - 1];// Exluindo a tarefa selecionada 
            listaDeTarefas.Remove(tarefaSelecionada);

            Console.WriteLine("Tarefa excluída com sucesso!");
        }// fim da função de excluir tarefas

        static void MarcarTarefaComoConcluida()// função para marca tarefa como concluida
        {
            Console.WriteLine("---Marcar Tarefa Como Concluida ---");

            // validação para saber se existe a tarefas
            if (listaDeTarefas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma tarefa para ser marcada como concluida....");
                return;
            }

            int indiceTarefa;
            while (true)
            {
                Console.Write("Digite o indice da tarefa a ser marcada como concluída: ");
                if (int.TryParse(Console.ReadLine(), out indiceTarefa))// pegando o indice digitado pelo usuário
                {
                    if (indiceTarefa > 0 && indiceTarefa <= listaDeTarefas.Count)// validando se o indice ta no range das tarefas cadastradas
                    {
                        break;
                    }
                }
                Console.WriteLine("O índice inválido! Tente novamente....");// resposta para o usuário se o indice for inválido
            }

            Tarefa tarefaSelecionada = listaDeTarefas[indiceTarefa - 1];
            tarefaSelecionada.Concluida = true;

            Console.WriteLine("Tarefa marcada como concluída com sucesso....");
        }// fim da função de marcar como concluída a tarefa

        static List<Tarefa> listaDeTarefas = new List<Tarefa>(); // Arry para add tarefas

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----- Lista de Tarefas -----");
                Console.WriteLine("Adicionar tarefa - 1");
                Console.WriteLine("Editar tarefa - 2");
                Console.WriteLine("Excluir tarefa - 3");
                Console.WriteLine("Marcar tarefa como concluída - 4");
                Console.WriteLine("Exibir lista de tarefas - 5");
                Console.WriteLine("Sair - 0");
                Console.Write("Escolha uma opção: ");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarTarefa();
                        break;
                    case 2:
                        EditarTarefa();
                        break;
                    case 3:
                        ExcluirTarefa();
                        break;
                    case 4:
                        MarcarTarefaComoConcluida();
                        break;
                    case 5:
                        ListarTarefas();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando aplicação...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}


