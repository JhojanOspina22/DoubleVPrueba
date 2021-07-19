using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Modelo;

namespace PruebaDoubleV.Controllers
{
    [ApiController]
    [Route("doublev")]
    public class DoublevControler : ControllerBase
    {
        private LogicaTicket LogicaTicket = new LogicaTicket();

        [HttpGet]
        [Route("/Listar")]
        public ResultTickets GetTickets(string filtro, string texto, int page)
        {
            return LogicaTicket.GetTickets(filtro, texto, page);
        }
        [HttpPost]
        [Route("/CrearTicket")]
        public Boolean CrearTicket(Ticket t)
        {

            return LogicaTicket.CrearTicket(t);
        }

        [HttpPut]
        [Route("/ModificarTicket")]
        public Boolean ModificarTicket(Ticket t)
        {

            return LogicaTicket.ModificarTicket(t);
        }

        [HttpDelete]
        [Route("/EliminarTicket")]
        public Boolean EliminarTicket(Ticket t)
        {

            return LogicaTicket.EliminarTicket(t);
        }

    }
}
