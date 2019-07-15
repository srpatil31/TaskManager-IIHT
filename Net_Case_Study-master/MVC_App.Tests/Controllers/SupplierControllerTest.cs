using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POPS_App.Models;
using POPS_DAL;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVC_App.Tests.Controllers
{
    [TestClass]
    public class SupplierControllerTest
    {
        [TestMethod]
        public void SaveSupplier()
        {
            Supplier supplier = new Supplier()
            {
                SUPLADDR = "Dummy Address",
                SUPLNAME = "Dummy Name",
                SUPLNO = "DM01"
            };

            var mock = new Mock<IController<Supplier>>();
            mock.Setup(q => q.Save(supplier)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.Save(supplier);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }

        [TestMethod]
        public void EditSupplier()
        {
            Supplier supplier = new Supplier()
            {
                SUPLADDR = "Dummy Address",
                SUPLNAME = "Dummy Name",
                SUPLNO = "DM01"
            };

            var mock = new Mock<IController<Supplier>>();
            mock.Setup(q => q.Update(supplier)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.Update(supplier);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetSupplier()
        {
            IList<Supplier> lstSupplier = new List<Supplier>() {
             new Supplier()
            {
                SUPLADDR = "Dummy Address",
                SUPLNAME = "Dummy Name",
                SUPLNO = "DM01"
            },
            new Supplier()
            {
                SUPLADDR = "Dummy Address",
                SUPLNAME = "Dummy Name",
                SUPLNO = "DM02"
            } };

            var mock = new Mock<IController<Supplier>>();
            mock.Setup(q => q.Get()).Returns(lstSupplier);

            Assert.AreEqual(2, mock.Object.Get().Count);
        }

        public void GetSupplier(string id)
        {
            var mock = new Mock<IController<Supplier>>();
            mock.Setup(q => q.Get(It.IsAny<string>())).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.Get(It.IsAny<string>());
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }
    }

    public class CodeAndReason : IHttpActionResult
    {
        private readonly HttpStatusCode code;
        private readonly string reason;

        public HttpStatusCode Code
        {
            get { return code; }
        }

        public CodeAndReason(HttpStatusCode code, string reason)
        {
            this.code = code;
            this.reason = reason;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(code)
            {
                ReasonPhrase = reason,
                Content = new StringContent(reason),
            };

            return Task.FromResult(response);
        }

        public static IHttpActionResult Ok(string reason)
        {
            return new CodeAndReason(HttpStatusCode.OK, reason);
        }

        public static IHttpActionResult NotFound(string reason)
        {
            return new CodeAndReason(HttpStatusCode.NotFound, reason);
        }

        public static IHttpActionResult Conflict(string reason)
        {
            return new CodeAndReason(HttpStatusCode.Conflict, reason);
        }

        public static IHttpActionResult Unauthorized(string reason)
        {
            return new CodeAndReason(HttpStatusCode.Unauthorized, reason);
        }
    }
}
