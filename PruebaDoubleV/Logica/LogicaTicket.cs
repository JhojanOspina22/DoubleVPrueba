using Modelo;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaTicket
    {
        private TicketRepository repositorio = new TicketRepository();

        public ResultTickets GetTickets(string filtro,string texto, int page)
        {
            try
            {
                return repositorio.GetTickets(filtro, texto, page);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearTicket(Ticket t)
        {
            try
            {
             
                return repositorio.CrearTicket(t);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarTicket(Ticket t)
        {
            try
            {
                return repositorio.ModificarTicket(t);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarTicket(Ticket t)
        {
            try
            {
                return repositorio.EliminarTicket(t);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
