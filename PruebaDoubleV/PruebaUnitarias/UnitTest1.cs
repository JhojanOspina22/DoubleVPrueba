using System;
using Xunit;
using Repositorio;

namespace PruebaUnitarias
{
    public class UnitTest1
    {
        private TicketRepository repository = new TicketRepository();

        [Fact]
        public void Test1()
        {
            Assert.NotNull( repository.GetTickets("Id", "1", 1));
        }
    }
}
