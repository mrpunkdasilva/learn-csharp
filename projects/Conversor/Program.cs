using System;
using System.Collections.Generic;

namespace AtividadeSemana1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            var parameters = ParseArguments(args);

            if (!ValidateParameters(parameters))
            {
                Console.WriteLine("Erro: Parametros 'valor', 'tipoEntrada' e 'tipoSaida' sao obrigatorios.");
                Console.WriteLine("Uso: dotnet run valor=<valor> tipoEntrada=<tipo> tipoSaida=<tipo>");
                return;
            }

            string valorStr = parameters["valor"];
            string tipoEntrada = parameters["tipoentrada"].ToLower();
            string tipoSaida = parameters["tiposaida"].ToLower();

            try
            {
                object valorEntrada = ParseInputValue(valorStr, tipoEntrada);
                object valorSaida = ConvertValue(valorEntrada, tipoSaida, valorStr);
                PrintResult(valorStr, tipoEntrada, valorSaida, tipoSaida);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Erro de conversao: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("=== Conversor de Tipos ===");
            Console.WriteLine("Por favor, forneca os parametros no formato chave=valor.");
            Console.WriteLine("Uso: dotnet run valor=<valor> tipoEntrada=<tipo> tipoSaida=<tipo>");
            Console.WriteLine("Exemplo: dotnet run valor=123.45 tipoEntrada=double tipoSaida=int");
            Console.WriteLine("Tipos suportados: int, double, float, bool, string, short");
        }

        static Dictionary<string, string> ParseArguments(string[] args)
        {
            var parameters = new Dictionary<string, string>();
            foreach (var arg in args)
            {
                var parts = arg.Split('=', 2);
                if (parts.Length == 2)
                {
                    parameters[parts[0].ToLower()] = parts[1];
                }
            }
            return parameters;
        }

        static bool ValidateParameters(Dictionary<string, string> parameters)
        {
            return parameters.ContainsKey("valor") &&
                   parameters.ContainsKey("tipoentrada") &&
                   parameters.ContainsKey("tiposaida");
        }

        
        static object ParseInputValue(string valorStr, string tipoEntrada)
        {
            try
            {
                return tipoEntrada switch
                {
                    "int" => int.Parse(valorStr),
                    "double" => double.Parse(valorStr),
                    "float" => float.Parse(valorStr),
                    "bool" => bool.Parse(valorStr),
                    "string" => valorStr,
                    "short" => short.Parse(valorStr),
                    _ => throw new ArgumentException($"Tipo de entrada desconhecido: {tipoEntrada}")
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ao processar o valor de entrada '{valorStr}': {ex.Message}", ex);
            }
        }

        static object ConvertValue(object valorEntrada, string tipoSaida, string valorStr)
        {
            try
            {
                return tipoSaida switch
                {
                    "int" => Convert.ToInt32(valorEntrada),
                    "double" => Convert.ToDouble(valorEntrada),
                    "float" => Convert.ToSingle(valorEntrada),
                    "bool" => Convert.ToBoolean(valorEntrada),
                    "string" => Convert.ToString(valorEntrada),
                    "short" => Convert.ToInt16(valorEntrada),
                    _ => throw new ArgumentException($"Tipo de saida desconhecido: {tipoSaida}")
                };
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Nao foi possivel converter '{valorStr}' ({valorEntrada.GetType().Name}) para {tipoSaida}: {ex.Message}", ex);
            }
        }

        static void PrintResult(string valorStr, string tipoEntrada, object valorSaida, string tipoSaida)
        {
            Console.WriteLine("=== Resultado da Conversao ===");
            Console.WriteLine($"Entrada: [{valorStr}] ({tipoEntrada})");
            Console.WriteLine($"Saida:   [{valorSaida}] ({tipoSaida})");
        }
    }
}