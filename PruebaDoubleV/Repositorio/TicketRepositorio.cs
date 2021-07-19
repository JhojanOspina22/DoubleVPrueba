using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class TicketRepository
    {

        public ResultTickets GetTickets(string filtro, string texto, int page)
        {
            using (var ctx = new DoublevModel())
            {
                var query = ctx.Tickets.Select(t => t);
                if (!String.IsNullOrEmpty(filtro))
                {

                    if (!String.IsNullOrEmpty(texto))
                    {

                        var parameterExp = Expression.Parameter(typeof(Ticket), "type");
                        var propertyExp = Expression.Property(parameterExp, filtro);

                        MethodInfo method = propertyExp.Type.Name.Equals("String") ? typeof(string).GetMethod("Contains", new[] { typeof(string) })
                        : typeof(Int32).GetMethod("Equals", new[] { typeof(Int32) });

                        var someValue = Expression.Constant(propertyExp.Type.Name.Equals("Int32") ? Convert.ToInt32(texto) : texto, propertyExp.Type.Name.Equals("String") ? typeof(string) : typeof(Int32));
                        var containsMethodExp = Expression.Call(propertyExp, method, someValue);

                        Expression<Func<Ticket, bool>> predicate = Expression.Lambda<Func<Ticket, bool>>(containsMethodExp, parameterExp);

                        query = query.Where(predicate);
                    }
                }
                query = query.OrderBy(t => t.Id);
                var totalitems = query.Count();
                query = query.Skip(10 * (page - 1)).Take(10);

                var totalPages = 0;
                var pagesrest = totalitems;
                while (pagesrest > 0)
                {
                    pagesrest -= 10;
                    totalPages++;
                }

                var lista = query.ToList();
                var Error = "";
                if (totalitems == 0)
                {
                    Error = "No se encontro ninguna coincidencia";
                }
                return new ResultTickets
                {
                    page = page,
                    totalpages = totalPages,
                    totalItems = totalitems,
                    items = lista.Count(),
                    Lista = lista,
                    error = Error
                };
            }
        }

        public Ticket ListarTicket(int IdTicket)
        {
            using (var ctx = new DoublevModel())
            {
                return ctx.Tickets.Select(t => t).FirstOrDefault(t => t.Id == IdTicket);
            }
        }

        public bool CrearTicket(Ticket t)
        {
            using (var ctx = new DoublevModel())
            {

                ctx.Tickets.Add(t);
                ctx.SaveChanges();

                return true;
            }
        }

        public bool ModificarTicket(Ticket t)
        {
            using (var ctx = new DoublevModel())
            {

                var Ticket = ctx.Tickets.FirstOrDefault(tt => tt.Id == t.Id);

                if (Ticket == null)
                    return false;

                Ticket.Usuario = t.Usuario;
                Ticket.FechaCreacion = t.FechaCreacion;
                Ticket.FechaActualizacion = t.FechaActualizacion;
                Ticket.Estatus = t.Estatus;
                ctx.SaveChanges();

                return true;

            }
        }
        public bool EliminarTicket(Ticket t)
        {
            using (var ctx = new DoublevModel())
            {

                var ticket = ctx.Tickets.FirstOrDefault(tt => tt.Id == t.Id);

                if (ticket == null) return false;

                ctx.Tickets.Remove(ticket);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}
