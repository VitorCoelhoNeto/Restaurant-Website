using Labb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb.Models
{
    public class RestauranteSearchFilters
    {
        public string Nome { get; set; }
        public bool TakeAway { get; set; }
        public bool Local { get; set; }
        public bool Entrega { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public string Morada { get; set; }
        public List<Restaurante> FiltrarHoras(List<Restaurante> restaurantes)
        {
            try
            {
                if(!this.Manha && !this.Tarde && !this.Noite)
                {
                    throw new Exception("SEM HORAS SELECIONADAS");
                }
                Regex timerules = new Regex(@"(([0-9]{2}):([0-9]{2}))[ ]?(AM)?|(PM)?|(am)?|(pm)?");
                List<Restaurante> filtrados = new List<Restaurante>();
                foreach (Restaurante restaurante in restaurantes)
                {
                    Match openmatch = timerules.Match(restaurante.HoraDeAbertura);
                    Match closematch = timerules.Match(restaurante.HoraDeFecho);
                    int HoraAbertura = int.Parse(openmatch.Groups[2].Value);
                    int HoraFecho = int.Parse(closematch.Groups[2].Value);
                    int MinutosAbertura = int.Parse(openmatch.Groups[3].Value);
                    int MinutosFecho = int.Parse(closematch.Groups[3].Value);
                    string tipoabertura = "";
                    string tipofecho = "";
                    if (HoraAbertura <= 12)
                    {
                        tipoabertura = "Manha";
                    }
                    else if (HoraAbertura <= 18)
                    {
                        tipoabertura = "Tarde";
                    }
                    else
                    {
                        tipoabertura = "Noite";
                    }
                    if (HoraFecho <= 12)
                    {
                        tipofecho = "Manha";
                    }
                    else if (HoraFecho <= 18)
                    {
                        tipofecho = "Tarde";
                    }
                    else
                    {
                        tipofecho = "Noite";
                    }
                    if (this.Manha && this.Tarde && this.Noite)
                    {
                        if (tipoabertura == "Manha" && tipofecho == "Noite")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                    else if (this.Manha && this.Tarde)
                    {
                        if (tipoabertura == "Manha" && tipofecho == "Tarde")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                    else if (this.Tarde && this.Noite)
                    {
                        if (tipoabertura == "Tarde" && tipofecho == "Noite")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                    else if (this.Manha)
                    {
                        if (tipoabertura == "Manha" && tipofecho == "Manha")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                    else if (this.Tarde)
                    {
                        if (tipoabertura == "Tarde" && tipofecho == "Tarde")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                    else if (this.Noite)
                    {
                        if (tipoabertura == "Noite" && tipofecho == "Noite")
                        {
                            filtrados.Add(restaurante);
                        }
                    }
                }
                return filtrados;
            }
            catch (Exception)
            {
                return restaurantes;
            }
        }
    }
}
