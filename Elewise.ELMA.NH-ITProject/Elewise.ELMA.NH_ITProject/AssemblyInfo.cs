[assembly: System.Runtime.InteropServices.Guid("99092343-51cf-4a44-a8b4-0cdede5ab578")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyTitle("Elewise.ELMA.NH_ITProject")]
[assembly: System.Reflection.AssemblyDescription("Модуль к аттестации NHibernate Developer Junior. Main and the only developer is L" +
        "eonid Goncharov, All rights reserved.\r\n\r\nModule adds \"IT-Project\" entity, Works " +
        "with DB via NHibernate,")]
[assembly: EleWise.ELMA.ComponentModel.ComponentAssembly()]
[assembly: EleWise.ELMA.Model.Attributes.ModelAssembly()]

#pragma warning disable 108,114,162,ELMA1705
namespace Elewise.ELMA.NH_ITProject
{
    using System;
    
    
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.AssemblyInfoMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("99092343-51cf-4a44-a8b4-0cdede5ab578")]
    [global::EleWise.ELMA.Model.Attributes.AssemblySummary(typeof(@__Resources__AssemblyInfo), "Summary")]
    internal class @__AssemblyInfo
    {
        
        /// <summary>
        /// Уникальный идентификатор данного класса
        /// </summary>
        public const string UID_S = "99092343-51cf-4a44-a8b4-0cdede5ab578";
        
        private static global::System.Guid _UID = new global::System.Guid(UID_S);
        
        /// <summary>
        /// Уникальный идентификатор данного класса
        /// </summary>
        public static global::System.Guid UID
        {
            get
            {
                return _UID;
            }
        }
    }
    
    internal class @__Resources__AssemblyInfo
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Elewise.ELMA.NH_ITProject");
            }
        }
        
        public static string Description
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Модуль к аттестации NHibernate Developer Junior. Main and the only developer is L" +
                        "eonid Goncharov, All rights reserved.\r\n\r\nModule adds \"IT-Project\" entity, Works " +
                        "with DB via NHibernate,");
            }
        }
        
        public static string Summary
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Модуль к аттестации NHibernate Dev Jun");
            }
        }
    }
}
#pragma warning restore 108,114,162,ELMA1705
