using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeEmExtenso.ConsoleApp
{
    public class Numeros
    {
        // public string Centavos(string numero)
        // {
        //     string numeroTest = "centavo";
        //     double novoNumero = Double.Parse(numero);
        //     if (novoNumero < 1)
        //     {
        //         if (novoNumero < 0.10)
        //         {
        //             switch (novoNumero)
        //             {
        //                 case 0.01:
        //                     numeroTest = Unidades("1") + " centavo";
        //                     break;
        //             }
        //         }
        //     }
        //     return numeroTest;
        // }

        public String Unidades(String numero)
        {
            int _numero = Convert.ToInt32(numero);
            String nome = "";
            switch (_numero)
            {
                case 1:
                    nome = "um";
                    break;
                case 2:
                    nome = "dois";
                    break;
                case 3:
                    nome = "três";
                    break;
                case 4:
                    nome = "quatro";
                    break;
                case 5:
                    nome = "cinco";
                    break;
                case 6:
                    nome = "seis";
                    break;
                case 7:
                    nome = "sete";
                    break;
                case 8:
                    nome = "oito";
                    break;
                case 9:
                    nome = "nove";
                    break;
            }
            return nome;
        }

        public String Dezenas(String numero)
        {
            int _numero = Convert.ToInt32(numero);
            String nome = null;
            switch (_numero)
            {
                case 10:
                    nome = "dez";
                    break;
                case 11:
                    nome = "onze";
                    break;
                case 12:
                    nome = "doze";
                    break;
                case 13:
                    nome = "treze";
                    break;
                case 14:
                    nome = "quatorze";
                    break;
                case 15:
                    nome = "quinze";
                    break;
                case 16:
                    nome = "dezesseis";
                    break;
                case 17:
                    nome = "dezessete";
                    break;
                case 18:
                    nome = "dezoito";
                    break;
                case 19:
                    nome = "dezenove";
                    break;
                case 20:
                    nome = "vinte";
                    break;
                case 30:
                    nome = "trinta";
                    break;
                case 40:
                    nome = "quarenta";
                    break;
                case 50:
                    nome = "cinquenta";
                    break;
                case 60:
                    nome = "sessenta";
                    break;
                case 70:
                    nome = "setenta";
                    break;
                case 80:
                    nome = "oitenta";
                    break;
                case 90:
                    nome = "noventa";
                    break;
                default:
                    if (_numero > 0)
                    {
                        nome = Dezenas(numero.Substring(0, 1) + "0") + " e " + Unidades(numero.Substring(1));
                    }
                    break;
            }
            return nome;
        }

        public String ConveterNumerosGrandes(String numero)
        {
            string word = "";
            try
            {
                bool beginsZero = false;   
                bool isDone = false;   
                double dblAmt = (Convert.ToDouble(numero));
                 
                if (dblAmt > 0)
                { 
                    beginsZero = numero.StartsWith("0");

                    int numDigits = numero.Length;
                    int pos = 0;   
                    String place = "";
                    switch (numDigits)
                    {
                        case 1:  

                            word = Unidades(numero);
                            isDone = true;
                            break;
                        case 2:   
                            word = Dezenas(numero);
                            isDone = true;
                            break;
                        case 3:   
                            pos = (numDigits % 3) + 1;
                            place = "centos ";
                            break;
                        case 4:   
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " mil ";
                            break;
                        case 7:  
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " milhões ";
                            break;
                        case 10:   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " bilhões ";
                            break;
                       
                        default:
                            isDone = true;
                            break;
                    }

                    string a = numero.Substring(pos);

                    if (!isDone)
                    {   
                        if (numero.Substring(0, pos) != "0" && numero.Substring(pos) != "0")
                        {
                            if (numero.Substring(0, pos) != "100" && numero.Substring(0, pos) != "200" && numero.Substring(0, pos) != "300")
                            {
                                try
                                {
                                    word = ConveterNumerosGrandes(numero.Substring(0, pos)) + place + ConveterNumerosGrandes(numero.Substring(pos));
                                    if (word.Trim().Substring(0, 6) == "um mil")
                                         word = word.Remove(0, 2);
                                }
                                catch { }
                            }

                            else if (numero.Substring(0, pos) == "100")
                                word = "cem" + place + ConveterNumerosGrandes(numero.Substring(pos));

                            else if (numero.Substring(0, pos) == "200")
                                word = "duzentos" + place + ConveterNumerosGrandes(numero.Substring(pos));

                            else if (numero.Substring(0, pos) == "300")
                                word = "trezentos" + place + ConveterNumerosGrandes(numero.Substring(pos));

                        }
                        else
                        {
                            word = ConveterNumerosGrandes(numero.Substring(0, pos)) + ConveterNumerosGrandes(numero.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names
                    //if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
           

            return word.Trim();
        }

        public String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";

            if (number.Substring(0, 1) == "0")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    digit = number[i].ToString();
                    if (!digit.Equals("0"))
                    {
                        engOne = Unidades(digit);
                        cd += " " + engOne;
                    }
                }
            }

            else
            {
                digit = number.ToString();
                if (!digit.Equals("0"))
                {
                    engOne = Dezenas(digit);
                    cd += " " + engOne;
                }

            }

            return cd;
        }


        


        //  private static String ConvertToWords(String numb)
        //  {
        //      String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
        //      String endStr = "centavos";
        //      try
        //      {
        //          int decimalPlace = numb.IndexOf(".");
        //          if (decimalPlace > 0)
        //          {
        //              wholeNo = numb.Substring(0, decimalPlace);
        //              points = numb.Substring(decimalPlace + 1);
        //              if (Convert.ToInt32(points) > 0)
        //              {
        //                  andStr = "and";// just to separate whole numbers from points/cents    
        //                  endStr = "Paisa " + endStr;//Cents    
        //                  pointStr = ConvertDecimals(points);
        //              }
        //          }
        //          val = String.Format("{0} {1}{2} {3}", ConveterNumerosGrandes(wholeNo).Trim(), andStr, pointStr, endStr);
        //      }
        //      catch { }
        //      return val;
        //  }



    }
}
