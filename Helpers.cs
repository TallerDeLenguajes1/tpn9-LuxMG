using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Helpers{
	class ConversorDeMorse{
		static Dictionary<string, string> CodigoMorse = new Dictionary<string, string>(){
			{"a", ".-"}, 	{"b", "-..."}, 	{"c", "-.-."}, 	{"d", "-.."},
			{"e", "."}, 	{"f", "..-."}, 	{"g", "--."}, 	{"h", "...."},
			{"i", ".."}, 	{"j", ".---"}, 	{"k", "-.-"}, 	{"l", ".-.."},
			{"m", "--"}, 	{"n", "-."}, 	{"o", "---"}, 	{"p", ".--."},
			{"q", "--.-"}, 	{"r", ".-."}, 	{"s", "..."}, 	{"t", "-"},
			{"u", "..-"}, 	{"v", "...-"}, 	{"w", ".--"}, 	{"x", "-..-"},
			{"y", "-.--"}, 	{"z", "--.."}, 	{"0", "-----"}, {"1", ".----"}, 
			{"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."}, 
			{"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."},
			{" ", "/"}
		};

		static public void Usar(){
			Console.WriteLine("Ingrese texto a convertir en morse: ");
			string texto = Console.ReadLine();
			TextoAMorse(texto);

			string fecha = DateTime.Now.ToString("yy-MM-dd_hh-mm-ss");
			string path = @"Morse/morse_" + fecha + ".txt";

			List<string> morse = File.ReadLines(path).ToList();
			foreach(string linea in morse){
				if(linea != null) MorseATexto(linea);
			}
		}

		//recibe un string en morse y devuelve la traduccion
		static public void MorseATexto(string morse){
			string texto = "";
			
			string[] text = morse.Split(" ");
			foreach(string letra in text){
				foreach(KeyValuePair<string, string> a in CodigoMorse){
					if(a.Value == letra) texto += a.Key;
				}
			}

			//crea un archivo con el texto traducido
			if(!Directory.Exists(@"Texto")) Directory.CreateDirectory(@"Texto");
			string path = @"Texto/texto_";
			CrearArchivo(texto, path);
		}

		//recibe un string en texto y lo devuelve en morse
		static public void TextoAMorse(string texto){
			string morse = "";
			texto = texto.ToLower();

			foreach(char letra in texto){
				morse += CodigoMorse[letra.ToString()] + " ";
			}	

			//crea un archivo con el texto en morse
			if(!Directory.Exists(@"Morse")) Directory.CreateDirectory(@"Morse");
			string path = @"Morse/morse_";
			CrearArchivo(morse, path);
		}

		static public void CrearArchivo(string texto, string path){
			string fecha = DateTime.Now.ToString("yy-MM-dd_hh-mm-ss");
			path += fecha + ".txt";

			Console.WriteLine("Revise el archivo: " + path);
			File.WriteAllText(path, texto);
		}
	}
}