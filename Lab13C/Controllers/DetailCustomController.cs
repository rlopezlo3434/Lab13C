using Lab13C.Models.Request;
using Lab13C.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public DetailCustomController(InvoiceContext context)
        {
            _context = context;
        }

        //Insertar una lista de Factura Detalle
        [HttpPost]
        public void InsertRange(List<DetailRequest> request)
        {
            //Convertir lista de Request a Lista modelo

            var modelos = request.Select(x => new Detail
            {
                DetailID = x.DetailID,
                Amount = x.Amount,
                Price = x.Price,
                SubTotal = x.SubTotal,
                InvoiceID = x.InvoiceID,
                Active = true
            }).ToList();

            _context.Details.AddRange(modelos);
            _context.SaveChanges();
        }
    }
}
