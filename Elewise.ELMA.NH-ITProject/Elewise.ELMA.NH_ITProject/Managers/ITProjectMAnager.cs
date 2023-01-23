using Elewise.ELMA.NH_ITProject.Models;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Services;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elewise.ELMA.NH_ITProject.Managers
{
    public class ITProjectManager : EntityManager<IITProject, long>
    {
        public new static ITProjectManager Instance
        {
            get { return Locator.GetServiceNotNull<ITProjectManager>(); }
        }

        /// <summary>
        /// Метод 1. Получение списка проектов, которые завершатся в текущем месяце
        /// </summary>
        /// <returns>List[IITProject] список проектов, удовлетворяющих условию</returns>
        public IList<IITProject> GetProjectsEndsCurrentMonth()
        {
            var crit = CreateCriteria()
                .Add(Restrictions.Ge("ProjectEndDate", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))) //дата конца >= 1 число тек месяца
                .Add(Restrictions.Lt("ProjectEndDate", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1))) //дата конца < 1 число след месяца
                .AddOrder(Order.Asc("ProjectEndDate")); //сортировка по возр
            return crit.List<IITProject>();
        }

        /// <summary>
        /// Метод 2. Получение проектов, на которые выделено более 200 часов и нет ведущего разработчика
        /// </summary>
        /// <returns>List[IITProject] список проектов, удовлетворяющих условию</returns>
        public IList<IITProject> GetProjects200PlusH_SenDevIsNull()
        {
            var crit = CreateCriteria()
                .Add(Restrictions.Gt("TimeBudget", (long)200)) //больше чем 200 чаосв
                .Add(Restrictions.IsNull("SenoirDeveloper"))//в поле главразраб null
                .AddOrder(Order.Asc("Name"));//сорт по имени по возр
            return crit.List<IITProject>();
        }

        /// <summary>
        /// Метод 3. Получение среднего количества участников в проектах
        /// </summary>
        /// <returns></returns>
        public double GetAvgUsrsByProject()
        {
            var cnt = Projections.Count("Id").As("Count");//число уч проекта
            var crit = CreateCriteria()
                .CreateCriteria("Users", "us", JoinType.InnerJoin)//иннер джоин по уч проекта и cte со счётчиком
                .SetProjection(Projections.ProjectionList()
                    .Add(Projections.GroupProperty("Id"), "Project")
                    .Add(cnt, "Count1")
                )
                .SetProjection(Projections.Avg(cnt));
            return crit.UniqueResult<double>();
        }

        /// <summary>
        /// Метод 4. Получение проектов, у которых есть ведущий разработчик и не определен срок сдачи
        /// </summary>
        /// <returns>List[IITProject] список проектов, удовлетворяющих условию</returns>
        public IList<IITProject> GetProjectsSenDevNotNullNoEndTime()
        {
            var crit = CreateCriteria()
                .Add(Restrictions.IsNotNull("SenoirDeveloper"))//в колонке главразраб не null
                .Add(Restrictions.IsNull("ProjectEndDate"))//в колонке дата сдачи null
                .AddOrder(Order.Asc("TimeBudget"));//сорт по времени на проект по возр

            return crit.List<IITProject>();
        }

        /// <summary>
        /// Метод 5. Получение суммы выделенных часов для проектов, которые были начаты в этом году и еще не завершены
        /// </summary>
        /// <returns>long сумма выделенных часов на проекты</returns>
        public long GetCurProjectsBudgetSum()
        {
            var crit = CreateCriteria()
                .Add(Restrictions.Ge("ProjectStartDate", new DateTime(DateTime.Now.Year, 1, 1)))//дата нач >= 01.01 тек года
                .Add(Restrictions.Lt("ProjectStartDate", DateTime.Now))//дата нач < сейчас
                .Add(Restrictions.Or(Restrictions.IsNull("ProjectEndDate"),
                    Restrictions.Gt("ProjectEndDate", DateTime.Now)))//или дата конца null или дата конца > сейчас
                .SetProjection(Projections.Sum(ProjectionFor(p => p.TimeBudget)));//складываем часы по проектам
            return crit.UniqueResult<long>();
        }

    }
}
