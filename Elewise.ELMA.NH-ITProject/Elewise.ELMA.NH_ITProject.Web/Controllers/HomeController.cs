using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Web.Mvc.Extensions;
using EleWise.ELMA.Web.Mvc.Attributes;
using EleWise.ELMA.Web.Mvc.Controllers;
using Elewise.ELMA.NH_ITProject.Managers;
using Orchard;
using Orchard.Themes;

namespace Elewise.ELMA.NH_ITProject.Web.Controllers
{
    [Themed]
    public class HomeController : BaseController
    {
        //
        // GET: /Elewise.ELMA.NH_ITProject.Web/

        public ActionResult Index()
        {
            var mgr = ITProjectManager.Instance;

            var m1 = mgr.GetProjectsEndsCurrentMonth();
            var m2 = mgr.GetProjects200PlusH_SenDevIsNull();
            var m3 = mgr.GetAvgUsrsByProject();
            var m4 = mgr.GetProjectsSenDevNotNullNoEndTime();
            var m5 = mgr.GetCurProjectsBudgetSum();

            return View();
        }

    }
}
