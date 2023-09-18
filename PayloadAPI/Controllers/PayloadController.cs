using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using PayloadAPI.Models;

namespace PayloadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        

        private readonly ILogger<PayloadController> _logger;
        public PayloadController(ILogger<PayloadController> logger ) 
        {
            _logger = logger;
        }

        public PayloadDbContext _context = new PayloadDbContext();


        [Route("getall")]
        [HttpGet]
        public List<Payload> GetAll()
        {
            _logger.LogInformation("Payload lists.");
            List<Payload> result = _context.Payloads.ToList();
            return result;
        }

        [Route("insert")]
        [HttpPost]
        public string ReceivePayloadAndInsert(PayloadInfo payloadifo)
        {
            try
            {
                _logger.LogInformation("Insert payload.");
                Payload payload = new Payload();

                payload.Deviceid = payloadifo.Deviceid;
                payload.Temperature = payloadifo.data.Temperature;
                payload.Humidity = payloadifo.data.Humidity;
                payload.Occupancy = payloadifo.data.Occupancy;

                _context.Payloads.Add(payload);
                _context.SaveChanges();

                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("upsert")]
        [HttpPost]
        public string Upsert(Payload payload)
        {
            try
            {
                Payload updateentity = new Payload();

                if (payload.Id == 0)
                {
                    _context.Payloads.Add(payload);
                    _context.SaveChanges();
                }
                else
                {
                    var entity = _context.Payloads.Find(payload.Id);
                    if (entity != null)
                    {
                        _context.Entry(entity).CurrentValues.SetValues(payload);
                        _context.SaveChanges();
                    }
                }

                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("detail")]
        [HttpGet]
        public Payload? GetDetail(int payloadid)
        {
            Payload? result = _context.Payloads.Find(payloadid);
            return result;
        }

        [Route("delete")]
        [HttpGet]
        public string Delete(int payloadid)
        {
            try
            {
                Payload? olddata = _context.Payloads.Find(payloadid);
                if (olddata != null)
                {
                    _context.Payloads.Remove(olddata);
                    _context.SaveChanges();


                    Payload? isoldata = _context.Payloads.Find(payloadid);
                    if (isoldata == null)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Fail";
                    }
                }
                else
                {
                    return "Your Id is invalid!";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
