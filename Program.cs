using System;
using System.Text.RegularExpressions;

namespace matrizletras
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabra = "";
            Regex alfabeto = new Regex("^[A-Za-z áÁéÉíÍóÓúÚÑñ]+$");
            bool palabraAceptable = false;

            Console.WriteLine("Escribe palabras o frases cortas y pulsa enter. (Ctrl+C para salir)");
            // Aunque supongo que es poco ortodoxo, he implementado este bucle infinito más externo,
            // para facilitar la ejecución recurrente del programa y ver mejor los resultados.
            do
            {
                do
                {
                    palabra = Console.ReadLine();
                    palabra = palabra.ToUpper();
                    if (palabra.Length < 1) Console.WriteLine("No ha introducido nada.");
                    else if (!alfabeto.IsMatch(palabra)) Console.WriteLine("Tienen que ser caracteres entre A y Z.");
                    else palabraAceptable = true;
                } while (!palabraAceptable);

                //Console.WriteLine($"La palabra a escribir es: {palabra}");

                // Definimos una matriz unidimensional de 7 strings
                // que serán las 7 líneas que contendrán la palabra.
                string[] matrizPalabra = new string[7];

                // Llamamos a la función que carga la palabra en la matriz.
                matrizPalabra = cargarPalabra(palabra);

                //Escribimos las siete líneas de la matrizPalabra.
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine(matrizPalabra[i]);
                }

            }while (true);
            // Sólo termina la ejecución del programa cuando el usuario pulsa Ctrl+C.
        }
        static public string[] cargarPalabra(string palabra)
        {
            string[] matrizPalabra = new string[7];
            char[,] matrizLetra = new char[7, 7];

            // Por cada letra de la palabra
            for (int i = 0; i < palabra.Length; i++)
            {
                // Primero cargamos la letra en una matriz[7,7]
                matrizLetra = cargarLetra(palabra[i]);

                // Por cada fila de ambas matrices (letra[7,7] y palabra[7])
                for (int m = 0; m < 7; m++)
                {
                    // Por cada columna de la matriz Letra:
                    // cargamos de letra hacia palabra.
                    for (int n = 0; n < 7; n++)
                    {
                        matrizPalabra[m] += matrizLetra[m, n];
                    }

                    // Insertamos una separación al final de cada letra
                    // para mejorar la legibilidad.
                    matrizPalabra[m] += "  ";
                }
            }
            return matrizPalabra;
        }

        static public char[,] cargarLetra(char letra)
        {
            char asterisco = '*';
            char pinta = '*';
            char espacio = ' ';
            char vacio = ' ';
            char blanco = ' ';
            char cadena = ' ';
            string[] letr = new string[7];
            int row = 0;
            int col = 0;
            int column = 0;
            int step = 0;
            int ind = 0;
            int count = 0;
            int i = 0;
            int j = 0;
            int fila = 0;
            int length = 7;
            int horizontal = default;
            int vertical = default;
            char[,] matrizLetra = new char[7, 7];
            // Inicializamos la matrizLetra a blancos, por si algún método no lo tuviera en cuenta.
            for (row= 0; row < 7; row++){
                for (col = 0; col < 7; col++){
                    matrizLetra[row,col] = ' ';
                }
            }

            switch (letra)
            {
                case 'A': case 'Á':
                    matrizLetra = new char[7, 7] {  {'*','*','*','*','*','*','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*','*','*','*','*','*','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'}};
                    break;

                case 'B': // Juanjo
                    for (i = 0; i < 7; i++)
                    {
                        //recorremos horizontal
                        for (j = 0; j < 7; j++)
                        {
                            matrizLetra[i, j] = (
                                    (((i == 0 || i == 6) && j < 4)
                                    ||
                                    ((i == 1 || i == 5 || i == 2) && (j == 0 || j == 3))
                                    ||
                                    ((i == 3 || i == 4) && (j == 0 || j == 2))) ? pinta : cadena
                            );
                        }
                    }
                    break;

                case 'C': // Justo
                    matrizLetra = new char[7, 7] {  {' ',' ','*','*','*','*',' '},
                                                    {' ','*',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ',' '},
                                                    {'*',' ',' ',' ',' ',' ',' '},
                                                    {'*',' ',' ',' ',' ',' ',' '},
                                                    {' ','*',' ',' ',' ',' ','*'},
                                                    {' ',' ','*','*','*','*',' '}
                    };
                    break;

                case 'D': // Miguel Angel
                    letr = new string[7];
                    letr[0] = "****** ";
                    letr[1] = "*     *";
                    letr[2] = "*     *";
                    letr[3] = "*     *";
                    letr[4] = "*     *";
                    letr[5] = "*     *";
                    letr[6] = "****** ";

                    // AÑADIDO:
                    // Pasamos el array de una dimensión al de dos dimensiones.
                    for (row = 0; row < 7; row++)
                    {
                        for (col = 0; col < 7; col++)
                        {
                            matrizLetra[row, col] = Convert.ToChar(letr[row].Substring(col, 1));
                        }
                    }

                    break;

                case 'E': case 'É': // Luis Miguel
                    matrizLetra = new char[7, 7] { {'*','*','*','*','*','*','*'}
                                                 , {'*',' ',' ',' ',' ',' ',' '}
                                                 , {'*',' ',' ',' ',' ',' ',' '}
                                                 , {'*','*','*','*','*',' ',' '}
                                                 , {'*',' ',' ',' ',' ',' ',' '}
                                                 , {'*',' ',' ',' ',' ',' ',' '}
                                                 , {'*','*','*','*','*','*','*'}};
                    break;

                case 'F': // Carola
                    length = 7;
                    asterisco = '*';
                    blanco = ' ';
                    for (row = 0; row < length; row++)
                    {
                        for (column = 0; column < length; column++)
                        {
                            matrizLetra[row, column] = (
                                row == 0 ||
                                row == 3 ||
                                column == 0
                                ? asterisco : blanco);
                        }
                    }
                    break;

                case 'G': // Carola
                    length = 7;
                    asterisco = '*';
                    blanco = ' ';
                    for (row = 0; row < length; row++)
                    {
                        for (column = 0; column < length; column++)
                        {
                            matrizLetra[row, column] = (
                                column == 0 ||
                                (column == 6 && row > 2) ||
                                (row == 3 && column > 3) ||
                                row == 0 ||
                                row == 6
                                ? asterisco : blanco);
                        }
                    }
                    break;

                case 'H': // Carola
                    for (row = 0; row < length; row++)
                    {
                        for (column = 0; column < length; column++)
                        {
                            matrizLetra[row, column] = (
                                row == 3 ||
                                column == 0 ||
                                column == 6
                                ? asterisco : blanco);
                        }
                    }
                    break;

                case 'I': case 'Í': // Carlos
                    for (row = 0; row < length; row++)
                    {
                        for (column = 0; column < length; column++)
                        {
                            matrizLetra[row, column] = (
                            (((row == 0) && (column > 0 && column < 6)) ||
                            (column == 3) ||
                            ((row == 6) && (column > 0 && column < 6)))
                            ? asterisco : espacio);
                        }
                    }
                    break;

                case 'J':
                    matrizLetra = new char[7, 7] {  {'*','*','*','*','*','*','*'},
                                                    {' ',' ',' ',' ',' ',' ','*'},
                                                    {' ',' ',' ',' ',' ',' ','*'},
                                                    {' ',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {' ','*',' ',' ',' ',' ','*'},
                                                    {' ',' ','*','*','*','*','*'}};

                    break;

                case 'K': // René
                    char[] miLetra = new char[49];
                    for (int h = 0; h < 49; h++)
                    {
                        miLetra[h] = ' ';
                    }
                    int f = 0, c = 1, paso = 2, index = 5, conteo = 0;
                    while (f < 7)
                    {
                        miLetra[conteo] = '*';
                        //Console.Write("*");
                        conteo++;
                        while (c < 5)
                        {
                            if (c == (index - 1) && (f < 4))
                            {
                                miLetra[conteo] = '*';
                                //Console.Write("*");
                                conteo++;
                            }
                            else if (f > 3)
                            {
                                if ((f - paso) == c)
                                {
                                    miLetra[conteo] = '*';
                                    //Console.Write("*");
                                    conteo++;
                                }
                                else
                                {
                                    miLetra[conteo] = ' ';
                                    //Console.Write(" ");
                                    conteo++;
                                }
                            }
                            else
                            {
                                miLetra[conteo] = ' ';
                                //Console.Write(" ");
                                conteo++;
                            }
                            c++;
                        }
                        index--;
                        c = 1;
                        //Console.Write("\n");
                        f++;
                    }

                    // AÑADIDO:
                    // Pasar el array de 1 dimensión de René miLetra[49] al array de 2 dimensiones matrizLetra[7,7].
                    // En el caso de la K, sólo se usan las cinco primeras columnas.
                    i = 0;
                    for (fila = 0; fila < 7; fila++)
                    {
                        for (col = 0; col < 5; col++)
                        {
                            matrizLetra[fila, col] = miLetra[i++];
                        }
                    }
                    break;

                case 'L': // Jose Vicente
                    for (i = 0; i < 7; i++)
                    {
                        matrizLetra[i, 0] = '*';
                        matrizLetra[6, i] = '*';
                    }
                    break;

                case 'M': // Justo
                    matrizLetra = new char[7, 7] {  {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*','*',' ',' ',' ','*','*'},
                                                    {'*',' ','*',' ','*',' ','*'},
                                                    {'*',' ',' ','*',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'}};
                    break;

                case 'N': // Miguel Angel
                    letr[0] = "*     *";
                    letr[1] = "**    *";
                    letr[2] = "* *   *";
                    letr[3] = "*  *  *";
                    letr[4] = "*   * *";
                    letr[5] = "*    **";
                    letr[6] = "*     *";

                    // AÑADIDO:
                    // Pasamos el arrays de una dimensión al de dos dimensiones.
                    for (row = 0; row < 7; row++)
                    {
                        for (col = 0; col < 7; col++)
                        {
                            matrizLetra[row, col] = Convert.ToChar(letr[row].Substring(col, 1));
                        }
                    }
                    break;

                case 'Ñ': // Juan Ramón
                    for (i = 0; i < 7; i++)
                    {
                        matrizLetra[0, i] = '*';
                    }
                    for (i = 2; i < 7; i++)
                    {
                        matrizLetra[i, 0] = '*';
                        matrizLetra[i, 6] = '*';
                    }
                    matrizLetra[2, 1] = '*';
                    matrizLetra[3, 2] = '*';
                    matrizLetra[4, 3] = '*';
                    matrizLetra[5, 4] = '*';
                    matrizLetra[6, 5] = '*';
                    break;

                case 'O': case 'Ó': // Justo
                    matrizLetra = new char[7, 7] {  {' ',' ','*','*','*',' ',' '},
                                                    {' ','*',' ',' ',' ','*',' '},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {' ','*',' ',' ',' ','*',' '},
                                                    {' ',' ','*','*','*',' ',' '}
                    };
                    break;

                case 'P':
                    for (horizontal = 0; horizontal < length; horizontal++)
                    {
                        for (vertical = 0; vertical < length; vertical++)
                        {
                            matrizLetra[horizontal, vertical] = (
                                (vertical == 0 ||
                                (horizontal == 0 && vertical < 6) ||
                                (vertical == 6 && (horizontal == 1 || horizontal == 2)) ||
                                (horizontal == 3 && vertical < 6)
                                ? asterisco : vacio));
                        }
                    }
                    break;

                case 'Q': // Justo
                    matrizLetra = new char[7, 7] {  {' ','*','*','*','*','*',' '},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ','*',' '},
                                                    {' ','*','*','*','*',' ','*'}};
                    break;

                case 'R': // Carlos
                    for (row = 0; row < length; row++)
                    {
                        for (column = 0; column < length; column++)
                        {
                            matrizLetra[row, column] = (
                            (column == 0) ||
                            ((row == 0 || row == 4) && column < 4) ||
                            (column == 4 && (row == 0 || row == 3 || row == 5)) ||
                            (column == 5 && (row == 1 || row == 2 || row == 6))
                            ? asterisco : espacio);
                        }
                    }
                    break;

                case 'S': // Juanjo
                    for (i = 0; i < 7; i++)
                    {
                        for (j = 0; j < 7; j++)
                        {
                            matrizLetra[i, j] = (
                            (((i == 0 || i == 6) && (j < 3))
                                || ((i == 1 || i == 2) && (j == 0))
                                || (i == 3 && j == 1)
                                || ((i == 4 || i == 5) && (j == 2))) ? pinta : cadena
                            );
                        }
                    }
                    break;

                case 'T': // Jose Vicente
                    for (i = 0; i < 7; i++)
                    {
                        matrizLetra[0, i] = '*';
                        matrizLetra[i, 3] = '*';
                    }
                    break;

                case 'U': case 'Ú':// Ino
                    matrizLetra = new char[7, 7] {  {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*',' ',' ',' ',' ',' ','*'},
                                                    {'*','*','*','*','*','*','*'}};
                    break;

                case 'V': // Javier
                    for (row = 0; row < 7; row++)
                    {
                        for (column = 0; column < 7; column++)
                        {
                            matrizLetra[row, column] = (
                            (column == 0 || column == 6) && (row == 0 || row == 1) ? '*' :
                            (column == 1 || column == 5) && (row == 2 || row == 3) ? '*' :
                            (column == 2 || column == 4) && (row == 4 || row == 5) ? '*' :
                            (column == 3) && (row == 6) ? '*' : ' ');
                        }
                    }
                    break;

                case 'W': // René
                    miLetra = new char[49];
                    row = 0;
                    col = 0;
                    step = 0;
                    ind = 5;
                    count = 0;
                    while (row < 7)
                    {
                        while (col < 7)
                        {
                            if (((col == 0) || (col == 3) || (col == 6)) && (row < 5))
                            {
                                miLetra[count] = '*';
                                //Console.Write("*");
                                count++;
                            }
                            else if ((row == 5) && (step == col))
                            {
                                miLetra[count] = '*';
                                //Console.Write("*");
                                count++;
                                step = step + 2;
                            }
                            else if ((row == 6) && ((col == 1) || (col == 5)))
                            {
                                miLetra[count] = '*';
                                //Console.Write("*");
                                count++;
                                step = step + 2;
                            }
                            else
                            {
                                miLetra[count] = ' ';
                                //Console.Write(" ");
                                count++;
                            }
                            col++;
                        }
                        ind--;
                        col = 0;
                        //Console.Write("\n");
                        row++;
                    }

                    // AÑADIDO:
                    // Pasar el array de 1 dimensión de René miLetra[49] al array de 2 dimensiones matrizLetra[7,7].
                    i = 0;
                    for (fila = 0; fila < 7; fila++)
                    {
                        for (col = 0; col < 7; col++)
                        {
                            matrizLetra[fila, col] = miLetra[i++];
                        }
                    }
                    break;

                case 'X': // Ino
                    matrizLetra = new char[7, 7] {  {'*',' ',' ',' ',' ',' ','*'},
                                                    {' ','*',' ',' ',' ','*',' '},
                                                    {' ',' ','*',' ','*',' ',' '},
                                                    {' ',' ',' ','*',' ',' ',' '},
                                                    {' ',' ','*',' ','*',' ',' '},
                                                    {' ','*',' ',' ',' ','*',' '},
                                                    {'*',' ',' ',' ',' ',' ','*'}};
                    break;

                case 'Y': // Juan Ramón
                    matrizLetra[0, 0] = '*';
                    matrizLetra[1, 1] = '*';
                    matrizLetra[2, 2] = '*';
                    matrizLetra[3, 3] = '*';
                    matrizLetra[2, 4] = '*';
                    matrizLetra[1, 5] = '*';
                    matrizLetra[0, 6] = '*';
                    for (i = 3; i < 7; i++)
                        matrizLetra[i, 3] = '*';
                    break;

                case 'Z': // Javier
                    for (row = 0; row < 7; row++)
                    {
                        for (column = 0; column < 7; column++)
                        {
                            matrizLetra[row, column] = (
                            (column >= 0 || column <= 6) && (row == 0 || row == 6) ? '*' :
                            (column == 1 && row == 5) ? '*' : (column == 2 && row == 4) ? '*' :
                            (column == 3 && row == 3) ? '*' : (column == 4 && row == 2) ? '*' :
                            (column == 5 && row == 1) ? '*' : ' ');
                        }
                    }

                    break;

                case ' ':
                    matrizLetra = new char[7, 7] {  {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '},
                                                    {' ',' ',' ',' ',' ',' ',' '}
                    };
                    break;
            };
            return matrizLetra;
        }
    }
}
