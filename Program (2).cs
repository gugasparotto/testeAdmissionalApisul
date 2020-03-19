using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TesteGus
{
    public class Entrys
    {
        public int andar { get; set; }
        public char elevador { get; set; }
        public char turno { get; set; }
    }
    public class Dados
    {
        public int matutino;
        public int vespertino;
        public int noturno;
        public int numDeUtilizacao;
    }

    class Program
    {
        // [0,0,1,1,4,0,1,0,2]
        // [{1,0},{2,3}]
        /// <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
        public static List<int> andarMenosUtilizado(List<Entrys> items)
        {
            int[] andares = new int[16];

            foreach (Entrys element in items)
            {
                andares[element.andar]++;
            }

            int minAndar = andares[0];
            for (int i = 0; i < 16; i++)
            {
                if (minAndar > andares[i])
                    minAndar = andares[i];
                Console.WriteLine("O andar " + i + " esta com: " + andares[i]);
            }

            var andaresMenosUtilizados = new List<int>();
            for (int andar = 0; andar < 16; andar++)
            {
                if (minAndar == andares[andar])
                    andaresMenosUtilizados.Add(andar);
            }

            Console.WriteLine("Andares menos utilizados:");
            foreach (int element in andaresMenosUtilizados)
            {
                Console.WriteLine(element);
            }

            return andaresMenosUtilizados;
        }

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
        public static List<char> elevadorMaisFrequentado(Dictionary<char, Dados> elevadores)
        {
            int maiorFreq = 0;
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                if (maiorFreq < entry.Value.numDeUtilizacao)
                    maiorFreq = entry.Value.numDeUtilizacao;
            }

            var elevadorMaisFrequentado = new List<char>();
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                if (maiorFreq == entry.Value.numDeUtilizacao)
                    elevadorMaisFrequentado.Add(entry.Key);
            }
            Console.WriteLine("Elevador mais utilizado:");
            foreach (char element in elevadorMaisFrequentado)
            {
                Console.WriteLine(element);
                //Console.WriteLine($"Element #{count}: {element}");
            }
            return elevadorMaisFrequentado;
        }

        /// <summary> Deve retornar uma List contendo o perÃ­odo de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        public static List<char> periodoMaiorFluxoElevadorMaisFrequentado(Dictionary<char, Dados> elevadores)
        {
            var elevMaisFreq = new List<char>();
            elevMaisFreq = elevadorMaisFrequentado(elevadores);
            var maiorFluxoElevadores = new List<char>();
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                char maiorChar = ' ';
                foreach (char elev in elevMaisFreq)
                {
                    if (elev == entry.Key)
                    {
                        int maior = entry.Value.matutino;
                        maiorChar = 'M';
                        for (int i = 0; i < 2; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (maior < entry.Value.vespertino)
                                    {
                                        maior = entry.Value.vespertino;
                                        maiorChar = 'V';
                                    }
                                    break;
                                case 1:
                                    if (maior < entry.Value.noturno)
                                    {
                                        maior = entry.Value.noturno;
                                        maiorChar = 'N';
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                }
                if (maiorChar != ' ')
                    maiorFluxoElevadores.Add(maiorChar);
            }
            Console.WriteLine("Periodo elevador mais utilizado:");
            foreach (char element in maiorFluxoElevadores)
            {
                Console.WriteLine(element);
                //Console.WriteLine($"Element #{count}: {element}");
            }
            return maiorFluxoElevadores;
        }

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
        public static List<char> elevadorMenosFrequentado(Dictionary<char, Dados> elevadores)
        {
            int menorFreq = 5000000;
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                if (menorFreq > entry.Value.numDeUtilizacao)
                    menorFreq = entry.Value.numDeUtilizacao;
            }

            var elevadorMenosFrequentado = new List<char>();
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                if (menorFreq == entry.Value.numDeUtilizacao)
                    elevadorMenosFrequentado.Add(entry.Key);
            }
            Console.WriteLine("Elevador menos utilizado:");
            foreach (char element in elevadorMenosFrequentado)
            {
                Console.WriteLine(element);
                //Console.WriteLine($"Element #{count}: {element}");
            }
            return elevadorMenosFrequentado;
        }


        /// <summary> Deve retornar uma List contendo o perÃ­odo de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        public static List<char> periodoMenorFluxoElevadorMenosFrequentado(Dictionary<char, Dados> elevadores)
        {
            var elevMenosFreq = new List<char>();
            elevMenosFreq = elevadorMenosFrequentado(elevadores);
            var menorFluxoElevadores = new List<char>();
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                char menorChar = ' ';
                foreach (char elev in elevMenosFreq)
                {
                    if (elev == entry.Key)
                    {
                        int menor = entry.Value.matutino;
                        menorChar = 'M';
                        for (int i = 0; i < 2; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (menor > entry.Value.vespertino)
                                    {
                                        menor = entry.Value.vespertino;
                                        menorChar = 'V';
                                    }
                                    break;
                                case 1:
                                    if (menor > entry.Value.noturno)
                                    {
                                        menor = entry.Value.noturno;
                                        menorChar = 'N';
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                }
                if (menorChar != ' ')
                    menorFluxoElevadores.Add(menorChar);
            }
            Console.WriteLine("Periodo elevador mais utilizado:");
            foreach (char element in menorFluxoElevadores)
            {
                Console.WriteLine(element);
                //Console.WriteLine($"Element #{count}: {element}");
            }
            return menorFluxoElevadores;
        }

        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilizaÃ§Ã£o do conjunto de elevadores. </summary> 
        public static List<char> periodoMaiorUtilizacaoConjuntoElevadores(Dictionary<char, Dados> elevadores)
        {
            var periodoMaiorFluxoElevadores = new List<char>();
            int matutinos = 0;
            int vespertinos = 0;
            int noturnos = 0;
            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                matutinos = matutinos + entry.Value.matutino;
                vespertinos = vespertinos + entry.Value.vespertino;
                noturnos = noturnos + entry.Value.noturno;
            }
            int maior = matutinos;
            if(maior < vespertinos)
                maior = vespertinos;
            if(maior < noturnos)
                maior = noturnos;
            for(int i = 0; i<3;i++)
            {
                switch (i)
                {
                    case 0:
                        if (maior == matutinos)
                            periodoMaiorFluxoElevadores.Add('M');
                        break;
                    case 1:
                        if (maior == vespertinos)
                            periodoMaiorFluxoElevadores.Add('V');
                        break;
                    case 2:
                        if (maior == noturnos)
                            periodoMaiorFluxoElevadores.Add('N');
                        break;
                    default: 
                        break;
                }
            }
            Console.WriteLine("Periodo maior fluxo elevadores:");
            foreach (char element in periodoMaiorFluxoElevadores)
            {
                Console.WriteLine(element);
                //Console.WriteLine($"Element #{count}: {element}");
            }
            return periodoMaiorFluxoElevadores;
        }

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relaÃ§Ã£o a todos os serviÃ§os prestados. </summary> 
        public static float percentualDeUsoElevadorA(Dictionary<char, Dados> elevadores)
        {
            float usoA = 0;
            float usoTotal = 0;
            if (elevadores.ContainsKey('A'))
            {
                Dados value = elevadores['A'];
                usoA = value.numDeUtilizacao;

            }

            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                usoTotal = usoTotal + entry.Value.numDeUtilizacao;
            }
            Console.WriteLine("Uso total: " + usoTotal + " ,uso A: " + usoA);
            float retorno = usoA / usoTotal;
            return retorno * 100;
        }
        
        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relaÃ§Ã£o a todos os serviÃ§os prestados. </summary> 
        public static float percentualDeUsoElevadorB(Dictionary<char, Dados> elevadores)
        {
            float usoB = 0;
            float usoTotal = 0;
            if (elevadores.ContainsKey('B'))
            {
                Dados value = elevadores['B'];
                usoB = value.numDeUtilizacao;

            }

            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                usoTotal = usoTotal + entry.Value.numDeUtilizacao;
            }
            Console.WriteLine("Uso total: " + usoTotal + " ,uso B: " + usoB);
            float retorno = usoB / usoTotal;
            return retorno * 100;
        }
        
        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relaÃ§Ã£o a todos os serviÃ§os prestados. </summary> 
        public static float percentualDeUsoElevadorC(Dictionary<char, Dados> elevadores)
        {
            float usoC = 0;
            float usoTotal = 0;
            if (elevadores.ContainsKey('C'))
            {
                Dados value = elevadores['C'];
                usoC = value.numDeUtilizacao;

            }

            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                usoTotal = usoTotal + entry.Value.numDeUtilizacao;
            }
            Console.WriteLine("Uso total: " + usoTotal + " ,uso C: " + usoC);
            float retorno = usoC / usoTotal;
            return retorno * 100;
        }
        
        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relaÃ§Ã£o a todos os serviÃ§os prestados. </summary> 
        public static float percentualDeUsoElevadorD(Dictionary<char, Dados> elevadores)
        {
            float usoD = 0;
            float usoTotal = 0;
            if (elevadores.ContainsKey('D'))
            {
                Dados value = elevadores['D'];
                usoD = value.numDeUtilizacao;

            }

            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                usoTotal = usoTotal + entry.Value.numDeUtilizacao;
            }
            Console.WriteLine("Uso total: " + usoTotal + " ,uso D: " + usoD);
            float retorno = usoD / usoTotal;
            return retorno * 100;
        }
        
        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relaÃ§Ã£o a todos os serviÃ§os prestados. </summary> 
        public static float percentualDeUsoElevadorE(Dictionary<char, Dados> elevadores)
        {
            float usoE = 0;
            float usoTotal = 0;
            if (elevadores.ContainsKey('E'))
            {
                Dados value = elevadores['E'];
                usoE = value.numDeUtilizacao;

            }

            foreach (KeyValuePair<char, Dados> entry in elevadores)
            {
                usoTotal = usoTotal + entry.Value.numDeUtilizacao;
            }
            Console.WriteLine("Uso total: " + usoTotal + " ,uso E: " + usoE);
            float retorno = usoE / usoTotal;
            return retorno*100;
        }


        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("input.json"))
            {
                string json = r.ReadToEnd();
                List<Entrys> items = JsonConvert.DeserializeObject<List<Entrys>>(json);
                int[] andares = new int[16];
               /* foreach (Entrys element in items)
                {
                    andares[element.andar]++;
                    //Console.WriteLine($"Element #{count}: {element}");
                }
                {   //Menos utilizados
                    int minAndar = andares[0];
                    for (int i = 0; i < 16; i++)
                    {
                        if (minAndar > andares[i])
                            minAndar = andares[i];
                        Console.WriteLine("O andar " + i + " esta com: " + andares[i]);
                    }
                    var andaresMenosUtilizados = new List<int>();
                    for (int i = 0; i < 16; i++)
                    {
                        if (minAndar == andares[i])
                            andaresMenosUtilizados.Add(i);
                    }
                    Console.WriteLine("Andares menos utilizados:");
                    foreach (int element in andaresMenosUtilizados)
                    {
                        Console.WriteLine(element);
                        //Console.WriteLine($"Element #{count}: {element}");
                    }
                }

                { //Mais Utilizados

                    int maxAndar = andares[0];
                    for (int i = 0; i < 16; i++)
                    {
                        if (maxAndar < andares[i])
                            maxAndar = andares[i];
                    }
                    var andaresMaisUtilizados = new List<int>();
                    for (int i = 0; i < 16; i++)
                    {
                        if (maxAndar == andares[i])
                            andaresMaisUtilizados.Add(i);
                    }
                    Console.WriteLine("Andares mais utilizados:");
                    foreach (int element in andaresMaisUtilizados)
                    {
                        Console.WriteLine(element);
                        //Console.WriteLine($"Element #{count}: {element}");
                    }
                }*/
                {// Maior frequencia por andar
                    var dictionary = new Dictionary<char, Dados>();
                    foreach (Entrys element in items)
                    {
                        if (dictionary.ContainsKey(element.elevador))
                        {
                            if (element.turno == 'M')
                                dictionary[element.elevador].matutino++;
                            if (element.turno == 'V')
                                dictionary[element.elevador].vespertino++;
                            if (element.turno == 'N')
                                dictionary[element.elevador].noturno++;

                            dictionary[element.elevador].numDeUtilizacao++;
                        }
                        else
                        {
                            var novaEntrada = new Dados();

                            if (element.turno == 'M')
                                novaEntrada.matutino = 1;
                            if (element.turno == 'V')
                                novaEntrada.vespertino = 1;
                            if (element.turno == 'N')
                                novaEntrada.noturno = 1;
                            novaEntrada.numDeUtilizacao = 1;

                            dictionary.Add(element.elevador, novaEntrada);
                        }

                    }

                    /*  if(dictionary.Count > 0)
                      {
                          int maiorFreq = 0;
                          foreach (KeyValuePair<char, Dados> entry in dictionary)
                          {
                              if (maiorFreq < entry.Value.numDeUtilizacao)
                                  maiorFreq = entry.Value.numDeUtilizacao;
                          }

                          var elevadoresMaisUtilizados = new List<char>();
                          foreach (KeyValuePair<char, Dados> entry in dictionary)
                          {
                              if (maiorFreq == entry.Value.numDeUtilizacao)
                                  elevadoresMaisUtilizados.Add(entry.Key);
                          }

                      }*/

                    andarMenosUtilizado(items);
                    elevadorMaisFrequentado(dictionary);
                    periodoMaiorFluxoElevadorMaisFrequentado(dictionary);
                    elevadorMenosFrequentado(dictionary);
                    periodoMenorFluxoElevadorMenosFrequentado(dictionary);
                    periodoMaiorUtilizacaoConjuntoElevadores(dictionary);
                    Console.WriteLine("Percentual uso A: " + percentualDeUsoElevadorA(dictionary).ToString("0.##"));
                    Console.WriteLine("Percentual uso B: " + percentualDeUsoElevadorB(dictionary).ToString("0.##"));
                    Console.WriteLine("Percentual uso C: " + percentualDeUsoElevadorC(dictionary).ToString("0.##"));
                    Console.WriteLine("Percentual uso D: " + percentualDeUsoElevadorD(dictionary).ToString("0.##"));
                    Console.WriteLine("Percentual uso E: " + percentualDeUsoElevadorE(dictionary).ToString("0.##"));
                    
                }
            }

            
        }


    }
}
